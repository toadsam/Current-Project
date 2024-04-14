using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScaryEvent_JJH))]
public class ScaryEventEditor_JJH : Editor
{
    private bool showOnStartEvents = false;
    private bool showOnPlayEvents = false;
    private bool showOnUpdateEvents = false;
    private bool showOnCompleteEvents = false;
    public override void OnInspectorGUI()
    {
        ScaryEvent_JJH script = (ScaryEvent_JJH)target;
        serializedObject.Update();

        // ScaryEventTier와 ScaryEventWhen을 Dropdown으로 표시
        script.scaryEventTier = (scaryEventTier)EditorGUILayout.EnumPopup("Scary Event Tier", script.scaryEventTier);
        script.scaryEventWhen = (scaryEventWhen)EditorGUILayout.EnumPopup("Scary Event When", script.scaryEventWhen);

        // 현재 Event Target에 대한 ObjectField를 표시
        EditorGUILayout.ObjectField("Current Event Target", script.currentEventTarget, typeof(ObjectInfoHolder), true);

        // 접히고 펼쳐지는 UnityEvent 섹션
        showOnStartEvents = EditorGUILayout.Foldout(showOnStartEvents, "On Start Events");
        if (showOnStartEvents)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onStart"), new GUIContent("On Start"));
        }

        showOnPlayEvents = EditorGUILayout.Foldout(showOnPlayEvents, "On Play Events");
        if (showOnPlayEvents)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onPlay"), new GUIContent("On Play"));
        }

        showOnUpdateEvents = EditorGUILayout.Foldout(showOnUpdateEvents, "On Update Events");
        if (showOnUpdateEvents)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onUpdate"), new GUIContent("On Update"));
        }

        showOnCompleteEvents = EditorGUILayout.Foldout(showOnCompleteEvents, "On Complete Events");
        if (showOnCompleteEvents)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onComplete"), new GUIContent("On Complete"));
        }

        serializedObject.ApplyModifiedProperties();
    }

    
    }
