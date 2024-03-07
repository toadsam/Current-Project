using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHidingCamera : MonoBehaviour
{
    private Transform target = null;

    //가려진 물체를 확인하는 데 사용되는 둥근 캐스트의 반지름
    [SerializeField]
    private float sphereCastRadius = 1f;

    //Raycast 사용하여 반환되는 충돌 정보
    private RaycastHit[] hitBuffer = new RaycastHit[32];

    //숨길 오브젝트와 보여줄 오브젝트 정보를 담는 변수
    private List<HideableObject> hiddenObjects = new List<HideableObject>();
    private List<HideableObject> previouslyHiddenObjects = new List<HideableObject>();

    private GameObject tPlayer;

    //오브젝트 표시유무 작동
    private void LateUpdate()
    {
        RefreshHiddenObjects();
    }

    public void RefreshHiddenObjects()
    {
        if(tPlayer == null)
        {
            tPlayer = GameObject.FindWithTag("Player");
            if(tPlayer != null)
                target = tPlayer.transform;
        }

        //target 위치에 대한 ray 계산
        Vector3 toTarget = (target.position - transform.position);
        float targetDistance = toTarget.magnitude;
        Vector3 targetDirection = toTarget / targetDistance;

        //실수로 플레이어 뒤의 벽에 부딪히지 않도록 목표물 바로 앞에서 멈추기
        targetDistance -= sphereCastRadius * 1.1f;

        //리스트 추가
        hiddenObjects.Clear();

        //sphereCastRadius로 플레이어랑 부딪치는 물체가 Trigger를 hit 해야하는지 안해야하는지 알려줌
        int hitCount = Physics.SphereCastNonAlloc(transform.position,
                                                    sphereCastRadius,
                                                    targetDirection,
                                                    hitBuffer,
                                                    targetDistance,
                                                    -1,
                                                    QueryTriggerInteraction.Ignore);
        
        //숨길 수 있는 물건 모으기
        for(int i = 0; i < hitCount; i++)
        {
            var hit = hitBuffer[i];
            var hideable = HideableObject.GetRootHideableCollider(hit.collider);

            if(hideable != null)
                hiddenObjects.Add(hideable);
        }

        //오브젝트가 이미 등록되어 있는지 확인 후 숨겨야 하는 것과 보여줘야 하는 것을 넣어줌
        //숨김
        foreach(var hideable in hiddenObjects)
        {
            if(!previouslyHiddenObjects.Contains(hideable))
                hideable.SetVisible(false);
        }

        //표시
        foreach(var hideable in previouslyHiddenObjects)
        {
            if(!hiddenObjects.Contains(hideable))
                hideable.SetVisible(true);
        }

        //스왑 목록
        var temp = hiddenObjects;
        hiddenObjects = previouslyHiddenObjects;
        previouslyHiddenObjects = temp;
    }
}
