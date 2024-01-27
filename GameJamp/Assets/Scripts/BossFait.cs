using UnityEngine;
using System.Collections;

public class BossFait : MonoBehaviour
{
    private Renderer objectRenderer;
    public float delayBeforeAppearance = 2f; // Затримка перед появою в секундах
    public float visibilityDuration = 3f; // Тривалість видимості в секундах

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            // Запускаємо корутину для управління видимістю об'єкта
            StartCoroutine(ManageVisibility());
        }
        else
        {
            Debug.LogError("Renderer не знайдено на об'єкті!");
        }
    }

    IEnumerator ManageVisibility()
    {
        // Робимо об'єкт неактивним
        gameObject.SetActive(false);

        // Затримка перед появою
        yield return new WaitForSeconds(delayBeforeAppearance);

        // Робимо об'єкт активним
        gameObject.SetActive(true);

        // Затримка перед зникненням
        yield return new WaitForSeconds(visibilityDuration);

        // Робимо об'єкт неактивним
        gameObject.SetActive(false);
    }
}
