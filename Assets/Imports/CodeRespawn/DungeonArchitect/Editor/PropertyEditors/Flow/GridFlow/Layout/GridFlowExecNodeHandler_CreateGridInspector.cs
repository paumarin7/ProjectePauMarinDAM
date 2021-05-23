﻿using DungeonArchitect.Flow.Impl.GridFlow.Tasks;
using UnityEditor;

namespace DungeonArchitect.Editors.Flow.GridFlow
{
    [CustomEditor(typeof(GridFlowLayoutTaskCreateGrid), false)]
    public class GridFlowExecNodeHandler_CreateGridInspector : FlowExecNodeHandlerInspectorBase
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