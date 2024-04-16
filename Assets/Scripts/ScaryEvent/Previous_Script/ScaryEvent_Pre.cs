using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaryEvent_Pre : MonoBehaviour
{
    public List<ScaryEffect> scaryEffects;
    public scaryEventTier scaryEventTier;
    public scaryEventWhen scaryEventWhen;
    
    public ObjectInfoHolder currentEventTarget;
    private Dictionary <string, int> currentIndexForTargets = new Dictionary<string, int>();

    private void Awake()
    {
        currentIndexForTargets.Add("light", 0);
        currentIndexForTargets.Add("audio", 0);
        currentIndexForTargets.Add("transform", 0);
    }
   

    public void StartEvent()
    {
        for (int i = 0; i < scaryEffects.Count; i++)
            scaryEffects[i].StartEffect();
    }
    

    public T GetCurrentTarget<T>(string targetType) where T : UnityEngine.Object {
        int index = currentIndexForTargets.ContainsKey(targetType) ? currentIndexForTargets[targetType] : 0;
        var targetList = currentEventTarget.GetType().GetField(targetType + "Targets").GetValue(currentEventTarget) as List<T>;
        currentIndexForTargets[targetType] +=1;
        return targetList != null && index < targetList.Count ? targetList[index] : null;
    }

    public void ResetIndexForTargets()
    {
        var keys = new List<string>(currentIndexForTargets.Keys);
        foreach (var key in keys)
            currentIndexForTargets[key] = 0;
    }
}