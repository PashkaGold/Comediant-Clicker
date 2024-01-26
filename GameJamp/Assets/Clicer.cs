using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Unity.Collections.AllocatorManager;

public class Clicer : MonoBehaviour
{
    [SerializeField] int money;
    public TMP_Text moneyText, obgectPrice;
    public int price, access, Level;
    public GameObject block;
    private void Awake()
    {

         PlayerPrefs.SetInt("money", 1000);
    }
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

