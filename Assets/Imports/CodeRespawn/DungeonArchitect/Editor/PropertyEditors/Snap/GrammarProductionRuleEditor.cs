﻿using DungeonArchitect.Grammar;
using UnityEditor;

namespace DungeonArchitect.Editors.SnapFlow
{
    [CustomEditor(typeof(GrammarProductionRule))]
    public class GrammarProductionRuleEditor : Editor
    {
        SerializedObject sobject;
        SerializedProperty ruleName;

        private void OnEnable()
        {
            sobject = new SerializedObject(target);
            ruleName = sobject.FindProperty("ruleName");
        }

        public override void OnInspectorGUI()
        {
            sobject.Update();
            
            EditorGUILayout.PropertyField(ruleName);
            
            InspectorNotify.Dispatch(sobject, target);
        }
    }
}