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

    private int charismaLevel = 0;
    private int viewersLevel = 0;
    private int jokesLevel = 0;

    private int[] charismaUpgradeCosts = { 100, 250, 1600, 35000 };
    private int[] viewersUpgradeCosts = { 500, 3000, 85000, 900000 };
    private int[] jokesUpgradeCosts = { 100000, 200000, 2300000, 10000000 };

    private int charismaMultiplier = 2;
    private int viewersMultiplier = 3;
    private int jokesMultiplier = 4;

    private Clicker clicker;

    private int count = 1;

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
        if (clicker.money >= charismaUpgradeCosts[charismaLevel] && charismaLevel < 4)
        {
            clicker.money -= charismaUpgradeCosts[charismaLevel];
            charismaLevel++;
            count++;
            UpdateUI();
        }
    }

    public void UpgradeViewers()
    {
        if (clicker.money >= viewersUpgradeCosts[viewersLevel] && viewersLevel < 4)
        {
            clicker.money -= viewersUpgradeCosts[viewersLevel];
            viewersLevel++;
            count++;
            UpdateUI();
        }
    }

    public void UpgradeJokes()
    {
        if (clicker.money >= jokesUpgradeCosts[jokesLevel] && jokesLevel < 4)
        {
            clicker.money -= jokesUpgradeCosts[jokesLevel];
            jokesLevel++;
            count++;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        textInfoCharizma.text = $"Харизма \t {charismaLevel}/4";
        textInfoJokes.text = $"Жарти \t {jokesLevel}/4";
        textInfoViewers.text = $"Публіка \t {viewersLevel}/4";

        textPriceCharizma.text = "Ціна: " + FormatNumber(charismaUpgradeCosts[charismaLevel]);
        textPriceViewers.text = "Ціна: " + FormatNumber(viewersUpgradeCosts[viewersLevel]);
        textPriceJokes.text = "Ціна: " + FormatNumber(jokesUpgradeCosts[jokesLevel]);
    }

    public int GetCount()
    {
        return count;
    }

    string FormatNumber(int number)
    {
        if (number >= 1000000)
        {
            return (number / 1000000f).ToString("0.#") + "млн";
        }
        else if (number >= 1000)
        {
            return (number / 1000f).ToString("0.#") + "к";
        }
        else
        {
            return number.ToString();
        }
    }
}
