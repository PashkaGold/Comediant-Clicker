using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maymeny : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Debug.Log("���� ��������� ");
        Application.Quit();
    }
}
