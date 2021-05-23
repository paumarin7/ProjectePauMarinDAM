﻿using DungeonArchitect.Flow.Impl.SnapGridFlow.Tasks;
using UnityEditor;

namespace DungeonArchitect.Editors.Flow.SnapGridFlow
{
    [CustomEditor(typeof(SGFLayoutTaskCreateGrid), false)]
    public class SnapGridFlowExecNodeHandler_CreateGridInspector : FlowExecNodeHandlerInspectorBase
    {
        public override void HandleInspectorGUI()
        {
            base.HandleInspectorGUI();

            DrawHeader("Grid Info");
            {
                EditorGUI.indentLevel++;
                DrawProperties("resolution");
                EditorGUI.indentLevel--;
            }
        }
    }
}