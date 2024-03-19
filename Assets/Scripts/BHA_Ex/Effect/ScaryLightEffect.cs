using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaryLightEffect : ScaryEffect
{
    // 대상이 되는 라이트
    public Light targetLight;

    // 대상 설정 값
    public Color targetColor;
    public float targetIntensity;
    public float targetIndirectMultiplier;
    public LightShadows targetShadowType;
    public bool targetDrawHalo;


    // ScaryEffect의 StartEffect 메서드를 오버라이드
    public override void StartEffect()
    {
        // delay 후에 Effect 시작
        DOVirtual.DelayedCall(delay, PlayEffect);
    }

    // Effect 실행 메서드
    private void PlayEffect()
    {
        onStart.Invoke();
        
        DOTween.Sequence()
            .Append(targetLight.DOColor(targetColor, duration).SetEase(ease))
            .Join(targetLight.DOIntensity(targetIntensity, duration).SetEase(ease))
            .Join(targetLight.DOShadowStrength(targetIndirectMultiplier, duration).SetEase(ease))
            // .Join(targetLight.DOShadowType(targetShadowType, duration).SetEase(ease))
            // .Join(targetLight.DOShadowBias(targetDrawHalo ? 1f : 0f, duration).SetEase(ease))
            .OnUpdate(() =>
            {
                onUpdate.Invoke();
            })
            .OnComplete(() =>
            {
                onComplete.Invoke();
            });
    }
}
