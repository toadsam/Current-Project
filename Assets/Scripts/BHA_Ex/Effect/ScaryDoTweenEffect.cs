using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScaryDoTweenEffect : ScaryEffect
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void RotatingLightBeamWithScaling()
    {
        var a = targetSource.GetCurrentTarget<Light>("light");

        // Light ���� ��ȭ ȿ��
        DOTween.To(() => a.color, x => a.color = x, new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value), 1f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
        
        a.color = Color.red; // ��ǥ ������ ���������� ����
    }
    
    //GameObject�� ���̵� ��-�ƿ� �ϴ� ���� ���õ� Light�� �����̴� ȿ���� �����մϴ�. �� �޼���� ������ �����⸦ �����ϰų� ���Ǹ� ������ �� �� �����մϴ�.
    public void LightFlickerAndGameObjectFade()
    {
        var a = targetSource.GetCurrentTarget<Light>("light");
        // GameObject ���̵� ��-�ƿ� ȿ��
        a.color = Color.green;
        // Light ������ ȿ��
        DOTween.To(() => a.intensity, x => a.intensity = x, 0, 0.1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(0.5f); // ������ ���� �� �ణ�� ������ �߰�
         
        //a.color = Color.blue;
    }
}
