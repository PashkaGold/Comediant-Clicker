using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clicker : MonoBehaviour
{
    [SerializeField] int money;
    [SerializeField] int count = 1;
    public TMP_Text moneyText;

    private void Awake()
    {
        // Завантажуємо збережене значення money
        money = PlayerPrefs.GetInt("money", 1000);
    }

    private void OnApplicationQuit()
    {
        // Зберігаємо значення money при виході з гри
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.Save(); // Збереження змін у PlayerPrefs
    }

    public void ButtonClick()
    {
        Debug.Log("Кнопку було натиснуто");
        money = money + count;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = money.ToString();
    }
}