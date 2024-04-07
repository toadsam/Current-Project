using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScaryDoTweenEffect : ScaryEffect
{
    
    
    public void RotatingLightBeamWithScaling()
    {
        var a = targetSource.GetCurrentTarget<Light>("light");
        Debug.Log("������");

        // Light ���� ��ȭ ȿ��
        DOTween.To(() => a.color, x => a.color = x, new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value), 1f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
        
        a.color = Color.red; // ��ǥ ������ ���������� ����
    }
    
    //GameObject�� ���̵� ��-�ƿ� �ϴ� ���� ���õ� Light�� �����̴� ȿ���� �����մϴ�. �� �޼���� ������ �����⸦ �����ϰų� ���Ǹ� ������ �� �� �����մϴ�.
    public void LightFlickerAndGameObjectFade()
    {
        Debug.Log("������");
        var a = targetSource.GetCurrentTarget<Light>("light");
        // GameObject ���̵� ��-�ƿ� ȿ��
        a.color = Color.green;
        // Light ������ ȿ��
        DOTween.To(() => a.intensity, x => a.intensity = x, 0, 0.1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(0.5f); // ������ ���� �� �ణ�� ������ �߰�
    }

    public void Rotating()
    {
        var a = targetSource.GetCurrentTarget<Transform>("transform");
        // GameObject ȸ�� ȿ��
        a.DORotate(new Vector3(0, 0, 360), 5f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);

       
    }

    public void Scaling()
    {
        var a = targetSource.GetCurrentTarget<Transform>("transform");
        // GameObject ũ�� ���� ȿ��
        a.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 5f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
