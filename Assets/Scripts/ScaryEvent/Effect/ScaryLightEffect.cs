using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public enum LightEffectType
{
    None,
    Flicker,
    ColorChange,
    IntensityChange
}

public class ScaryLightEffect : MonoBehaviour
{
    public LightEffectType effectType;
    public Light lightComponent; //이거 왜 필요한거야?? target에서 가져오지 않나??!
    public Color targetColor;
    public float targetIntensity;
    public float targetIndirectMultiplier;
    public LightShadows targetShadowType;
    public bool targetDrawHalo;
    public float duration;

    public ScaryEvent targetSource;

    //Light도 DoTween 이용해서 쉽게 구현할건지
    //아니면 코루틴 이용해서 구현할건지 정해야할 것 같습니다!!!
    //근데 코드가 깔끔한거는 DoTween인 것 같아요,,훗,,

    void Start()
    {
        targetSource = transform.parent.GetComponent<ScaryEvent>();
    }

    // IEnumerator FlickerLight()
    // {
    //     while (true)
    //     {
    //         lightComponent.enabled = !lightComponent.enabled;
    //         yield return new WaitForSeconds(flickerDuration);
    //     }
    // }

    //DoTween 이용 (엥 근데 그냥 IntensityChange랑 기능 똑같음ㅋㅋㅋㅋ 반복이 안 되넹..)
    public void Flicker()
    {
        var a = targetSource.GetCurrentTarget<Light>("light");
        DOTween.To(() => a.intensity, x => a.intensity = x, targetIntensity, duration)
        .SetEase(Ease.InOutQuad)
        .SetLoops(-1, LoopType.Yoyo)
        .SetDelay(0.5f);
    }

    public void ColorChange()
    {
        var a = targetSource.GetCurrentTarget<Light>("light");
        a.DOColor(targetColor, duration);
    }

    //DoTween 이용
    public void IntensityChange()
    {
        var a = targetSource.GetCurrentTarget<Light>("light");
        a.DOIntensity(targetIntensity, duration)
        .SetEase(Ease.InOutSine);
    }

    //코루틴
    // public void IntensityChange()
    // {
    //     ChangeIntensity();
    // }

    // IEnumerator ChangeIntensity()
    // {
    //     yield return new WaitForSeconds(0.3f);
    //     var a = targetSource.GetCurrentTarget<Light>("light");
    //     float initialIntensity = a.intensity;
    //     float elapsedTime = 0f;

    //     while (elapsedTime < duration)
    //     {
    //         float t = elapsedTime / duration;
    //         t = easeCurve.Evaluate(t);
    //         a.intensity = Mathf.Lerp(initialIntensity, targetIntensity, t);
    //         elapsedTime += Time.deltaTime;
    //         yield return null;
    //     }
    //     a.intensity = targetIntensity;
    // }
}
