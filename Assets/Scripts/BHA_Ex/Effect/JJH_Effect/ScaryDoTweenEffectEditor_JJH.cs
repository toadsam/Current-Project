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
        // �Ӽ����� �ʱ�ȭ�մϴ�.
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

        // ���õ� DoTweenType�� ���� �Ӽ��� �����ݴϴ�.
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

        // Duration�� �׻� �����ݴϴ�.
        EditorGUILayout.PropertyField(durationProp);

        serializedObject.ApplyModifiedProperties();
    }
}