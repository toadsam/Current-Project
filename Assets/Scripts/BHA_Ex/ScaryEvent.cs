using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaryEvent : MonoBehaviour
{
    public List<ScaryEffect> scaryEffects;
   // public List<ScaryEffect> startEffects;
    public enum scaryEventTier {Low, Medium, High};
    public ObjectInfoHolder currentEventTarget;
    private Dictionary <string, int> currentIndexForTargets = new Dictionary<string, int>();
    

    private void Start()
    {
        currentIndexForTargets.Add("light", 0);
        currentIndexForTargets.Add("audio", 0);
        currentIndexForTargets.Add("transform", 0);
        StartEvent();
    }
    
    


    public void StartEvent()
    {
        scaryEffects[0].StartEffect();
      //  scaryEffects[0].RotatingLightBeamWithScaling();
        
    }

    // public T GetCurrentTarget<T>(string key)
    // {
    //     int currentIndex = currentIndexForTargets[key];
    //     currentIndexForTargets[key] += 1;
    //
    //     return (T)(object)currentEventTarget.lightTargets[currentIndexForTargets[key]];
    // }

    // //제네릭 함수
    // public T GetCurrentTarget<T>(string key)
    // {
    //     //현재 대상의 인덱스 가져오기
    //     int currentIndex = currentIndexForTargets[key];

    //     //key

    //     //현재 대상의 리스트에서 해당 인덱스의 대상 반환
    //     return (T)(currentEventTarget.lightTargets[currentIndex]);
    // }
    public T GetCurrentTarget<T>(string targetType) where T : UnityEngine.Object {
        int index = currentIndexForTargets.ContainsKey(targetType) ? currentIndexForTargets[targetType] : 0;
        var targetList = currentEventTarget.GetType().GetField(targetType + "Targets").GetValue(currentEventTarget) as List<T>;
        currentIndexForTargets[targetType] +=1;
        return targetList != null && index < targetList.Count ? targetList[index] : null;
    }
}