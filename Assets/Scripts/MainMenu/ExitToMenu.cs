using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenu : MonoBehaviour
{
    private const string MENU_SCENE = "MainMenu";

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(MENU_SCENE);
    }
}
