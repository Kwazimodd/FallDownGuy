using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void goStartGame()
    {
        SceneManager.LoadScene("GameStart", LoadSceneMode.Single);
    }
    public void goExit()
    {
        Application.Quit();
    }
}