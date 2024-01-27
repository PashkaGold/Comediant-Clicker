using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Upgrades : MonoBehaviour
{
    public TMP_Text textPriceCharizma;
    public TMP_Text textPriceViewers;
    public TMP_Text textPriceJokes;

    public Button charismaButton;
    public Button viewersButton;
    public Button jokesButton;

    public Image workFieldImage;
    public List<Sprite> spriteList; // Додано список спрайтів
    private int currentSpriteIndex = 0; // Змінна для відстеження поточного індексу спрайту

    private int charismaLevel = 1;
    private int viewersLevel = 1;
    private int jokesLevel = 1;

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

        workFieldImage = GameObject.Find("YourWorkFieldObjectName").GetComponent<Image>();
        jokesButtonImage = jokesButton.GetComponent<Image>(); // Знайти компонент Image для jokesButton

        // Ініціалізація списку спрайтів
        spriteList = new List<Sprite>();
        // Додайте ваші об'єкти Sprite до списку
        spriteList.Add(Resources.Load<Sprite>("Sprite1")); // Замініть "Sprite1" на шлях до вашого спрайта
        spriteList.Add(Resources.Load<Sprite>("Sprite2")); // Замініть "Sprite2" на шлях до іншого спрайта
        // і так далі...

        if (workFieldImage != null && spriteList.Count > 0)
        {
            // Встановлення початкового спрайту для робочого поля
            workFieldImage.sprite = spriteList[currentSpriteIndex];
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
