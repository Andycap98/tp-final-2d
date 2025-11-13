using UnityEngine;

public class movimientoJugador : MonoBehaviour
{
    // crear un atributo velocidad de tipo float
    [SerializeField] float velocidad = 5.0f;
    Rigidbody2D rb;//sirve para controlar el movimiento del jugador
    Vector2 direccion;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//decirle al script que obtenga el componente Rigidbody2D del objeto al que está adjunto
        rb.gravityScale = 0;//para que no afecte la gravedad al jugador
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoX = Input.GetAxisRaw("Horizontal");//obtener el valor del eje horizontal
        float movimientoY = Input.GetAxisRaw("Vertical");//obtener el valor del eje vertical
        direccion = new Vector2(movimientoX, movimientoY).normalized;//normalizar el vector para que no se mueva más rápido en diagonal
        
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direccion * velocidad * Time.fixedDeltaTime);//mover el jugador
    }


}





