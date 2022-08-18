using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject pausePanel, settingsPanel;
    private bool isSettingsActive;
    public Text darkModeText;

    public void ButtonPlay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

    public void ButtonSettings()
    {
        isSettingsActive = !isSettingsActive;
        settingsPanel.SetActive(isSettingsActive);
    }

    public void ButtonPause()
    {
        if(Time.timeScale == 0)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ButtonShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void ButtonBGColor()
    {
        if(PlayerPrefs.GetInt("blackBG") == 1)
        {
            PlayerPrefs.SetInt("blackBG", 0);
            Camera.main.backgroundColor = Color.white;
            darkModeText.text = "DARKMODE: OFF";
        }
        else
        {
            PlayerPrefs.SetInt("blackBG", 1);
            Camera.main.backgroundColor = Color.black;
            darkModeText.text = "DARKMODE: ON";
        }
    }
}
