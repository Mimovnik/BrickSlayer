using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void loadLevel(int num)
    {
        SceneManager.LoadScene("Level" + num);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
