using UnityEngine;
using System.Collections;

public class BossFait : MonoBehaviour
{
    private Renderer objectRenderer;
    public float delayBeforeAppearance = 2f; // �������� ����� ������ � ��������
    public float visibilityDuration = 3f; // ��������� �������� � ��������

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            // ��������� �������� ��� ��������� �������� ��'����
            StartCoroutine(ManageVisibility());
        }
        else
        {
            Debug.LogError("Renderer �� �������� �� ��'���!");
        }
    }

    IEnumerator ManageVisibility()
    {
        // ������ ��'��� ����������
        gameObject.SetActive(false);

        // �������� ����� ������
        yield return new WaitForSeconds(delayBeforeAppearance);

        // ������ ��'��� ��������
        gameObject.SetActive(true);

        // �������� ����� ����������
        yield return new WaitForSeconds(visibilityDuration);

        // ������ ��'��� ����������
        gameObject.SetActive(false);
    }
}
