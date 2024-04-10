using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEventHandler : MonoBehaviour
{
    public ScaryEvent[] scaryEvents;
    [SerializeField] private ObjectInfoHolder[] startTargets;
    public ObjectInfoHolder targrt;

    private void Start()
    {
        scaryEvents = FindObjectsOfType<ScaryEvent>();
        if (startTargets == null)
            Debug.Log("없음");
        else
        {
           // Match(startTargets[1], scaryEventWhen.OnAwake);
            Debug.Log("들어옴");
            for (int i = 0; i < startTargets.Length; i++)
            {
                //StartCoroutine(WaitAndPrint());
               // Match(startTargets[i], scaryEventWhen.OnAwake);

            }
            
        }
        
        
    }
    IEnumerator WaitAndPrint()
    {
        // 3초 동안 대기
        yield return new WaitForSeconds(1);

        // 대기 후 메시지 출력
        Debug.Log("액션이 완료되었습니다!");
    }

    public void Match(ObjectInfoHolder objectInfoHolder,scaryEventWhen eventWhen) 
    {
        for (int i = 0; i < scaryEvents.Length; i++)
        {
            if (objectInfoHolder.ObjectTier == scaryEvents[i].scaryEventTier && eventWhen  == scaryEvents[i].scaryEventWhen)
            {
                Debug.Log("�� ������");
                scaryEvents[i].currentEventTarget = objectInfoHolder;
                scaryEvents[i].ResetIndexForTargets();
                Debug.Log(objectInfoHolder.name);
                scaryEvents[i].StartEvent();
                //break;
                //scaryEvents.Add(scaryEvents[i]);
                //scaryEvents.RemoveAt(i);
                //scaryEvents.Add()
            }
        }

        
        

    }

    
}
