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

public class ScaryLightEffect_JJH : MonoBehaviour
{
    public Light lightComponent;
    public LightEffectType effectType;
    public Color targetColor;
    public float targetIntensity;
    public float flickerDuration;
    public float duration;

    void Start()
    {
       // ApplyEffect();
    }

    // void ApplyEffect()
    // {
    //     switch (effectType)
    //     {
    //         case LightEffectType.Flicker:
    //             StartCoroutine(FlickerLight());
    //             break;
    //         case LightEffectType.ColorChange:
    //             lightComponent.DOColor(targetColor, duration);
    //             break;
    //         case LightEffectType.IntensityChange:
    //             lightComponent.DOIntensity(targetIntensity, duration);
    //             break;
    //     }
    // }

    IEnumerator FlickerLight()
    {
        while (true)
        {
            lightComponent.enabled = !lightComponent.enabled;
            yield return new WaitForSeconds(flickerDuration);
        }
    }

    public void Flicker()
    {
        Debug.Log("깜빡깜빡");
    }

    public void ColorChange()
    {
        Debug.Log("색 바꾸기");
    }

    public void IntensityChange()
    {
        Debug.Log("색 강도 바꾸기");
        
        Debug.Log("배현아배현아배혀나배현나");
    }
    
}
