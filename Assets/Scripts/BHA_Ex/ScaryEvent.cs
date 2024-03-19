using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryEvent : MonoBehaviour
{
    public List<ScaryEffect> scaryEffects;
    public List<ScaryEffect> startEffects;
    public enum scaryEventTier {Low, Medium, High};
    public ObjectInfoHolder currentEventTarget;
    private Dictionary <string, int> currentIndexForTargets;


    public void StartEvent()
    {
        //Effect 실행
        foreach(ScaryEffect effect in scaryEffects)
            effect.StartEffect();

    }

    // //제네릭 함수
    // public T GetCurrentTarget<T>(string key)
    // {
    //     //현재 대상의 인덱스 가져오기
    //     int currentIndex = currentIndexForTargets[key];

    //     //현재 대상의 리스트에서 해당 인덱스의 대상 반환
    //     return (T)(currentEventTarget.lightTargets[currentIndex]);
    // }
}