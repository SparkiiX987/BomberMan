using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    } 

    public void QuitGame()
    {
        Application.Quit();
    }
}
