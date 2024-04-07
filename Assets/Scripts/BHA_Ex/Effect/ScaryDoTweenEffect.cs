using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScaryDoTweenEffect : ScaryEffect
{
    
    
    public void RotatingLightBeamWithScaling()
    {
        var a = targetSource.GetCurrentTarget<Light>("light");
        Debug.Log("배현아");

        // Light 색상 변화 효과
        DOTween.To(() => a.color, x => a.color = x, new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value), 1f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
        
        a.color = Color.red; // 목표 색상을 빨간색으로 설정
    }
    
    //GameObject가 페이드 인-아웃 하는 동안 관련된 Light가 깜박이는 효과를 생성합니다. 이 메서드는 음산한 분위기를 연출하거나 주의를 끌고자 할 때 유용합니다.
    public void LightFlickerAndGameObjectFade()
    {
        Debug.Log("정재훈");
        var a = targetSource.GetCurrentTarget<Light>("light");
        // GameObject 페이드 인-아웃 효과
        a.color = Color.green;
        // Light 깜박임 효과
        DOTween.To(() => a.intensity, x => a.intensity = x, 0, 0.1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(0.5f); // 깜박임 시작 전 약간의 지연을 추가
    }

    public void Rotating()
    {
        var a = targetSource.GetCurrentTarget<Transform>("transform");
        // GameObject 회전 효과
        a.DORotate(new Vector3(0, 0, 360), 5f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);

       
    }

    public void Scaling()
    {
        var a = targetSource.GetCurrentTarget<Transform>("transform");
        // GameObject 크기 증가 효과
        a.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 5f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
