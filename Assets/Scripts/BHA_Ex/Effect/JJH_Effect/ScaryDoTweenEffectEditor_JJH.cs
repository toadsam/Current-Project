using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScaryDoTweenEffect_JJH))]
public class ScaryDoTweenEffectEditor_JJH : Editor
{
    SerializedProperty doTweenTypeProp;
    SerializedProperty targetPositionProp;
    SerializedProperty targetRotationProp;
    SerializedProperty targetScaleProp;
    SerializedProperty durationProp;

    void OnEnable()
    {
        // 속성들을 초기화합니다.
        doTweenTypeProp = serializedObject.FindProperty("doTweenType");
        targetPositionProp = serializedObject.FindProperty("targetPosition");
        targetRotationProp = serializedObject.FindProperty("targetRotation");
        targetScaleProp = serializedObject.FindProperty("targetScale");
        durationProp = serializedObject.FindProperty("duration");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(doTweenTypeProp);

        DoTweenType currentType = (DoTweenType)doTweenTypeProp.enumValueIndex;

        // 선택된 DoTweenType에 따라 속성을 보여줍니다.
        switch (currentType)
        {
            case DoTweenType.Move:
                EditorGUILayout.PropertyField(targetPositionProp);
                break;
            case DoTweenType.Rotate:
                EditorGUILayout.PropertyField(targetRotationProp);
                break;
            case DoTweenType.Scale:
                EditorGUILayout.PropertyField(targetScaleProp);
                break;
        }

        // Duration은 항상 보여줍니다.
        EditorGUILayout.PropertyField(durationProp);

        serializedObject.ApplyModifiedProperties();
    }
}