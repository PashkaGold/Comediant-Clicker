using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public GameObject hiddenObject;
    public Button displayButton;
    public float displayDelay = 1f; // Затримка перед початком відображення об'єкта
    public float displayDuration = 3f; // Час в секундах, протягом якого об'єкт буде відображений

    private bool isDisplaying = false;

    private void Start()
    {
        // Початково приховуємо об'єкт
        hiddenObject.SetActive(false);

        // Додаємо обробник події для кнопки
        displayButton.onClick.AddListener(OnDisplayButtonClick);
    }

    private void Update()
    {
        // Перевіряємо, чи об'єкт не відображається в даний момент
        if (Input.GetKeyDown(KeyCode.Space) && !isDisplaying)
        {
            // Відображаємо об'єкт
            ShowObject();
        }
    }

    public void OnDisplayButtonClick()
    {
        // Перевіряємо, чи об'єкт не відображається в даний момент
        if (!isDisplaying)
        {
            // Відображаємо об'єкт
            ShowObject();
        }
    }

    private void ShowObject()
    {
        isDisplaying = true;

        // Запускаємо таймер на відображення об'єкта через displayDelay секунд
        Invoke("ActivateObject", displayDelay);
    }

    private void ActivateObject()
    {
        // Встановлюємо об'єкт видимим
        hiddenObject.SetActive(true);

        // Запускаємо таймер на приховування об'єкта через displayDuration секунд
        Invoke("HideObject", displayDuration);
    }

    private void HideObject()
    {
        // Приховуємо об'єкт після закінчення відображення
        hiddenObject.SetActive(false);
        isDisplaying = false;
    }
}
