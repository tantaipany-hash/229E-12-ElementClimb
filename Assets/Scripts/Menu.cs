using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1); // Level1
    }

    public void GoToCredit()
    {
        SceneManager.LoadScene("Credit");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
