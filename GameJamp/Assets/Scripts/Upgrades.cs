using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public TMP_Text textPriceCharizma;
    public TMP_Text textPriceViewers;
    public TMP_Text textPriceJokes;

    public Button charismaButton;
    public Button viewersButton;
    public Button jokesButton;

    private int charismaLevel = 1;
    private int viewersLevel = 1;
    private int jokesLevel = 1;

    private int charismaUpgradeCost = 100;
    private int viewersUpgradeCost = 200;
    private int jokesUpgradeCost = 300;

    private int count = 1; // Змінна count

    private Clicker clicker;

    private void Start()
    {
        clicker = FindObjectOfType<Clicker>();
        UpdateUI();

        charismaButton.onClick.AddListener(UpgradeCharisma);
        viewersButton.onClick.AddListener(UpgradeViewers);
        jokesButton.onClick.AddListener(UpgradeJokes);
    }

    public void UpgradeCharisma()
    {
        if (clicker.money >= charismaUpgradeCost)
        {
            clicker.money -= charismaUpgradeCost;
            charismaLevel++;
            charismaUpgradeCost *= 2;
            count++; // Збільшуємо count
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
            count++; // Збільшуємо count
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
            count++; // Збільшуємо count
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
