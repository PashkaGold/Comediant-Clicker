using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Upgrades : MonoBehaviour
{
    public TMP_Text textPriceCharizma;
    public TMP_Text textPriceViewers;
    public TMP_Text textPriceJokes;
    
    public TMP_Text textInfoCharizma;
    public TMP_Text textInfoViewers;
    public TMP_Text textInfoJokes;

    public Button charismaButton;
    public Button viewersButton;
    public Button jokesButton;

    public Image workFieldImage;
    public List<Sprite> spriteList; // Додано список спрайтів
    private int currentSpriteIndex = 0; // Змінна для відстеження поточного індексу спрайту

    private int charismaLevel = 0;
    private int viewersLevel = 0;
    private int jokesLevel = 0;

    private int charismaUpgradeCost = 100;
    private int viewersUpgradeCost = 200;
    private int jokesUpgradeCost = 300;

    private int count = 1;

    private Clicker clicker;

    private Button workFieldButton; // Додано поле для компонента Button кнопки робочого поля
    public Image jokesButtonImage; // Додано поле для компонента Image кнопки jokesButton
    public Sprite[] newJokesSprites; // Додано поле для нового масиву спрайтів для jokesButton

    private void Start()
    {
        clicker = FindObjectOfType<Clicker>();
        UpdateUI();

        charismaButton.onClick.AddListener(UpgradeCharisma);
        viewersButton.onClick.AddListener(UpgradeViewers);
        jokesButton.onClick.AddListener(UpgradeJokes);

        // Перевірка, чи workFieldImage та jokesButton не є null перед отриманням компонентів Image
        if (workFieldImage == null)
        {
            Debug.LogError("workFieldImage не ініціалізовано! Перевірте правильність назви об'єкта в Scene.");
        }
        else
        {
            // Якщо workFieldImage не null, отримуємо компонент Image
            workFieldImage.sprite = spriteList[currentSpriteIndex];
        }

        if (jokesButton == null)
        {
            Debug.LogError("jokesButton не ініціалізовано! Перевірте правильність назви об'єкта в Scene.");
        }
        else
        {
            // Якщо jokesButton не null, отримуємо компонент Image
            jokesButtonImage = jokesButton.GetComponent<Image>();
        }

        
    }

    public void UpgradeCharisma()
    {
        if (clicker.money >= charismaUpgradeCost)
        {
            clicker.money -= charismaUpgradeCost;
            charismaLevel++;
            charismaUpgradeCost *= 2;
            count++;
            UpdateUI();
        }
    }

    public void UpgradeViewers()
    {
        if (clicker.money >= viewersUpgradeCost)
        {
            clicker.money -= viewersUpgradeCost;
            viewersLevel++;
            viewersUpgradeCost *= 2;

            // Зміна спрайту робочого поля при натисканні кнопки
            if (workFieldImage != null && spriteList.Count > 0)
            {
                // Змінити спрайт на наступний у списку
                currentSpriteIndex = (currentSpriteIndex + 1) % spriteList.Count;
                workFieldImage.sprite = spriteList[currentSpriteIndex];
            }

            count++;
            UpdateUI();
        }
    }

    public void UpgradeJokes()
    {
        if (clicker.money >= jokesUpgradeCost)
        {
            clicker.money -= jokesUpgradeCost;
            jokesLevel++;
            jokesUpgradeCost *= 2;

            // Зміна спрайту при натисканні кнопки
            if (jokesButtonImage != null && newJokesSprites != null && newJokesSprites.Length > 0)
            {
                // Виберіть індекс спрайта залежно від рівня або якоїсь іншої умови
                int newSpriteIndex = Mathf.Clamp(jokesLevel - 1, 0, newJokesSprites.Length - 1);
                jokesButtonImage.sprite = newJokesSprites[newSpriteIndex];
            }

            count++;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        textInfoCharizma.text = $"Харизма \t {charismaLevel}/4";
        textInfoJokes.text = $"Жарти \t {jokesLevel}/4";
        textInfoViewers.text = $"Публіка \t {viewersLevel}/4";

        textPriceCharizma.text = "Ціна: " + charismaUpgradeCost.ToString();
        textPriceViewers.text = "Ціна: " + viewersUpgradeCost.ToString();
        textPriceJokes.text = "Ціна: " + jokesUpgradeCost.ToString();
    }

    // Додана функція для отримання значення count
    public int GetCount()
    {
        return count;
    }
}
