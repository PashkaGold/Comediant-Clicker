using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public int money;
    public GameObject button;
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
    public void SubtractMoney()
    {
        if (money >= 40000000)
        {
            money -= 40000000;
            Update();
        }
        else
        {
            Debug.Log("Not enough money to subtract 40 million.");
        }
    }
    private void Update()
    {
        moneyText.text = money.ToString();

        if (money >= 40000000)
        {

                button.SetActive(true);
        }
    }

}
