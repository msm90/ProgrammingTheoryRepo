using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuUI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    
    public void ExitGame()
    {
    if (Application.isEditor)
        EditorApplication.ExitPlaymode();
    else
        Application.Quit();
    }
}
