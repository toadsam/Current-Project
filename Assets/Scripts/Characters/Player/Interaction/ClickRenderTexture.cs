using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickRenderTexture : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RectTransform renderTextureUI; // Render Texture�� ������ �ִ� UI ����� RectTransform

    [SerializeField]private Camera renderTextureCamera; // Render Texture�� �������ϴ� ī�޶�
    [SerializeField]private RenderTexture renderTexture; // Render Texture

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

        // ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ�մϴ�.
        Ray ray = renderTextureCamera.ScreenPointToRay(screenPoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // Ŭ���� ������ ���� ��ǥ�� ����մϴ�.
            Debug.Log("Ŭ���� ��ġ�� ���� ��ǥ: " + hit.point);
        }
        else
        {
            Debug.Log("����ĳ��Ʈ�� ���� �浹�� �����ϴ�.");
        }
    }
}