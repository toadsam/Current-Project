using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEventHandler : MonoBehaviour
{
    public List<ScaryEvent> scaryEvents;

    private void Start()
    {
        
        scaryEvents = new List<ScaryEvent>();
        for (int i = 0; i < transform.childCount; i++)
        {
            scaryEvents.Add(transform.GetChild(i).GetComponent<ScaryEvent>());
        }
        //ó�� �̺�Ʈ ����
    } 

    public void Match(ObjectInfoHolder objectInfoHolder,scaryEventWhen eventWhen) 
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (objectInfoHolder.ObjectTier == scaryEvents[i].scaryEventTier && eventWhen  == scaryEvents[i].scaryEventWhen)
            {
                Debug.Log("�� ������");
                scaryEvents[i].currentEventTarget = objectInfoHolder;
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
