using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private bool pausaActiva=false;
    [SerializeField] private GameObject menuPausa;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           intercambiarPausa();
        }
    }

    void intercambiarPausa() {
     pausaActiva = !pausaActiva;
        if (pausaActiva) {
            Time.timeScale = 0f; // Pausar el juego
            
        } else {
            Time.timeScale = 1f; // Reanudar el juego
        }
    }

    public void  pausarJuego () {
        Time.timeScale = 0f; // Pausar el juego
        pausaActiva = true;
        menuPausa.SetActive(true);
    }

   public void reanudarJuego () {
        Time.timeScale = 1f; // Reanudar el juego
        pausaActiva = false;
        menuPausa.SetActive(false);
    }
}
