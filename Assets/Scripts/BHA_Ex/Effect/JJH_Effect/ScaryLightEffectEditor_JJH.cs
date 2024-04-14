using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScaryLightEffect_JJH))]
public class ScaryLightEffectEditor_JJH : Editor
{
    SerializedProperty lightComponentProp;
    SerializedProperty effectTypeProp;
    SerializedProperty targetColorProp;
    SerializedProperty targetIntensityProp;
    SerializedProperty flickerDurationProp;
    SerializedProperty durationProp;

    void OnEnable()
    {
        // 속성들을 SerializedProperty로 찾아 초기화
        lightComponentProp = serializedObject.FindProperty("lightComponent");
        effectTypeProp = serializedObject.FindProperty("effectType");
        targetColorProp = serializedObject.FindProperty("targetColor");
        targetIntensityProp = serializedObject.FindProperty("targetIntensity");
        flickerDurationProp = serializedObject.FindProperty("flickerDuration");
        durationProp = serializedObject.FindProperty("duration");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(effectTypeProp);

        LightEffectType effectType = (LightEffectType)effectTypeProp.enumValueIndex;

        // 선택된 EffectType에 따라 관련 속성만 표시
        switch (effectType)
        {
            case LightEffectType.Flicker:
                EditorGUILayout.PropertyField(lightComponentProp);
                EditorGUILayout.PropertyField(flickerDurationProp);
                break;
            case LightEffectType.ColorChange:
                EditorGUILayout.PropertyField(lightComponentProp);
                EditorGUILayout.PropertyField(targetColorProp);
                EditorGUILayout.PropertyField(durationProp);
                break;
            case LightEffectType.IntensityChange:
                EditorGUILayout.PropertyField(lightComponentProp);
                EditorGUILayout.PropertyField(targetIntensityProp);
                EditorGUILayout.PropertyField(durationProp);
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}