using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEventHandler : MonoBehaviour
{
    public ScaryEvent scaryEvent;

    private void Start()
    {
        //ó�� �̺�Ʈ ����
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            scaryEvent.StartEvent();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            //scaryEvent.StopEvent();
        }
    }
}
