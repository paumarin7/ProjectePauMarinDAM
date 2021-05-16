﻿/*           INFINITY CODE          */
/*     https://infinity-code.com    */

using System;
using InfinityCode.uContext;
using InfinityCode.uContext.Tools;
using InfinityCode.uContext.UnityTypes;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace InfinityCode.uContextPro.Tools
{
    [InitializeOnLoad]
    public static class SmartSelection
    {
        private static GUIStyle _areaStyle;
        private static Rect screenRect;

        private static GUIStyle areaStyle
        {
            get
            {
                if (_areaStyle == null)
                {
                    _areaStyle = new GUIStyle(Waila.StyleID);
                    _areaStyle.fontSize = 10;
                    _areaStyle.stretchHeight = true;
                    _areaStyle.fixedHeight = 0;
                    _areaStyle.border = new RectOffset(8, 8, 8, 8);
                    _areaStyle.margin = new RectOffset(4, 4, 4, 4);
                }

                return _areaStyle;
            }
        }

        static SmartSelection()
        {
            Waila.OnClose += OnClose;
            Waila.OnDrawModeExternal += OnDrawModeExternal;
            Waila.OnUpdateTooltipsExternal += OnUpdateTooltipsExternal;
            Waila.OnStartSmartSelection += ShowSmartSelection;
        }

        private static void DrawButton(Transform t, bool addSlash, ref bool state)
        {
            if (t.parent != null)
            {
                DrawButton(t.parent, true, ref state);
            }

            if (GUILayout.Button(t.gameObject.name, Waila.labelStyle, GUILayout.ExpandWidth(false)))
            {
                if (Event.current.control || Event.current.shift) SelectionRef.Add(t.gameObject);
                else Selection.activeGameObject = t.gameObject;
                state = true;
            }

            if (GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition))
            {
                Waila.Highlight(t.gameObject);
            }

            if (addSlash) GUILayout.Label("/", Waila.labelStyle, GUILayout.ExpandWidth(false));
        }

        private static void DrawSmartSelection(Event e)
        {
            if (!UnityEditor.Tools.hidden) UnityEditor.Tools.hidden = true;

            try
            {
                Handles.BeginGUI();

                GUILayout.BeginArea(screenRect, areaStyle);
                
                GUILayout.Label("Select GameObject:", Waila.labelStyle);
                Rect rect = EditorGUILayout.GetControlRect(false, 1);
                rect.height = 1;
                EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));

                try
                {
                    bool state = false;

                    for (int i = 0; i < Waila.targets.Count; i++)
                    {
                        Transform t = Waila.targets[i].transform;
                        EditorGUILayout.BeginHorizontal();
                        DrawButton(t, false, ref state);
                        EditorGUILayout.EndHorizontal();
                    }

                    if (state)
                    {
                        Waila.mode = 0;
                        UnityEditor.Tools.hidden = false;
                    }
                }
                catch(Exception ex)
                {
                    Log.Add(ex);
                }

                GUILayout.EndArea();
                Handles.EndGUI();

                if (e.type == EventType.MouseUp)
                {
                    Waila.mode = 0;
                    UnityEditor.Tools.hidden = false;
                }
                else if (e.type == EventType.KeyDown)
                {
                    if (e.keyCode != KeyCode.LeftShift && e.keyCode != KeyCode.RightShift && e.keyCode != KeyCode.LeftControl && e.keyCode != KeyCode.RightControl)
                    {
                        Waila.mode = 0;
                        UnityEditor.Tools.hidden = false;
                    }
                }
            }
            catch
            {
            }
        }

        private static void OnClose()
        {
            Waila.Highlight(null);
        }

        private static void OnDrawModeExternal()
        {
            if (Waila.mode != 1) return;

            DrawSmartSelection(Event.current);
        }

        private static bool OnUpdateTooltipsExternal()
        {
            if (Prefs.wailaShowAllNamesUnderCursor && Event.current.modifiers == Prefs.wailaShowAllNamesUnderCursorModifiers)
            {
                UpdateAllTooltips();
                return true;
            }

            return false;
        }

        private static void ShowSmartSelection()
        {
            if (!(EditorWindow.focusedWindow is SceneView)) return;
            if (Waila.targets == null || Waila.targets.Count == 0) return;

            Event.current.Use();

            float width = Waila.labelStyle.CalcSize(new GUIContent("Select GameObject")).x + Waila.labelStyle.margin.horizontal + 10;

            int rightMargin = Waila.labelStyle.margin.right;
            Vector2 slashSize = Waila.labelStyle.CalcSize(new GUIContent("/"));

            float height = Waila.labelStyle.margin.top;

            int count = 0;

            try
            {
                for (int i = 0; i < Waila.targets.Count; i++)
                {
                    GameObject go = Waila.targets[i];
                    if (go == null) break;

                    float w = 0;
                    Transform t = go.transform;
                    Vector2 contentSize = Waila.labelStyle.CalcSize(new GUIContent(t.gameObject.name));
                    w += contentSize.x + rightMargin + Waila.labelStyle.margin.left;
                    height += contentSize.y + Waila.labelStyle.margin.bottom + Waila.labelStyle.padding.bottom;

                    while (t.parent != null)
                    {
                        t = t.parent;
                        w += slashSize.x + rightMargin;
                        contentSize = Waila.labelStyle.CalcSize(new GUIContent(t.gameObject.name));
                        w += contentSize.x + rightMargin;
                    }

                    w += 5;
                    if (w > width) width = w;

                    count++;
                }
            }
            catch (Exception e)
            {
                Log.Add(e);
            }

            if (count == 0) return;

            Vector2 size = new Vector2(width + 12, height + 32);
            Vector2 position = Event.current.mousePosition - new Vector2(size.x / 2, size.y * 1.5f);

            if (position.x < 5) position.x = 5;
            else if (position.x + size.x > EditorWindow.focusedWindow.position.width - 5) position.x = EditorWindow.focusedWindow.position.width - size.x - 5;

            if (position.y < 5) position.y = 5;
            else if (position.y + size.y > EditorWindow.focusedWindow.position.height - 5) position.y = EditorWindow.focusedWindow.position.height - size.y - 5;

            screenRect = new Rect(position, size);
            Waila.mode = 1;
            Waila.tooltip = null;
        }

        private static void UpdateAllTooltips()
        {
            Waila.tooltip = null;

            int count = 0;

            StaticStringBuilder.Clear();

            Waila.targets.Clear();

            while (count < 20)
            {
                GameObject go = HandleUtility.PickGameObject(Event.current.mousePosition, false, Waila.targets.ToArray());
                if (go == null) break;

                Waila.targets.Add(go);
                if (count > 0) StaticStringBuilder.Append("\n");
                int length = StaticStringBuilder.Length;
                Transform t = go.transform;
                StaticStringBuilder.Append(t.gameObject.name);
                while (t.parent != null)
                {
                    t = t.parent;
                    StaticStringBuilder.Insert(length, " / ");
                    StaticStringBuilder.Insert(length, t.gameObject.name);
                }

                count++;
            }

            if (Waila.targets.Count > 0) Waila.Highlight(Waila.targets[0]);
            else Waila.Highlight(null);

            if (count > 0) Waila.tooltip = new GUIContent(StaticStringBuilder.GetString(true));
        }
    }
}