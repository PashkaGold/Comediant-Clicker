using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Unity.Collections.AllocatorManager;

public class Clicer : MonoBehaviour
{
    [SerializeField] int money;
    [SerializeField] int count = 1;
    public TMP_Text moneyText;

    private void Awake()
    {

         PlayerPrefs.SetInt("money", 1000);
    }
    public void ButtonClick()
    {
        Debug.Log("Кнопку було натиснуто ");
        money = money + count;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = money.ToString();
    }

   
    }

