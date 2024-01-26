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
        // ����������� ��������� �������� money
        money = PlayerPrefs.GetInt("money", 1000);
    }

    private void OnApplicationQuit()
    {
        // �������� �������� money ��� ����� � ���
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.Save(); // ���������� ��� � PlayerPrefs
    }

    public void ButtonClick()
    {
        Debug.Log("������ ���� ���������");
        money = money + count;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = money.ToString();
    }
}