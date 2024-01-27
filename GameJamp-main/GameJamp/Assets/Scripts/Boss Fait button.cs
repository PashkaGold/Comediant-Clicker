using UnityEngine;

public class bossFAITbutton : MonoBehaviour
{
    [System.Serializable]
    public class ObjectData
    {
        public GameObject objectToPopUp;
        public float delayBeforeAppearance = 2f;
        public float visibilityDuration = 3f;
    }

    public ObjectData[] objectsToPopUp;

    private void Start()
    {
        foreach (var objectData in objectsToPopUp)
        {
            if (objectData.objectToPopUp != null)
            {
                objectData.objectToPopUp.SetActive(false);
            }
            else
            {
                Debug.LogError("�� ������� ��'��� ��� ������������! ������� ��'��� �� �������.");
            }
        }
    }

    public void OnButtonClick(int index)
    {
        if (index >= 0 && index < objectsToPopUp.Length)
        {
            var objectData = objectsToPopUp[index];

            // ��������� �������� ����� ������ ��'����
            Invoke("PopUpObject", objectData.delayBeforeAppearance);
        }
        else
        {
            Debug.LogError("������������ ������ ��'���� ��� ������������!");
        }
    }

    private void PopUpObject()
    {
        foreach (var objectData in objectsToPopUp)
        {
            if (objectData.objectToPopUp != null)
            {
                // ������ ��'��� ���������
                objectData.objectToPopUp.SetActive(true);

                // �������� ����� ����������
                Invoke("HideObject", objectData.visibilityDuration);
            }
        }
    }

    private void HideObject()
    {
        foreach (var objectData in objectsToPopUp)
        {
            if (objectData.objectToPopUp != null)
            {
                // ������ ��'��� ���������
                objectData.objectToPopUp.SetActive(false);
            }
        }
    }
}
