using UnityEngine;

public class movimientoBala : MonoBehaviour
{
    public float velocidadBala = 10f; // Velocidad de la bala

    // NUEVO: dirección configurable (por defecto hacia la derecha)
    private Vector2 direccion = Vector2.right;

    // Este método lo llama movimientoJugador justo después de instanciar la bala
    public void SetDireccion(Vector2 nuevaDireccion)
    {
        if (nuevaDireccion != Vector2.zero)
            direccion = nuevaDireccion.normalized;
        else
            direccion = Vector2.right; // seguridad por si viene cero
    }

    void Update()
    {
        // Mover la bala en la dirección actual
        transform.Translate(direccion * velocidadBala * Time.deltaTime);

        // Si se va demasiado lejos, destruirla (para evitar basura en la escena)
        if (transform.position.magnitude > 30f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("meteorito"))
        {
            movimientodeObstaculos meteorito =
                collision.GetComponent<movimientodeObstaculos>();

            if (meteorito != null)
            {
                meteorito.RecibirDisparo();
            }

            Destroy(gameObject);
            contadorDeDestrucciones.sumarScore();
        }

        if (collision.CompareTag("asteroide"))
        {
            movimientodeObstaculos asteroide =
                collision.GetComponent<movimientodeObstaculos>();

            if (asteroide != null)
            {
                asteroide.RecibirDisparo();
            }

            Destroy(gameObject);
            contadorDeDestrucciones.sumarScore();
        }
    }
}
    
