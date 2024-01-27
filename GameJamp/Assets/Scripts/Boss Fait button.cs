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
                Debug.LogError("Не вказано об'єкт для вискакування! Додайте об'єкт до скрипта.");
            }
        }
    }

    public void OnButtonClick(int index)
    {
        if (index >= 0 && index < objectsToPopUp.Length)
        {
            var objectData = objectsToPopUp[index];

            // Початкова затримка перед появою об'єкта
            Invoke("PopUpObject", objectData.delayBeforeAppearance);
        }
        else
        {
            Debug.LogError("Неправильний індекс об'єкта для вискакування!");
        }
    }

    private void PopUpObject()
    {
        foreach (var objectData in objectsToPopUp)
        {
            if (objectData.objectToPopUp != null)
            {
                // Робимо об'єкт видимимим
                objectData.objectToPopUp.SetActive(true);

                // Затримка перед зникненням
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
                // Робимо об'єкт невидимим
                objectData.objectToPopUp.SetActive(false);
            }
        }
    }
}
