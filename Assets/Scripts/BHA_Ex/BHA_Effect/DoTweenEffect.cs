using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DoTweenEffect : ScaryEffect
{
    
    
    public void RotatingLightBeamWithScaling()
    {
        var a = targetSource.GetCurrentTarget<Light>("light");

        DOTween.To(() => a.color, x => a.color = x, new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value), 1f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
        
        a.color = Color.red;
    }
    
    public void LightFlickerAndGameObjectFade()
    {
        var a = targetSource.GetCurrentTarget<Light>("light");
        a.color = Color.green;
        DOTween.To(() => a.intensity, x => a.intensity = x, 0, 0.1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(0.5f);
    }

    public void Rotating()
    {
        var a = targetSource.GetCurrentTarget<Transform>("transform");
        a.DORotate(new Vector3(0, 0, 360), 5f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);  
    }

    public void Scaling()
    {
        var a = targetSource.GetCurrentTarget<Transform>("transform");
        a.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 5f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);
    }

    public void Shaking()
    {
        // DoTween을 이용하여 오브젝트를 흔들이는 애니메이션을 생성합니다.
        transform.DOShakePosition(2f, 1f);
    }

    public void Spin()
    {
        DOTween.Sequence()
        .Append(transform.DOLocalMoveY(0, .5f).From(.5f, true, true).SetEase(Ease.InOutQuad))
        .Join(transform.DOLocalRotate(new Vector3(0, 720, 0), 2.8f, RotateMode.FastBeyond360).SetEase(Ease.OutQuart).SetDelay(.2f))
        .Join(objectPivot.DOLocalRotate(new Vector3(0, 0, 10), .8f).SetEase(Ease.OutQuad))
        .Insert(1, objectPivot.DOLocalRotate(new Vector3(0, 0, 0), 1.5f).SetEase(Ease.OutQuad));
    }

    

}
