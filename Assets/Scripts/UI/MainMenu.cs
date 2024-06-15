using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settings;

    public void Play()
    {
        SceneManager.LoadScene("Prototype");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Settings(bool open)
    {
        settings.SetActive(open);
    }
}
