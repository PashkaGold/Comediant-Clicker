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

    public Image workFieldImage;
    public List<Sprite> spriteList; // ������ ������ �������
    private int currentSpriteIndex = 0; // ����� ��� ���������� ��������� ������� �������

    private int charismaLevel = 0;
    private int viewersLevel = 0;
    private int jokesLevel = 0;

    private int charismaUpgradeCost = 100;
    private int viewersUpgradeCost = 200;
    private int jokesUpgradeCost = 300;

    private int count = 1;

    private Clicker clicker;

    private Button workFieldButton; // ������ ���� ��� ���������� Button ������ �������� ����
    public Image jokesButtonImage; // ������ ���� ��� ���������� Image ������ jokesButton
    public Sprite[] newJokesSprites; // ������ ���� ��� ������ ������ ������� ��� jokesButton

    private void Start()
    {
        clicker = FindObjectOfType<Clicker>();
        UpdateUI();

        charismaButton.onClick.AddListener(UpgradeCharisma);
        viewersButton.onClick.AddListener(UpgradeViewers);
        jokesButton.onClick.AddListener(UpgradeJokes);

        // ��������, �� workFieldImage �� jokesButton �� � null ����� ���������� ���������� Image
        if (workFieldImage == null)
        {
            Debug.LogError("workFieldImage �� ������������! �������� ����������� ����� ��'���� � Scene.");
        }
        else
        {
            // ���� workFieldImage �� null, �������� ��������� Image
            workFieldImage.sprite = spriteList[currentSpriteIndex];
        }

        if (jokesButton == null)
        {
            Debug.LogError("jokesButton �� ������������! �������� ����������� ����� ��'���� � Scene.");
        }
        else
        {
            // ���� jokesButton �� null, �������� ��������� Image
            jokesButtonImage = jokesButton.GetComponent<Image>();
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

            // ���� ������� �������� ���� ��� ��������� ������
            if (workFieldImage != null && spriteList.Count > 0)
            {
                // ������ ������ �� ��������� � ������
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

            // ���� ������� ��� ��������� ������
            if (jokesButtonImage != null && newJokesSprites != null && newJokesSprites.Length > 0)
            {
                // ������� ������ ������� ������� �� ���� ��� ����� ���� �����
                int newSpriteIndex = Mathf.Clamp(jokesLevel - 1, 0, newJokesSprites.Length - 1);
                jokesButtonImage.sprite = newJokesSprites[newSpriteIndex];
            }

            count++;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        textInfoCharizma.text = $"������� \t {charismaLevel}/4";
        textInfoJokes.text = $"����� \t {jokesLevel}/4";
        textInfoViewers.text = $"������ \t {viewersLevel}/4";

        textPriceCharizma.text = "ֳ��: " + charismaUpgradeCost.ToString();
        textPriceViewers.text = "ֳ��: " + viewersUpgradeCost.ToString();
        textPriceJokes.text = "ֳ��: " + jokesUpgradeCost.ToString();
    }

    // ������ ������� ��� ��������� �������� count
    public int GetCount()
    {
        return count;
    }
}
