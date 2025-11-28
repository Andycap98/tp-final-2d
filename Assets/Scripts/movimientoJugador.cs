using UnityEngine;
using TMPro;
using System;

public class movimientoJugador : MonoBehaviour
{
    public TextMeshProUGUI vidas;
    public TextMeshProUGUI tiempo;
    public GameObject balaprefab; // prefab de la bala
    public Transform puntoDisparo; // punto desde donde se dispara la bala

    [SerializeField] float velocidad = 5.0f;
    Rigidbody2D rb;
    Vector2 direccion;

    // NUEVO: dirección de disparo según hacia dónde apunta la nave
    private Vector2 direccionDisparo = Vector2.right;

    public GameObject panelgameover;
    public GameObject panelganaste;
    public TextMeshProUGUI puntaje;
    public int maxVidas = 3;
    public float tiempoJuego = 30f;

    // flag para elegir modo de victoria
    [SerializeField] private bool ganarPorTiempo = false;
    // false = Nivel 1 (por puntaje)
    // true  = Nivel 2 (modo supervivencia por tiempo)

    private int vidasRestantes;
    private float tiempoRestante;
    private bool juegoTerminado;
    private Animator animator;

    void Start()
    {
        contadorDeDestrucciones.resetScore(); // reiniciar el puntaje al iniciar el juego
        vidasRestantes = maxVidas;
        tiempoRestante = tiempoJuego;

        if (panelgameover != null)
            panelgameover.SetActive(false);

        if (panelganaste != null)
            panelganaste.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        ActualizarVidasUI();
        ActualizarTiempoUI();

        animator = GetComponent<Animator>();

        contadorDeDestrucciones.OnScoreChanged += ActualizarPuntajeUI;

        // por defecto, disparar hacia la derecha
        direccionDisparo = Vector2.right;
    }

    private void ActualizarPuntajeUI()
    {
        if (puntaje != null)
        {
            int score = contadorDeDestrucciones.getScore();
            Debug.Log("Puntaje actualizado: " + score);
            puntaje.text = "Puntaje: " + score.ToString();

            // NIVEL 1: ganar por puntaje antes de que termine el tiempo
            if (!ganarPorTiempo && score >= 20 && tiempoRestante > 0f && !juegoTerminado)
            {
                Victoria();
            }
            // NIVEL 2: ganarPorTiempo = true -> el puntaje NO define victoria
        }
    }

    private void ActualizarVidasUI()
    {
        if (vidas != null)
            vidas.text = "Vidas: " + vidasRestantes.ToString();
    }

    private void ActualizarTiempoUI()
    {
        if (tiempo != null)
            tiempo.text = "Tiempo: " + Mathf.CeilToInt(tiempoRestante).ToString();
    }

    void Update()
    {
        if (juegoTerminado) return;

        // ---- MANEJO DEL TIEMPO ----
        tiempoRestante -= Time.deltaTime;
        if (tiempoRestante < 0f)
            tiempoRestante = 0f;

        // Si el tiempo llegó a 0, decidimos qué pasa según el modo
        if (tiempoRestante <= 0f)
        {
            ActualizarTiempoUI();

            if (!juegoTerminado) // por si ya hubo GameOver antes
            {
                if (ganarPorTiempo)
                {
                    // NIVEL 2: modo supervivencia -> si llegaste vivo hasta el final, ganás
                    Victoria();
                }
                else
                {
                    // NIVEL 1: depende del puntaje
                    int score = contadorDeDestrucciones.getScore();
                    if (score >= 20)
                    {
                        // Por si justo llega a 20 cuando el tiempo ya está en cero
                        Victoria();
                    }
                    else
                    {
                        // No llegó a 20 en el tiempo límite -> pierde
                        GameOver();
                    }
                }
            }

            return; // cortamos aquí, para que no siga moviéndose ni disparando
        }

        // Mientras aún hay tiempo, actualizamos el texto
        ActualizarTiempoUI();

        // ---- MOVIMIENTO + DISPARO ----
        float movimientoX = Input.GetAxisRaw("Horizontal");
        float movimientoY = Input.GetAxisRaw("Vertical");
        direccion = new Vector2(movimientoX, movimientoY).normalized;

        // DISPARO
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bala = Instantiate(balaprefab, puntoDisparo.position, Quaternion.identity);

            // pasar la dirección de disparo actual a la bala
            movimientoBala scriptBala = bala.GetComponent<movimientoBala>();
            if (scriptBala != null)
            {
                scriptBala.SetDireccion(direccionDisparo);
            }
        }

        // ANIMACIÓN + DIRECCIÓN DE DISPARO
        if (movimientoY > 0)
        {
            animator.SetInteger("estado", 1);   // arriba
            direccionDisparo = Vector2.up;      // disparar hacia arriba
        }
        else if (movimientoY < 0)
        {
            animator.SetInteger("estado", -1);  // abajo
            direccionDisparo = Vector2.down;    // disparar hacia abajo
        }
        else
        {
            animator.SetInteger("estado", 0);   // quieto
            direccionDisparo = Vector2.right;   // disparar hacia la derecha
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("meteorito"))
        {
            GolpeMeteorito();
        }

        if (collision.CompareTag("asteroide"))
        {
            Destroy(gameObject);
            GolpeAsteroide();
        }
    }

    public void GolpeMeteorito()
    {
        if (juegoTerminado) return;
        vidasRestantes--;
        ActualizarVidasUI();

        if (vidasRestantes <= 0)
            GameOver();
    }

    public void GolpeAsteroide()
    {
        if (juegoTerminado) return;
        vidasRestantes = 0;
        GameOver();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direccion * velocidad * Time.fixedDeltaTime);
    }

    public void GameOver()
    {
        if (juegoTerminado) return;

        juegoTerminado = true;
        if (panelgameover != null)
            panelgameover.SetActive(true);
    }

    public void Victoria()
    {
        if (juegoTerminado) return; // evitar llamar dos veces

        juegoTerminado = true;
        if (panelganaste != null)
            panelganaste.SetActive(true);
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}
