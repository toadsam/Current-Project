using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public PlayerInputActions InputActions { get; private set; }
    private Transform interactionText;
    [SerializeField] private GameObject objectCamera;
    [SerializeField] private GameObject cameraUI;
    private Transform cameraPosition;

    private void Awake()
    {
        InputActions = new PlayerInputActions();
        InputActions.Player.Exit.performed += ctx => OnEscapePressed();
        InputActions.Player.Interaction.performed += ctx => OnInteraction();
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
                interactionText = other.transform.GetChild(0);
                cameraPosition = other.transform.GetChild(1);
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

    
    private void OnInteraction()
    {
        Debug.Log("나 누르는 중");
        if (interactionText != null)
        {
            // UI 텍스트가 활성화되어 있고, 마우스 왼쪽 버튼이 클릭되면 상호작용 시작
            if (interactionText.gameObject.activeSelf)
            {
                StartInteraction();
            }
        }
        else
        {
            return;
        }
    }

    private void StartInteraction()
    {
        // 상호작용 동작 실행
        Debug.Log("상호작용 시작!");
        if(cameraPosition != null)
        {
            objectCamera.transform.position = cameraPosition.position;
            cameraUI.SetActive(true);
        }
        //여기 부분에 위치를 카메라의 위치를 받고 카메라를 옮긴다.

    }
    private void OnEscapePressed()
    {
        Debug.Log("ESC 키가 눌렸습니다.");
        if(cameraPosition != null)
        {
            //objectCamera.transform.position = cameraPosition.position;
            cameraUI.SetActive(false);
        }
        // ESC 키가 눌렸을 때 수행되어야 하는 동작을 여기에 추가합니다.
    }
}
