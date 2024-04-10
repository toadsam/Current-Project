using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEventHandler : MonoBehaviour
{
    public ScaryEvent[] scaryEvents;

    private void Start()
    {
        scaryEvents = FindObjectsOfType<ScaryEvent>();
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
