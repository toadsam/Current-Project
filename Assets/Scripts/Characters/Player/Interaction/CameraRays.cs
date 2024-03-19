using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraRays : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    [SerializeField] private GameObject FocusCamera;
    private RaycastHit[] ratHits;

    private Ray ray;

    public float MAX_RAY_DISTANCE = 500.0f;
    private float greenRayDuration = 0.0f;
    public float GREEN_RAY_THRESHOLD = 2.0f;

    

    private void LateUpdate()
    {
        if (PlayerInteractionEx.isDetect)
        {

            ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // 카메라 뷰포트의 중심에서 레이 생성
            ratHits = Physics.RaycastAll(ray, MAX_RAY_DISTANCE); // 모든 충돌 정보를 가져옴
            

            foreach (RaycastHit hit in ratHits)
            {
                if (hit.collider.CompareTag("FocusObject") && (!hit.collider.gameObject.GetComponent<InteractionObject>().data.isComplete)) // 충돌한 오브젝트의 태그가 "add"인 경우에만
                {
                  
                    Debug.DrawLine(ray.origin, hit.point, Color.green); // 레이의 충돌 지점까지 초록색 라인을 그려줌 (디버그용)
                    
                    
                   
                    
                        greenRayDuration += Time.deltaTime; // 초록색 레이캐스트의 지속 시간 업데이트
                        if (greenRayDuration >= GREEN_RAY_THRESHOLD)
                        {
                    
                            ExecuteFunction(ratHits[0].point,hit.collider.gameObject); // 초록색 레이캐스트가 일정 시간 이상 지속되면 함수 실행
                            greenRayDuration = 0.0f; // 초록색 레이캐스트가 감지되지 않았으므로 지속 시간 초기화
                          ;
                        
                        }
                    
                   
                      
                    

                    break; // 첫 번째로 발견한 "add" 태그를 가진 오브젝트만 처리하고 루프 종료
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
                }


            }


            void ExecuteFunction(Vector3 hitPoint, GameObject gameObject)
            {
                  Debug.Log("초록색 레이캐스트가 2초 이상 지속되었습니다!");
                if (gameObject.GetComponent<InteractionObject>() != null)
                {
                    if (gameObject.GetComponent<InteractionObject>().data.isChage == true)
                    {
                        Debug.Log("바뀌었다");
                        MainManager.Instance.GetScore();
                        gameObject.GetComponent<InteractionObject>().data.isComplete = true;
                    }
                    else
                    {
                        Debug.Log("안 바뀌었다");
                    }
                }
                else { Debug.Log("없는 다른 값이다!!!!");
                }
                
            }
        }
    }
}
