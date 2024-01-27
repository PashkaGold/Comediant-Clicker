using System.Collections;
using UnityEngine;

public class BossFait : MonoBehaviour


{
    private Renderer objectRenderer;
    public float initialDelay = 2f; // Початкова затримка перед з'явленням
    public float visibleDuration = 3f; // Тривалість видимості
    public float invisibleDuration = 2f; // Тривалість невидимості

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
            // Зробити об'єкт видимимим
            objectRenderer.enabled = true;

            yield return new WaitForSeconds(visibleDuration);

            // Зробити об'єкт невидимимим
            objectRenderer.enabled = false;

            yield return new WaitForSeconds(invisibleDuration);
        }
    }
}
