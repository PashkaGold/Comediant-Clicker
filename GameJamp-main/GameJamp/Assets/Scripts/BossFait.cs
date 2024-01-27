using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ButtonVisibilityManager : MonoBehaviour
{
    [System.Serializable]
    public class ButtonData
    {
        public Button button;
        public float delayBeforeAppearance = 2f;
        public float visibilityDuration = 3f;
    }

    public List<ButtonData> buttonsToManage = new List<ButtonData>();

    void Start()
    {
        StartCoroutine(ManageAllButtonsVisibility());
    }

    IEnumerator ManageAllButtonsVisibility()
    {
        foreach (var buttonData in buttonsToManage)
        {
            if (buttonData.button == null)
            {
                Debug.LogError("Button �� ������� � ������ � ��'����! ������� Button �� ��� ��'����.");
                yield break;
            }

            StartCoroutine(ManageButtonVisibility(buttonData));
        }
    }

    IEnumerator ManageButtonVisibility(ButtonData buttonData)
    {
        // �������� ����� ���������� ������
        yield return new WaitForSeconds(buttonData.delayBeforeAppearance);

        // ������ ������ ������� �� ��������
        buttonData.button.gameObject.SetActive(true);
        buttonData.button.interactable = true;

        // �������� ����� ����������
        yield return new WaitForSeconds(buttonData.visibilityDuration);

        // ������ ������ ���������� �� ���������
        buttonData.button.interactable = false;
        buttonData.button.gameObject.SetActive(false);
    }
}
