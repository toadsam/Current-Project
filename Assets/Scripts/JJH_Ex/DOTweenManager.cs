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
                // DOTweenManager 인스턴스가 없으면 새로 생성합니다.
                GameObject obj = new GameObject("DOTweenManager");
                instance = obj.AddComponent<DOTweenManager>();
                DontDestroyOnLoad(obj); // 씬 전환시에도 파괴되지 않도록 설정합니다.
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // 씬 전환시에도 파괴되지 않도록 설정합니다.
        }
        else if (instance != this)
        {
            Destroy(gameObject); // 중복 인스턴스를 파괴합니다.
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

    // 예시: GameObject를 x축으로 이동시키는 메서드
    public void MoveX(GameObject target, float endValue, float duration)
    {
        target.transform.DOMoveX(endValue, duration);
    }

    // 다른 DOTween 애니메이션 메서드를 여기에 추가...
    public void MoveY(GameObject target, float endValue, float duration, bool snapping = false)
    {
        target.transform.DOMoveY(endValue, duration).SetEase(Ease.InOutQuad).SetOptions(snapping);
    }
    
    //회전 하는 코드
    public void Rotate(GameObject target, Vector3 byAngles, float duration)
    {
        target.transform.DORotate(byAngles, duration, RotateMode.FastBeyond360).SetEase(Ease.InOutQuad);
    }
    
    //크기를 변경하는 코드
    public void Scale(GameObject target, Vector3 endValue, float duration)
    {
        target.transform.DOScale(endValue, duration).SetEase(Ease.InOutQuad);
    }
    
    //fade in  out하는 코드
    public void Fade(CanvasGroup target, float endValue, float duration)
    {
        target.DOFade(endValue, duration).SetEase(Ease.InOutQuad);
    }
    
    //색을 바꾸는 코드
    public void ColorChange(SpriteRenderer target, Color endValue, float duration)
    {
        target.DOColor(endValue, duration).SetEase(Ease.InOutQuad);
    }
    
    //다양한 조합의 코드
    public void SequenceExample(GameObject target)
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(target.transform.DOMoveX(5f, 1f)); // 1초 동안 x축으로 5만큼 이동
        mySequence.Append(target.transform.DORotate(new Vector3(0, 180, 0), 1f)); // 그 후 1초 동안 180도 회전
        mySequence.Append(target.transform.DOScale(new Vector3(2, 2, 2), 1f)); // 마지막으로 1초 동안 크기를 2배로 증가
    }
    
    //객체를 정의된 경로로 이동시키기
    public void MoveAlongPath(GameObject target, Vector3[] pathPoints, float duration, PathType pathType = PathType.CatmullRom, PathMode pathMode = PathMode.Full3D)
    {
        // pathPoints는 이동할 경로의 점들을 나타냅니다.
        // PathType.CatmullRom은 경로가 부드럽게 연결되도록 합니다.
        // PathMode.Full3D는 객체가 경로를 따라 3D 공간에서 회전하도록 합니다.
        target.transform.DOPath(pathPoints, duration, pathType, pathMode)
            .SetEase(Ease.InOutQuad) // 부드러운 시작과 끝을 위한 Easing
            .SetOptions(false) // 경로의 방향에 맞춰서 자동으로 회전하지 않도록 설정
            .SetLookAt(0.01f); // 약간 앞을 바라보도록 설정하여 더 자연스러운 이동 효과를 줍니다.
    }
    //객체가 잠깐 팽창했다가 돌아오는 효과

    public void PunchScale(GameObject target, Vector3 punch, float duration, int vibrato = 10, float elasticity = 1)
    {
        // punch는 얼마나 멀리 팽창할지를 나타내는 벡터입니다.
        // vibrato는 펀치 동안 진동하는 횟수를 나타냅니다.
        // elasticity는 펀치가 되돌아오는 정도를 나타냅니다. 1에 가까울수록 원래 크기로 완전히 되돌아옵니다.
        target.transform.DOPunchScale(punch, duration, vibrato, elasticity)
            .SetEase(Ease.OutElastic); // Elastic 효과로 끝맺음하여 자연스러운 동작을 구현
    }
    
    //GameObject의 투명도를 0에서 1로 변경하고 동시에 작은 크기에서 원래 크기로 확대하는 애니메이션입니다.
    public void FadeInAndScaleUp(GameObject target)
    {
        // 투명도를 0으로 설정합니다.
        CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();
        if (canvasGroup == null) canvasGroup = target.AddComponent<CanvasGroup>();
        canvasGroup.alpha = 0;

        // 크기를 줄입니다.
        target.transform.localScale = Vector3.zero;

        // 투명도를 1로 변경하고, 크기를 원래대로 돌립니다.
        canvasGroup.DOFade(1, 1f); // 1초 동안 페이드 인
        target.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBack); // 1초 동안 확대, 탄성 효과
    }
    
    //GameObject가 바운스하면서 회전하는 애니메이션입니다.
    public void BounceAndRotate(GameObject target)
    {
        // 바운스 효과
        float jumpHeight = 2f; // 점프 높이
        target.transform.DOJump(target.transform.position, jumpHeight, 1, 1f)
            .SetEase(Ease.OutQuad); // 바운스 효과

        // 회전 효과
        target.transform.DORotate(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear); // 1초 동안 360도 회전
    }
    //GameObject를 서서히 투명하게 만든 후 사라지게 하는 애니메이션입니다.
    public void FadeOutAndDisappear(GameObject target)
    {
        CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();
        if (canvasGroup == null) canvasGroup = target.AddComponent<CanvasGroup>();

        // 투명도를 서서히 0으로 변경합니다.
        canvasGroup.DOFade(0, 1f) // 1초 동안 페이드 아웃
            .OnComplete(() => GameObject.Destroy(target)); // 애니메이션이 완료되면 GameObject를 제거
    }
    
    //GameObject가 반복적으로 확대 및 축소되는 펄스 효과를 생성합니다.
    public void Pulse(GameObject target)
    {
        // 확대 축소를 반복합니다.
        target.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f) // 0.5초 동안 확대
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo); // 무한 반복, 확대 후 축소
    }
    
    //GameObject가 확대 및 축소되는 동안 관련된 Light의 강도가 증가하거나 감소하는 펄스 효과를 생성합니다.
    public void LightIntensityPulseWithScale(GameObject target, Light lightSource)
    {
        // GameObject 확대 축소 효과
        target.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f) // 0.5초 동안 확대
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo); // 무한 반복, 확대 후 축소

        // Light 강도 펄스 효과
        float originalIntensity = lightSource.intensity;
        DOTween.To(() => lightSource.intensity, x => lightSource.intensity = x, originalIntensity * 1.5f, 0.5f) // 강도 증가
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo); // 무한 반복, 강도 증가 후 감소
    }
    
    //GameObject가 이동하는 동안 관련된 Light의 색상을 변경하는 효과를 생성합니다. 이 메서드는 GameObject가 특정 경로를 따라 이동할 때 조명의 색상을 동적으로 변경하고자 할 때 유용합니다.
    public void LightColorChangeOnMove(GameObject target, Light lightSource, Vector3 endPosition, float duration)
    {
        // GameObject 이동 효과
        target.transform.DOMove(endPosition, duration)
            .SetEase(Ease.InOutQuad);

        // Light 색상 변경 효과
        Color originalColor = lightSource.color;
        Color targetColor = Color.red; // 목표 색상을 빨간색으로 설정
        DOTween.To(() => lightSource.color, x => lightSource.color = x, targetColor, duration)
            .SetEase(Ease.InOutQuad);
    }
    
    //GameObject가 회전하는 동안 관련된 Light가 깜빡이는 효과를 생성합니다. 이 메서드는 공포 게임에서의 손전등 깜박임이나 경고 신호 등에 사용될 수 있습니다.
    public void LightFlickerEffectOnRotation(GameObject target, Light lightSource, Vector3 rotationAngles, float duration)
    {
        // GameObject 회전 효과
        target.transform.DORotate(rotationAngles, duration)
            .SetEase(Ease.InOutQuad);

        // Light 깜빡임 효과
        float flickerDuration = 0.1f; // 깜빡임 지속 시간
        int flickerCount = Mathf.FloorToInt(duration / flickerDuration); // 전체 지속 시간 동안 깜빡일 횟수
        DOTween.To(() => lightSource.intensity, x => lightSource.intensity = x, 0, flickerDuration) // 강도를 0으로 변경
            .SetLoops(flickerCount, LoopType.Yoyo) // 강도를 원래대로 복구하는 것을 포함한 깜빡임 횟수 설정
            .SetEase(Ease.InOutQuad);
    }
    
    
    //GameObject의 크기가 펄스 효과로 변하면서 동시에 Light의 강도와 색상이 지속적으로 변하는 효과입니다.
    public void ColorfulPulseWithLightIntensityAndScale(GameObject target, Light lightSource)
    {
        // GameObject 크기 펄스 효과
        target.transform.DOScale(new Vector3(1.05f, 1.05f, 1.05f), 1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);

        // Light 강도 펄스 효과
        DOTween.To(() => lightSource.intensity, x => lightSource.intensity = x, lightSource.intensity * 1.2f, 1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);

        // Light 색상 변화 효과
        DOTween.To(() => lightSource.color, x => lightSource.color = x, new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value), 2f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
    }
    
    //GameObject가 회전하면서 크기가 점차 증가하고, 관련된 Light가 빔처럼 방향을 바꾸면서 지속적으로 색상이 변하는 효과입니다.
    public void RotatingLightBeamWithScaling(GameObject target, Light lightSource)
    {
        // GameObject 회전 효과
        target.transform.DORotate(new Vector3(0, 0, 360), 5f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);

        // GameObject 크기 증가 효과
        target.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 5f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);

        // Light 색상 변화 효과
        DOTween.To(() => lightSource.color, x => lightSource.color = x, new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value), 3f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
    }
    
    //GameObject가 페이드 인-아웃 하는 동안 관련된 Light가 깜박이는 효과를 생성합니다. 이 메서드는 음산한 분위기를 연출하거나 주의를 끌고자 할 때 유용합니다.
    public void LightFlickerAndGameObjectFade(GameObject target, Light lightSource)
    {
        // GameObject 페이드 인-아웃 효과
        CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();
        if (canvasGroup == null) canvasGroup = target.AddComponent<CanvasGroup>();
        canvasGroup.DOFade(0, 1f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);

        // Light 깜박임 효과
        DOTween.To(() => lightSource.intensity, x => lightSource.intensity = x, 0, 0.1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(0.5f); // 깜박임 시작 전 약간의 지연을 추가
    }
    
    public void ComplexAnimationWithRandomMovement(GameObject target, Light lightSource)
    {
        // GameObject의 랜덤한 위치로의 빠른 이동
        DOTween.Sequence()
            .Append(target.transform.DOMove(new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), target.transform.position.z), 0.5f).SetEase(Ease.InOutQuad))
            .AppendInterval(0.5f) // 잠시 대기
            .SetLoops(-1, LoopType.Restart); // 반복

        // GameObject 크기 변화와 페이드 인-아웃 효과
        target.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo); // 크기 변화를 반복

        CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>();
        if (canvasGroup == null) canvasGroup = target.AddComponent<CanvasGroup>();
        canvasGroup.DOFade(0, 1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo); // 페이드 인-아웃 반복

        // Light의 색상 변화와 깜박임 효과
        lightSource.DOColor(new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value), 2f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart); // 색상 변화를 반복

        DOTween.To(() => lightSource.intensity, x => lightSource.intensity = x, 0, 0.1f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo) // 깜박임 효과를 반복
            .SetDelay(0.2f); // 깜박임 시작 전 약간의 지연
    }

    
}