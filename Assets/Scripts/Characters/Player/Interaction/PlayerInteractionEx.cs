using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    private Color originalBackgroundColor; // 기존 배경 색상 저장

    private void Awake()
    {
        InputActions = new PlayerInputActions();
        InputActions.Player.Exit.performed += ctx => OnEscapePressed();
     //   InputActions.Player.Interaction.performed += ctx => OnInteraction();
        cameraObj = objectCamera.GetComponent<Camera>();
        originalBackgroundColor = cameraObj.backgroundColor;
    }
    
    void Update()
    {
        if(cameraObj.orthographicSize == 0.5f)
            MovingCamera();
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
            originalBackgroundColor = cameraObj.backgroundColor;
            SetCameraBackground(Color.black);
            cameraUI.SetActive(true);

            float halfOrthographicSize = cameraObj.orthographicSize / 2f;

            minBound = new Vector3(originalCameraPosition.x - halfOrthographicSize, originalCameraPosition.y - halfOrthographicSize, originalCameraPosition.z);
            maxBound = new Vector3(originalCameraPosition.x + halfOrthographicSize, originalCameraPosition.y + halfOrthographicSize, originalCameraPosition.z);
        }
        

        //여기 부분에 위치를 카메라의 위치를 받고 카메라를 옮긴다.

    }

    private void SetCameraBackground(Color color)
    {
        cameraObj.backgroundColor = color;
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

    public void StartFocusInteraction()
    {
        if(!focusInteraction)
        {
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
            cameraObj.backgroundColor = originalBackgroundColor;
        }
        // ESC 키가 눌렸을 때 수행되어야 하는 동작을 여기에 추가합니다.
    }
}
