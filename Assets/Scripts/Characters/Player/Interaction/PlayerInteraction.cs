using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // UI �ؽ�Ʈ ������Ʈ
    private Transform interactionText;

    private void OnTriggerEnter(Collider other)
    {
        // ��ȣ�ۿ� ������ ��ü�� �±׸� Ȯ��
        if (other.CompareTag("Interaction"))
        {
            if (other.transform.childCount > 0)
            {
                interactionText = other.transform.GetChild(0);
                // ������ ù ��° �ڽĿ� ���� �۾��� ����
            }
            else
            {
                Debug.Log("�����ϴ�");
                return;
            }
            // UI �ؽ�Ʈ�� Ȱ��ȭ�Ͽ� ��ȣ�ۿ� ���� ������ ǥ��
            interactionText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ��ü���� �浹�� ����� �� UI �ؽ�Ʈ ��Ȱ��ȭ
        interactionText.gameObject.SetActive(false);
    }

    private void Update()
    {
        // ���콺 ���� ��ư Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            // UI �ؽ�Ʈ�� Ȱ��ȭ�Ǿ� �ְ�, ���콺 ���� ��ư�� Ŭ���Ǹ� ��ȣ�ۿ� ����
            if (interactionText.gameObject.activeSelf)
            {
                StartInteraction();
            }
        }
    }

    private void StartInteraction()
    {
        // ��ȣ�ۿ� ���� ����
        Debug.Log("��ȣ�ۿ� ����!");
    }
}
