using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenManager : MonoBehaviour
{
    private static DOTweenManager instance;

    public GameObject testObject;
    public GameObject testObject1;
    public GameObject testObject2;
    public GameObject testObject3;
    public GameObject testObject4;
    public GameObject testObject5;
    public GameObject testObject6;
    public GameObject testObject7;
    
    public Light testRight1;
    public Light testRight2;
    public Light testRight3;
    public Light testRight4;
    public Light testRight5;
    public Light testRight6;
    public Light testRight7;
    public static DOTweenManager Instance
    {
        get
        {
            if (instance == null)
            {
                // DOTweenManager �ν��Ͻ��� ������ ���� �����մϴ�.
                GameObject obj = new GameObject("DOTweenManager");
                instance = obj.AddComponent<DOTweenManager>();
                DontDestroyOnLoad(obj); // �� ��ȯ�ÿ��� �ı����� �ʵ��� �����մϴ�.
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // �� ��ȯ�ÿ��� �ı����� �ʵ��� �����մϴ�.
        }
        else if (instance != this)
        {
            Destroy(gameObject); // �ߺ� �ν��Ͻ��� �ı��մϴ�.
        }
    }

    private void Start()
    {
        Pulse(testObject);
        LightIntensityPulseWithScale(testObject1, testRight1);
        LightColorChangeOnMove(testObject2, testRight2,(Vector3.back), 2f );
        LightFlickerEffectOnRotation(testObject3, testRight3, (Vector3.back), 2f);
        ColorfulPulseWithLightIntensityAndScale(testObject4, testRight4);
        RotatingLightBeamWithScaling(testObject5, testRight5);
        LightFlickerAndGameObjectFade(testObject6, testRight6);
        ComplexAnimationWithRandomMovement(testObject7, testRight7);


    }

    // ����: GameObject�� x������ �̵���Ű�� �޼���
    public void MoveX(GameObject target, float endValue, float duration)
    {
        target.transform.DOMoveX(endValue, duration);
    }

    // �ٸ� DOTween �ִϸ��̼� �޼��带 ���⿡ �߰�...
    public void MoveY(GameObject target, float endValue, float duration, bool snapping = false)
    {
        target.transform.DOMoveY(endValue, duration).SetEase(Ease.InOutQuad).SetOptions(snapping);
    }
    
    //ȸ�� �ϴ� �ڵ�
    public void Rotate(GameObject target, Vector3 byAngles, float duration)
    {
        target.transform.DORotate(byAngles, duration, RotateMode.FastBeyond360).SetEase(Ease.InOutQuad);
    }
    
    //ũ�⸦ �����ϴ� �ڵ�
    public void Scale(GameObject target, Vector3 endValue, float duration)
    {
        target.transform.DOScale(endValue, duration).SetEase(Ease.InOutQuad);
    }
    
    //fade in  out�ϴ� �ڵ�
    public void Fade(CanvasGroup target, float endValue, float duration)
    {
        target.DOFade(endValue, duration).SetEase(Ease.InOutQuad);
    }
    
    //���� �ٲٴ� �ڵ�
    public void ColorChange(SpriteRenderer target, Color endValue, float duration)
    {
        target.DOColor(endValue, duration).SetEase(Ease.InOutQuad);
    }
    
    //�پ��� ������ �ڵ�
    public void SequenceExample(GameObject target)
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(target.transform.DOMoveX(5f, 1f)); // 1�� ���� x������ 5��ŭ �̵�
        mySequence.Append(target.transform.DORotate(new Vector3(0, 180, 0), 1f)); // �� �� 1�� ���� 180�� ȸ��
        mySequence.Append(target.transform.DOScale(new Vector3(2, 2, 2), 1f)); // ���������� 1�� ���� ũ�⸦ 2��� ����
    }
    
    //��ü�� ���ǵ� ��η� �̵���Ű��
    public void MoveAlongPath(GameObject target, Vector3[] pathPoints, float duration, PathType pathType = PathType.CatmullRom, PathMode pathMode = PathMode.Full3D)
    {
        // pathPoints�� �̵��� ����� ������ ��Ÿ���ϴ�.
        // PathType.CatmullRom�� ��ΰ� �ε巴�� ����ǵ��� �մϴ�.
        // PathMode.Full3D�� ��ü�� ��θ� ���� 3D �������� ȸ���ϵ��� �մϴ�.
        target.transform.DOPath(pathPoints, duration, pathType, pathMode)
            .SetEase(Ease.InOutQuad) // �ε巯�� ���۰� ���� ���� Easing
            .SetOptions(false) // ����� ���⿡ ���缭 �ڵ����� ȸ������ �ʵ��� ����
            .SetLookAt(0.01f); // �ణ ���� �ٶ󺸵��� �����Ͽ� �� �ڿ������� �̵� ȿ���� �ݴϴ�.
    }
    //��ü�� ��� ��â�ߴٰ� ���ƿ��� ȿ��

    public void PunchScale(GameObject target, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1)
    {
        // punch�� �󸶳� �ָ� ��â������ ��Ÿ���� �����Դϴ�.
        // vibrato�� ��ġ ���� �����ϴ� Ƚ���� ��Ÿ���ϴ�.
        // elasticity�� ��ġ�� �ǵ��ƿ��� ������ ��Ÿ���ϴ�. 1�� �������� ���� ũ��� ������ �ǵ��ƿɴϴ�.
        target.transform.DOPunchScale(punch, duration, vibrato, elasticity)
            .SetEase(Ease.OutElastic); // Elastic ȿ���� �������Ͽ� �ڿ������� ������ ����
    }
    
    //GameObject�� ������ 0���� 1�� �����ϰ� ���ÿ� ���� ũ�⿡�� ���� ũ��� Ȯ���ϴ� �ִϸ��̼��Դϴ�.
    public void FadeInAndScaleUp(GameObject target)
    {
        // ������ 0���� �����մϴ�.
        CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();
        if (canvasGroup == null) canvasGroup = target.AddComponent<CanvasGroup>();
        canvasGroup.alpha = 0;

        // ũ�⸦ ���Դϴ�.
        target.transform.localScale = Vector3.zero;

        // ������ 1�� �����ϰ�, ũ�⸦ ������� �����ϴ�.
        canvasGroup.DOFade(1, 1f); // 1�� ���� ���̵� ��
        target.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBack); // 1�� ���� Ȯ��, ź�� ȿ��
    }
    
    //GameObject�� �ٿ�ϸ鼭 ȸ���ϴ� �ִϸ��̼��Դϴ�.
    public void BounceAndRotate(GameObject target)
    {
        // �ٿ ȿ��
        float jumpHeight = 2f; // ���� ����
        target.transform.DOJump(target.transform.position, jumpHeight, 1, 1f)
            .SetEase(Ease.OutQuad); // �ٿ ȿ��

        // ȸ�� ȿ��
        target.transform.DORotate(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear); // 1�� ���� 360�� ȸ��
    }
    //GameObject�� ������ �����ϰ� ���� �� ������� �ϴ� �ִϸ��̼��Դϴ�.
    public void FadeOutAndDisappear(GameObject target)
    {
        CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();
        if (canvasGroup == null) canvasGroup = target.AddComponent<CanvasGroup>();

        // ������ ������ 0���� �����մϴ�.
        canvasGroup.DOFade(0, 1f) // 1�� ���� ���̵� �ƿ�
            .OnComplete(() => GameObject.Destroy(target)); // �ִϸ��̼��� �Ϸ�Ǹ� GameObject�� ����
    }
    
    //GameObject�� �ݺ������� Ȯ�� �� ��ҵǴ� �޽� ȿ���� �����մϴ�.
    public void Pulse(GameObject target)
    {
        // Ȯ�� ��Ҹ� �ݺ��մϴ�.
        target.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f) // 0.5�� ���� Ȯ��
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo); // ���� �ݺ�, Ȯ�� �� ���
    }
    
    //GameObject�� Ȯ�� �� ��ҵǴ� ���� ���õ� Light�� ������ �����ϰų� �����ϴ� �޽� ȿ���� �����մϴ�.
    public void LightIntensityPulseWithScale(GameObject target, Light lightSource)
    {
        // GameObject Ȯ�� ��� ȿ��
        target.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f) // 0.5�� ���� Ȯ��
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo); // ���� �ݺ�, Ȯ�� �� ���

        // Light ���� �޽� ȿ��
        float originalIntensity = lightSource.intensity;
        DOTween.To(() => lightSource.intensity, x => lightSource.intensity = x, originalIntensity * 1.5f, 0.5f) // ���� ����
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo); // ���� �ݺ�, ���� ���� �� ����
    }
    
    //GameObject�� �̵��ϴ� ���� ���õ� Light�� ������ �����ϴ� ȿ���� �����մϴ�. �� �޼���� GameObject�� Ư�� ��θ� ���� �̵��� �� ������ ������ �������� �����ϰ��� �� �� �����մϴ�.
    public void LightColorChangeOnMove(GameObject target, Light lightSource, Vector3 endPosition, float duration)
    {
        // GameObject �̵� ȿ��
        target.transform.DOMove(endPosition, duration)
            .SetEase(Ease.InOutQuad);

        // Light ���� ���� ȿ��
        Color originalColor = lightSource.color;
        Color targetColor = Color.red; // ��ǥ ������ ���������� ����
        DOTween.To(() => lightSource.color, x => lightSource.color = x, targetColor, duration)
            .SetEase(Ease.InOutQuad);
    }
    
    //GameObject�� ȸ���ϴ� ���� ���õ� Light�� �����̴� ȿ���� �����մϴ�. �� �޼���� ���� ���ӿ����� ������ �������̳� ��� ��ȣ � ���� �� �ֽ��ϴ�.
    public void LightFlickerEffectOnRotation(GameObject target, Light lightSource, Vector3 rotationAngles, float duration)
    {
        // GameObject ȸ�� ȿ��
        target.transform.DORotate(rotationAngles, duration)
            .SetEase(Ease.InOutQuad);

        // Light ������ ȿ��
        float flickerDuration = 0.1f; // ������ ���� �ð�
        int flickerCount = Mathf.FloorToInt(duration / flickerDuration); // ��ü ���� �ð� ���� ������ Ƚ��
        DOTween.To(() => lightSource.intensity, x => lightSource.intensity = x, 0, flickerDuration) // ������ 0���� ����
            .SetLoops(flickerCount, LoopType.Yoyo) // ������ ������� �����ϴ� ���� ������ ������ Ƚ�� ����
            .SetEase(Ease.InOutQuad);
    }
    
    
    //GameObject�� ũ�Ⱑ �޽� ȿ���� ���ϸ鼭 ���ÿ� Light�� ������ ������ ���������� ���ϴ� ȿ���Դϴ�.
    public void ColorfulPulseWithLightIntensityAndScale(GameObject target, Light lightSource)
    {
        // GameObject ũ�� �޽� ȿ��
        target.transform.DOScale(new Vector3(1.05f, 1.05f, 1.05f), 1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);

        // Light ���� �޽� ȿ��
        DOTween.To(() => lightSource.intensity, x => lightSource.intensity = x, lightSource.intensity * 1.2f, 1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);

        // Light ���� ��ȭ ȿ��
        DOTween.To(() => lightSource.color, x => lightSource.color = x, new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value), 2f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
    }
    
    //GameObject�� ȸ���ϸ鼭 ũ�Ⱑ ���� �����ϰ�, ���õ� Light�� ��ó�� ������ �ٲٸ鼭 ���������� ������ ���ϴ� ȿ���Դϴ�.
    public void RotatingLightBeamWithScaling(GameObject target, Light lightSource)
    {
        // GameObject ȸ�� ȿ��
        target.transform.DORotate(new Vector3(0, 0, 360), 5f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);

        // GameObject ũ�� ���� ȿ��
        target.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 5f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);

        // Light ���� ��ȭ ȿ��
        DOTween.To(() => lightSource.color, x => lightSource.color = x, new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value), 3f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
    }
    
    //GameObject�� ���̵� ��-�ƿ� �ϴ� ���� ���õ� Light�� �����̴� ȿ���� �����մϴ�. �� �޼���� ������ �����⸦ �����ϰų� ���Ǹ� ������ �� �� �����մϴ�.
    public void LightFlickerAndGameObjectFade(GameObject target, Light lightSource)
    {
        // GameObject ���̵� ��-�ƿ� ȿ��
        CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();
        if (canvasGroup == null) canvasGroup = target.AddComponent<CanvasGroup>();
        canvasGroup.DOFade(0, 1f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);

        // Light ������ ȿ��
        DOTween.To(() => lightSource.intensity, x => lightSource.intensity = x, 0, 0.1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(0.5f); // ������ ���� �� �ణ�� ������ �߰�
    }
    
    public void ComplexAnimationWithRandomMovement(GameObject target, Light lightSource)
    {
        // GameObject�� ������ ��ġ���� ���� �̵�
        DOTween.Sequence()
            .Append(target.transform.DOMove(new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), target.transform.position.z), 0.5f).SetEase(Ease.InOutQuad))
            .AppendInterval(0.5f) // ��� ���
            .SetLoops(-1, LoopType.Restart); // �ݺ�

        // GameObject ũ�� ��ȭ�� ���̵� ��-�ƿ� ȿ��
        target.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo); // ũ�� ��ȭ�� �ݺ�

        CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();
        if (canvasGroup == null) canvasGroup = target.AddComponent<CanvasGroup>();
        canvasGroup.DOFade(0, 1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo); // ���̵� ��-�ƿ� �ݺ�

        // Light�� ���� ��ȭ�� ������ ȿ��
        lightSource.DOColor(new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value), 2f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart); // ���� ��ȭ�� �ݺ�

        DOTween.To(() => lightSource.intensity, x => lightSource.intensity = x, 0, 0.1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo) // ������ ȿ���� �ݺ�
            .SetDelay(0.2f); // ������ ���� �� �ణ�� ����
    }

    
}