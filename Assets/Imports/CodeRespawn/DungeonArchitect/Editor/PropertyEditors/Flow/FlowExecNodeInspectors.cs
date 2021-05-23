﻿using System.Collections.Generic;
using System.Linq;
using DungeonArchitect.Flow.Exec;
using UnityEditor;
using UnityEngine;

namespace DungeonArchitect.Editors.Flow
{
    public class FlowExecNodeHandlerInspectorBase : Editor
    {
        protected SerializedObject sobject;
        Dictionary<string, SerializedProperty> properties = new Dictionary<string, SerializedProperty>();

        public FlowInspectorMonoScriptProperty<T> CreateScriptProperty<T>(string className)
        {
            return new FlowInspectorMonoScriptProperty<T>(className);
        }

        public void DrawProperty(string name)
        {
            DrawProperty(name, false);
        }

        public void DrawProperties(params string[] names)
        {
            foreach (var name in names)
            {
                DrawProperty(name, false);
            }
        }

        public void DrawHeader(string title)
        {
            EditorGUILayout.Space();
            GUILayout.Label(title, InspectorStyles.HeaderStyle);
        }

        protected SerializedProperty GetProperty(string name)
        {
            if (properties.ContainsKey(name))
            {
                return properties[name];
            }

            if (!name.Contains("."))
            {
                var property = sobject.FindProperty(name);
                properties.Add(name, property);
                return property;
            }
            else
            {
                var tokens = name.Split(".".ToCharArray());
                var property = GetProperty(tokens[0]);
                for (int i = 1; i < tokens.Length; i++)
                {
                    property = property.FindPropertyRelative(tokens[i]);
                }
                properties[name] = property;
                return property;
            }
        }

        public void DrawProperty(string name, bool includeChildren)
        {
            var property = GetProperty(name);
            if (property != null)
            {
                EditorGUILayout.PropertyField(property, includeChildren);
            }
            else
            {
                Debug.LogError("Invalid property name: " + name);
            }
        }

        protected virtual void OnEnable()
        {
            sobject = new SerializedObject(target);
        }

        public virtual void HandleInspectorGUI()
        {
            var attribute = FlowExecNodeInfoAttribute.GetHandlerAttribute(target.GetType());
            var title = "Node Settings";
            if (attribute != null)
            {
                title = attribute.Title;
            }
            
            // Draw the header
            GUILayout.Box(title, InspectorStyles.TitleStyle);
            EditorGUILayout.Space();
            
        }

        protected virtual void DrawMiscProperties()
        {
            DrawProperty("description");
        }

        public override void OnInspectorGUI()
        {
            sobject.Update();

            HandleInspectorGUI();
            
            DrawHeader("Misc");
            {
                EditorGUI.indentLevel++;
                DrawMiscProperties();
                EditorGUI.indentLevel--;
            }

            InspectorNotify.Dispatch(sobject, target);
        }
    }
    
    public class FlowInspectorMonoScriptProperty<T>
    {
        public string ClassName { get; private set; }
        public MonoScript ScriptCache { get; set; }

        public FlowInspectorMonoScriptProperty(string propertyValue)
        {
            ClassName = propertyValue;
            UpdateScriptCache();
        }

        public void Draw(System.Action<string> ClassSetter)
        {
            var newScript = EditorGUILayout.ObjectField("Script", ScriptCache, typeof(MonoScript), false) as MonoScript;
            if (newScript != ScriptCache)
            {
                if (newScript == null)
                {
                    ClassName = null;
                }
                else
                {
                    if (!newScript.GetClass().GetInterfaces().Contains(typeof(T)))
                    {
                        // The script doesn't implement the interface
                        ClassName = null;
                    }
                    else
                    {
                        ClassName = newScript.GetClass().AssemblyQualifiedName;
                    }
                }
                UpdateScriptCache();
            }

            ClassSetter(ClassName);
        }

        public void Destroy()
        {
            if (ScriptCache != null)
            {
                ScriptableObject.DestroyImmediate(ScriptCache);
                ScriptCache = null;
            }
        }

        void UpdateScriptCache()
        {
            if (ClassName == null || ClassName.Length == 0)
            {
                ScriptCache = null;
                return;
            }

            var type = System.Type.GetType(ClassName);
            if (type == null)
            {
                ScriptCache = null;
                return;
            }

            var instance = ScriptableObject.CreateInstance(type);
            ScriptCache = MonoScript.FromScriptableObject(instance);
            Object.DestroyImmediate(instance);
        }
    }
}
