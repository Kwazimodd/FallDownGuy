using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void goStartGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
        WaitUntil waitUntilSceneLoaded = new WaitUntil(() => SceneManager.GetSceneByName("Game").isLoaded);

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game"));
    }
    public void goSettings()
    {
        //do settings
    }
    public void goExit()
    {
        Application.Quit();
    }
}
