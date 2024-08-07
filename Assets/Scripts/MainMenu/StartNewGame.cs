using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
    private const string GAME_SCENE = "GameScene";
    public void StartGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }
}
