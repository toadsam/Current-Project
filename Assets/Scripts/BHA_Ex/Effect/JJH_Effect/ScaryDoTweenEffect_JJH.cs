using System;
using DG.Tweening;
using UnityEngine;

public enum DoTweenType
{
    None,
    Move,
    Rotate,
    Scale
}

public class ScaryDoTweenEffect_JJH : MonoBehaviour
{
    public DoTweenType doTweenType;
    public Vector3 targetPosition;
    public Vector3 targetRotation;
    public Vector3 targetScale;
    public float duration = 1f;

    public ScaryEvent targetSource;
    // void Start()
    // {
    //     switch (doTweenType)
    //     {
    //         case DoTweenType.Move:
    //             transform.DOMove(targetPosition, duration);
    //             break;
    //         case DoTweenType.Rotate:
    //             transform.DORotate(targetRotation, duration);
    //             break;
    //         case DoTweenType.Scale:
    //             transform.DOScale(targetScale, duration);
    //             break;
    //     }
    // }

    private void Start()
    {
        // Debug.Log(targetPosition);
        // Debug.Log(targetRotation);
        // Debug.Log(targetScale);
    }

    public void Scale()
    {
        var a = targetSource.GetCurrentTarget<Transform>("transform");
    }

    public void Rotation()
    {
        
        
    }

    public void Position()
    {
        
    }
}