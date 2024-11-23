using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadWinScreen() {
        SceneManager.LoadScene("WinScreen");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("GameJam");
    }
}
