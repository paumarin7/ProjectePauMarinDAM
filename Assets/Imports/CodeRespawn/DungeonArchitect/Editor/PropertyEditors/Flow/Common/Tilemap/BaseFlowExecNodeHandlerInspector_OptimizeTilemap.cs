﻿using UnityEditor;

namespace DungeonArchitect.Editors.Flow.Common
{
    public class BaseFlowExecNodeHandlerInspector_OptimizeTilemap : FlowExecNodeHandlerInspectorBase
    {
        public override void HandleInspectorGUI()
        {
            base.HandleInspectorGUI();

            DrawHeader("Optimize");
            {
                EditorGUI.indentLevel++;
                DrawProperties("discardDistanceFromLayout");
                EditorGUI.indentLevel--;
            }
        }
    }
}