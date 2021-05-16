/*           INFINITY CODE          */
/*     https://infinity-code.com    */

using InfinityCode.uContext;
using InfinityCode.uContext.Tools;
using UnityEditor;
using UnityEngine;

namespace InfinityCode.uContextPro.Tools
{
    [InitializeOnLoad]
    public static class HighJumpToPoint
    {
#if UNITY_EDITOR_OSX
        private const EventModifiers MODIFIERS = EventModifiers.Command | EventModifiers.Shift;
#else
        private const EventModifiers MODIFIERS = EventModifiers.Control | EventModifiers.Shift;
#endif

        static HighJumpToPoint()
        {
            SceneViewManager.AddListener(OnSceneGUI);
        }

        private static void OnSceneGUI(SceneView view)
        {
            if (!Prefs.highJumpToPoint || view.orthographic) return;

            Event e = Event.current;
            if (e.type != EventType.MouseUp || e.button != 2 || e.modifiers != (MODIFIERS)) return;

            if (!JumpToPoint.GetTargetPoint(e, out Vector3 targetPosition)) return;

            view.LookAt(targetPosition + new Vector3(0, 20, 0), view.rotation, 20);

            UnityEditor.Tools.viewTool = ViewTool.None;
            GUIUtility.hotControl = 0;

            e.Use();
        }
    }
}