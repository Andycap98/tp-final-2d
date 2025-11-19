using UnityEngine;

public class MENU : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Juego");
    }
    public void StartToLevel2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("JuegoNivel2");
    }
}
