using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Clicer : MonoBehaviour
{
    [SerializeField] int money;
    public TMP_Text moneyText;

    public void ButtonClick()
    {
        Debug.Log("Кнопку було натиснуто ");
        money++;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = money.ToString();
    }
}
