using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickRenderTexture : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RectTransform renderTextureUI; // Render Texture�� ������ �ִ� UI ����� RectTransform

    [SerializeField]private Camera renderTextureCamera; // Render Texture�� �������ϴ� ī�޶�
    [SerializeField]private RenderTexture renderTexture; // Render Texture
    [SerializeField] private GameObject FocusCamera;

    void Start()
    {
        // Render Texture�� �������ϴ� ī�޶� �����ɴϴ�.
        renderTextureCamera = GetComponentInChildren<Camera>();
        if (renderTextureCamera == null)
        {
            Debug.LogError("ī�޶� ������Ʈ�� ã�� �� �����ϴ�.");
        }
    }

    void OnEnable()
    {
        renderTextureCamera = GetComponentInChildren<Camera>();
        if (renderTextureCamera == null)
        {
            Debug.LogError("ī�޶� ������Ʈ�� ã�� �� �����ϴ�.");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Ŭ���� UI ����� ��ũ�� ��ǥ�� �����ɴϴ�.
        Vector2 screenPoint = eventData.position;

        // ��ũ�� ��ǥ�� ���� �ؽ�ó ��ǥ�� ��ȯ�մϴ�.
        Vector2 normalizedPoint = new Vector2(screenPoint.x / Screen.width, screenPoint.y / Screen.height);
        Vector2 renderTextureSize = new Vector2(renderTexture.width, renderTexture.height);
        Vector2 renderTexturePoint = Vector2.Scale(normalizedPoint, renderTextureSize);

        // ��ũ�� ��ǥ�� ���� �ؽ�ó ��ǥ�� ��ȯ�� ���̸� �����մϴ�.
        Ray ray = renderTextureCamera.ScreenPointToRay(renderTexturePoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // Ŭ���� ������ ���� ��ǥ�� ����մϴ�.
            Debug.Log("Ŭ���� ��ġ�� ���� ��ǥ: " + hit.point);
            FocusCamera.transform.position = hit.point;
        }
        else
        {
            Debug.Log("����ĳ��Ʈ�� ���� �浹�� �����ϴ�.");
        }
        // // Ŭ���� UI ����� ��ũ�� ��ǥ�� �����ɴϴ�.
        // Vector2 screenPoint = eventData.position;
        //
        // Vector3 viewportPoint = new Vector3(screenPoint.x / Screen.width, 1 - (screenPoint.y / Screen.height), 0);//new Vector3(screenPoint.x / Screen.width, screenPoint.y / Screen.height, 0);
        //
        // // ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ�մϴ�.
        // Ray ray = renderTextureCamera.ScreenPointToRay(viewportPoint);
        // RaycastHit hit;
        // if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        // {
        //     // Ŭ���� ������ ���� ��ǥ�� ����մϴ�.
        //     Debug.Log("Ŭ���� ��ġ�� ���� ��ǥ: " + hit.point);
        //     FocusCamera.transform.position = hit.point;
        // }
        // else
        // {
        //     Debug.Log("����ĳ��Ʈ�� ���� �浹�� �����ϴ�.");
        // }
    }
}