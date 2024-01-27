using UnityEngine;
using TMPro;

public class Clicker : MonoBehaviour
{
    public int money;


    public TMP_Text moneyText;
    private Upgrades upgrades;

    private void Awake()
    {
        money = PlayerPrefs.GetInt("money", 1000);
        upgrades = FindObjectOfType<Upgrades>();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.Save();
    }

    public void ButtonClick()
    {
        money += upgrades.GetCount(); // Отримуємо значення count з Upgrades
    }

    private void Update()
    {
        moneyText.text = $"{money.ToString()}/1000000";
    }
}
