using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public GameObject hiddenObject;
    public Button displayButton;
    public float displayDelay = 1f; // �������� ����� �������� ����������� ��'����
    public float displayDuration = 3f; // ��� � ��������, �������� ����� ��'��� ���� �����������

    private bool isDisplaying = false;

    private void Start()
    {
        // ��������� ��������� ��'���
        hiddenObject.SetActive(false);

        // ������ �������� ��䳿 ��� ������
        displayButton.onClick.AddListener(OnDisplayButtonClick);
    }

    private void Update()
    {
        // ����������, �� ��'��� �� ������������ � ����� ������
        if (Input.GetKeyDown(KeyCode.Space) && !isDisplaying)
        {
            // ³��������� ��'���
            ShowObject();
        }
    }

    public void OnDisplayButtonClick()
    {
        // ����������, �� ��'��� �� ������������ � ����� ������
        if (!isDisplaying)
        {
            // ³��������� ��'���
            ShowObject();
        }
    }

    private void ShowObject()
    {
        isDisplaying = true;

        // ��������� ������ �� ����������� ��'���� ����� displayDelay ������
        Invoke("ActivateObject", displayDelay);
    }

    private void ActivateObject()
    {
        // ������������ ��'��� �������
        hiddenObject.SetActive(true);

        // ��������� ������ �� ������������ ��'���� ����� displayDuration ������
        Invoke("HideObject", displayDuration);
    }

    private void HideObject()
    {
        // ��������� ��'��� ���� ��������� �����������
        hiddenObject.SetActive(false);
        isDisplaying = false;
    }
}
