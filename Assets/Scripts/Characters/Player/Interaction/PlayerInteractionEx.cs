using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public static class ExtensionMethods
{
	public static void AddListener (this EventTrigger trigger, EventTriggerType eventType, System.Action<PointerEventData> listener)
	{
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = eventType;
		entry.callback.AddListener(data => listener.Invoke((PointerEventData)data));
		trigger.triggers.Add(entry);
	}
}

public class PlayerInteractionEx : MonoBehaviour
{
    public PlayerInputActions InputActions { get; private set; }
    [SerializeField] private GameObject interactionText;
    [SerializeField] private GameObject objectCamera;
    [SerializeField] private GameObject cameraUI;
    private Transform cameraPosition;

    private Camera cameraObj;
    private bool focusInteraction;
    private Vector3 minBound; // 제한할 구역의 최소 지점
    private Vector3 maxBound;
    private Vector3 originalCameraPosition;

    //private Ray ray;
    private RaycastHit[] ratHits;
    public float MAX_RAY_DISTANCE = 500f;

    [SerializeField] private RectTransform renderTextureUI; // Render Texture를 가지고 있는 UI 요소의 RectTransform
    [SerializeField]private RenderTexture renderTexture; // Render Texture

    private void Awake()
    {
        InputActions = new PlayerInputActions();
        InputActions.Player.Exit.performed += ctx => OnEscapePressed();
     //   InputActions.Player.Interaction.performed += ctx => OnInteraction();
        cameraObj = objectCamera.GetComponent<Camera>();
        interactionText.GetComponent<Button>().onClick.AddListener(OnInteraction);

        //cameraUI.GetComponent<EventTrigger>().AddListener(EventTriggerType.PointerClick, OnClick);

        renderTextureUI = objectCamera.GetComponent<RectTransform>();
        renderTexture = objectCamera.GetComponent<Camera>().targetTexture;
    }
    
    void Update()
    {
        if(cameraObj.orthographicSize == 0.5f)
            MovingCamera();
        // ray = objectCamera.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // 카메라 뷰포트의 중심에서 레이 생성
        
        // ratHits = Physics.RaycastAll(ray, MAX_RAY_DISTANCE); // 모든 충돌 정보를 가져옴

        // foreach (RaycastHit hit in ratHits)
        // {
        //     if (!hit.collider.CompareTag("Interaction"))
        //     {
        //         Debug.DrawLine(ray.origin, hit.point, Color.green); // 레이의 충돌 지점까지 초록색 라인을 그려줌 (디버그용)
        //         // Debug.Log("캐릭터가 보고 있는 오브젝트 이름: " + hit.collider.gameObject.name); // 디버그 로그 출력
                
        //         break; // 첫 번째로 발견한 "add" 태그를 가진 오브젝트만 처리하고 루프 종료
                
        //     }
        // }
    }

    private void OnEnable()
    {
        // Input 시스템 활성화
        InputActions.Enable();
    }
    
    private void OnDisable()
    {
        // Input 시스템 비활성화
        InputActions.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        // 상호작용 가능한 물체의 태그를 확인
        if (other.CompareTag("Interaction"))
        {
            if (other.transform.childCount > 0)
            {
                //interactionText = other.transform.GetChild(0);
                cameraPosition = other.transform.GetChild(0);
                // 가져온 첫 번째 자식에 대한 작업을 수행
            }
            else
            {
                Debug.Log("없습니다");
                return;
            }
            // UI 텍스트를 활성화하여 상호작용 가능 문구를 표시
            interactionText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 물체와의 충돌이 종료될 때 UI 텍스트 비활성화
        interactionText.gameObject.SetActive(false);
    }

    
    public void OnInteraction()
    {
        Debug.Log("나 누르는 중");
        interactionText.gameObject.SetActive(false);
        StartInteraction();
        // if (interactionText != null)
        // {
        //     // UI 텍스트가 활성화되어 있고, 마우스 왼쪽 버튼이 클릭되면 상호작용 시작
        //     if (interactionText.gameObject.activeSelf)
        //     {
        //         StartInteraction();
        //     }
        // }
        // else
        // {
        //     return;
        // }
    }

    private void StartInteraction()
    {
        // 상호작용 동작 실행
        Debug.Log("상호작용 시작!");
        if(cameraPosition != null)
        {
            objectCamera.transform.position = cameraPosition.position;
            originalCameraPosition = objectCamera.transform.position;
            cameraUI.SetActive(true);

            float halfOrthographicSize = cameraObj.orthographicSize / 2f;

            minBound = new Vector3(originalCameraPosition.x - halfOrthographicSize, originalCameraPosition.y - halfOrthographicSize, originalCameraPosition.z);
            maxBound = new Vector3(originalCameraPosition.x + halfOrthographicSize, originalCameraPosition.y + halfOrthographicSize, originalCameraPosition.z);
        }
        

        //여기 부분에 위치를 카메라의 위치를 받고 카메라를 옮긴다.

    }

    private void MovingCamera()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * 2f * Time.deltaTime;

        // 월드 좌표 기준으로 이동
        movement = objectCamera.transform.TransformDirection(movement);

        // 새로운 위치 계산
        Vector3 newPosition = objectCamera.transform.position + movement;

        // 이동한 위치를 특정 구역 내에 제한
        newPosition.x = Mathf.Clamp(newPosition.x, minBound.x, maxBound.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBound.y, maxBound.y);
        // newPosition.z = Mathf.Clamp(newPosition.z, minBound.z, maxBound.z);

        // 실제로 이동
        objectCamera.transform.position = newPosition;
    }

    private void OnClick(PointerEventData eventData)
    {
        if(!focusInteraction)
        {
            // 클릭된 UI 요소의 스크린 좌표를 가져옵니다.
            Vector2 screenPoint = eventData.position;

            // 스크린 좌표를 월드 좌표로 변환합니다.
            Ray ray = objectCamera.GetComponent<Camera>().ScreenPointToRay(screenPoint);
            RaycastHit hit;

            Debug.Log("ray 크기" + ray);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                objectCamera.transform.position = hit.point;
                cameraObj.orthographicSize = 0.5f;
                focusInteraction = true;
                // 클릭된 지점의 월드 좌표를 출력합니다.
                Debug.DrawLine(ray.origin, hit.point, Color.green);
                Debug.Log("클릭된 위치의 월드 좌표: " + hit.point);
            }
            else
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                Debug.Log("레이캐스트에 의한 충돌이 없습니다.");
            }
        }
    }

    public void StartFocusInteraction()
    {
        if(!focusInteraction)
        {
            // 클릭한 위치의 스크린 좌표를 가져옴
            Vector3 clickPosition = Input.mousePosition;

            Vector3 viewportPosition = cameraObj.ScreenToViewportPoint(clickPosition);
            

            Vector3 worldPosition = cameraObj.ViewportToWorldPoint(new Vector3(viewportPosition.x, viewportPosition.y, cameraObj.transform.position.z));

            Debug.Log($"이동 전 카메라 위치: {cameraObj.transform.position}");

            // 카메라 이동
            cameraObj.transform.position = new Vector3(worldPosition.x, worldPosition.y, cameraObj.transform.position.z);
            Debug.Log($"이동 후 카메라 위치: {cameraObj.transform.position}");

            cameraObj.orthographicSize = 0.5f;
            focusInteraction = true;
        }
    }

    private void OnEscapePressed()
    {
        Debug.Log("ESC 키가 눌렸습니다.");
        if(cameraPosition != null)
        {
            //objectCamera.transform.position = cameraPosition.position;
            cameraUI.SetActive(false);
            cameraObj.orthographicSize = 1f;
            focusInteraction = false;
        }
        // ESC 키가 눌렸을 때 수행되어야 하는 동작을 여기에 추가합니다.
    }
}
