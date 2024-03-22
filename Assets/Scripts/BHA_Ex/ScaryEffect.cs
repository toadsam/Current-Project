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

   public void StartEffect()
    {
        // //delay 후에 Effect 시작
        // DOVirtual.DelayedCall(delay, PlayEffect);
    }

//     private void PlayEffect()
//     {
//         //Effect가 시작될 때 실행되는 이벤트 호출
//         onStart.Invoke();

//         //Effect 실행
//         transform.DOMove(Vector3.zero, duration).SetEase(ease).SetLoops(loop).OnPlay(() =>
//         {
//             onPlay.Invoke();
//         }).OnUpdate(() =>
//         {
//             onUpdate.Invoke();
//         }).OnComplete(() =>
//         {
//             onComplete.Invoke();
//         });
//     }
}