using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField]
    Button playButton, quitButton;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        playButton.onClick.AddListener(OnPlayPressed);
        quitButton.onClick.AddListener(OnQuitPressed);
    }

    public void OnPlayPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }
}
