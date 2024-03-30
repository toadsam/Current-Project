using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEventHandler : MonoBehaviour
{
    public ScaryEvent scaryEvent;

    private void Start()
    {
        //처음 이벤트 시작
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
