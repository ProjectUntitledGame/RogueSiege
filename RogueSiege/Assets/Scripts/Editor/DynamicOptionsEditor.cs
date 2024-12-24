using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelController))]
public class DynamicOptionsEditor : Editor
{
    SerializedProperty aiCount;
    SerializedProperty aiTypeCounts;
    SerializedProperty container;

    private void OnEnable()
    {
        aiCount = serializedObject.FindProperty("enemiesInLevel");
        container = serializedObject.FindProperty("container");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(container);
        if(container.objectReferenceValue != null)
        {
            AIContainer tempAIContainer = (AIContainer)container.objectReferenceValue;
            EditorGUILayout.PropertyField(aiCount);
            if (aiCount.intValue > 0)
            {

                for (int i = 0; i < tempAIContainer.aiTypes.Length; i++)
                {
                    SerializedProperty enemyTypeCount = aiTypeCounts.GetArrayElementAtIndex(i);

                    // Display a label for each enemy type and an integer field to specify the count
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Number of " + tempAIContainer.aiTypes[i].name, GUILayout.MaxWidth(150));
                    enemyTypeCount.intValue = EditorGUILayout.IntField(enemyTypeCount.intValue);
                    EditorGUILayout.EndHorizontal();
                }
            }
            else
            {
                EditorGUILayout.HelpBox("There are no enemies in the level!", MessageType.Warning);
            }
        }
        else
        {
            EditorGUILayout.HelpBox("Assign the container to set enemy counts!", MessageType.Warning);
        }
        serializedObject.ApplyModifiedProperties();
    }
}
