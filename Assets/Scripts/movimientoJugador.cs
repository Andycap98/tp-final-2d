using UnityEngine;
using TMPro;
using System;

public class movimientoJugador : MonoBehaviour
{
    public TextMeshProUGUI vidas;
    public TextMeshProUGUI tiempo;
  public  GameObject balaprefab; //prefab de la bala
    public Transform puntoDisparo; //punto desde donde se dispara la bala

    // crear un atributo velocidad de tipo float
    [SerializeField] float velocidad = 5.0f;
    Rigidbody2D rb;//sirve para controlar el movimiento del jugador
    Vector2 direccion;
    public GameObject panelgameover;
    public GameObject panelganaste;
    public TextMeshProUGUI puntaje;
    public int maxVidas= 3;
    public float tiempoJuego = 30f;
    private int vidasRestantes;
    private float tiempoRestante;
    private bool juegoTerminado;
    private Animator animator;
    void Start()
    {
        vidasRestantes = maxVidas;
        tiempoRestante = tiempoJuego;
        if (panelgameover != null)
            panelgameover.SetActive(false); // Asegurarse de que el panel de Game Over esté desactivado al inicio
        
        if (panelganaste != null)
            panelganaste.SetActive(false); // Asegurarse de que el panel de Ganaste esté desactivado al inicio


        rb = GetComponent<Rigidbody2D>();//decirle al script que obtenga el componente Rigidbody2D del objeto al que está adjunto
        rb.gravityScale = 0;//para que no afecte la gravedad al jugador

        ActualizarVidasUI();
        ActualizarTiempoUI();

        animator = GetComponent<Animator>();

        contadorDeDestrucciones.OnScoreChanged += ActualizarPuntajeUI;
    }

    private void ActualizarPuntajeUI()
    {
        if (puntaje != null)
        {
            int score = contadorDeDestrucciones.getScore();
            puntaje.text = "Puntaje: " + score.ToString();
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
    // Update is called once per frame
    void Update()
    {
        if (juegoTerminado) return;//cuando esta variable es true no siga ejecutando 
        tiempoRestante -= Time.deltaTime;// disminuir el tiempo
        if (tiempoRestante < 0) tiempoRestante = 0;//juagodor gano
       

     ActualizarTiempoUI ();
        if (tiempoRestante <= 0) Victoria();
        float movimientoX = Input.GetAxisRaw("Horizontal");//obtener el valor del eje horizontal
        float movimientoY = Input.GetAxisRaw("Vertical");//obtener el valor del eje vertical
        direccion = new Vector2(movimientoX, movimientoY).normalized;//normalizar el vector para que no se mueva más rápido en diagonal
        if (Input.GetKeyDown(KeyCode.Space)) //si se presiona la barra espaciadora
        {
            Instantiate(balaprefab, puntoDisparo.position,Quaternion.identity); //instanciar la bala en el punto de disparo
        }
       if (movimientoY > 0) { animator.SetInteger("estado", 1); } //arriba
       if (movimientoY < 0) { animator.SetInteger("estado", -1); } //abajo
         if (movimientoY == 0) { animator.SetInteger("estado", 0); } //quieto
    }

    private void OnTriggerEnter2D(Collider2D collision) //cuando obj entre en colision con otro obj 
    {
        if (collision.CompareTag("meteorito"))
        {
            
            GolpeMeteorito();//llamar al metodo game over
        }

        if (collision.CompareTag ("asteroide"))
        {
            Destroy(gameObject);
            GolpeAsteroide ();
        }
    }

    public void GolpeMeteorito()
    {
        if (juegoTerminado) return;
        vidasRestantes--;
        ActualizarVidasUI ();

        if (vidasRestantes<=0) 
        GameOver();
    }

    public void GolpeAsteroide() { 
    
        if (juegoTerminado) return;
        vidasRestantes = 0;
        GameOver();
    
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direccion * velocidad * Time.fixedDeltaTime);//mover el jugador
    }

    public void GameOver()
    {
        juegoTerminado = true;
        if (panelgameover != null) 
        panelgameover.SetActive(true);//activar el panel de game over
        //Time.timeScale = 0f; // Pausar el juego

    }

    public void Victoria() { 
        juegoTerminado = true;
      if (panelganaste != null)
            panelganaste.SetActive(true);

    
    }

    public void RestartGame()
    {
        //Time.timeScale = 1f; // Reanudar el juego
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name); // Recargar la escena actual
    }

}





