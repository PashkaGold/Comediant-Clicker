using System.Collections;
using UnityEngine;

public class BossFait : MonoBehaviour


{
    private Renderer objectRenderer;
    public float initialDelay = 2f; // ��������� �������� ����� �'��������
    public float visibleDuration = 3f; // ��������� ��������
    public float invisibleDuration = 2f; // ��������� ����������

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        StartCoroutine(VisibilityRoutine());
    }

    private IEnumerator VisibilityRoutine()
    {
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            // ������� ��'��� ���������
            objectRenderer.enabled = true;

            yield return new WaitForSeconds(visibleDuration);

            // ������� ��'��� �����������
            objectRenderer.enabled = false;

            yield return new WaitForSeconds(invisibleDuration);
        }
    }
}
