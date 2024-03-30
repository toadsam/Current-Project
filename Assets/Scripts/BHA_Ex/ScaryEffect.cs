using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class ScaryEffect : MonoBehaviour
{
   public ScaryEvent targetSource;
   public float duration;
   public float delay;
   public Ease ease;
   public int loop;
   public UnityEvent onStart;
   public UnityEvent onPlay;
   public UnityEvent onUpdate;
   public UnityEvent onComplete;

   private void Start()
   {
    // targetSource = this.GetComponent<ScaryEvent>();
   }

   public void StartEffect()
   {
       onStart.Invoke();
       Debug.Log("배현아 정재훈 파이팅!");
       //onStart.Invoke();
       onComplete.Invoke();
   }
   public void RotatingLightBeamWithScaling()
   {
       Debug.Log("배현아 정재훈 힘내자!");
   }

     private void PlayEffect()
     {
         //Effect가 시작될 때 실행되는 이벤트 호출
         onStart.Invoke();
         onPlay.Invoke();
         onUpdate.Invoke();
         onComplete.Invoke();

        
     }
}