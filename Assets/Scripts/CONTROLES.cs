using UnityEngine;
using UnityEngine.SceneManagement;

public class CONTROLES : MonoBehaviour
{
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menú");
        // Cambiá "MainMenu" por el nombre real de tu escena de menú
    }
}