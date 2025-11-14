using UnityEngine;

public class movimientoBala : MonoBehaviour
{
   public float velocidadBala = 10f; // Velocidad de la bala

   
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velocidadBala * Time.deltaTime); // Mover la bala hacia la derecha
        if(transform.position.x > 20f) // Si la bala sale de la pantalla
        {
            Destroy(gameObject); // Destruir la bala
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("enemigo")) // Si la bala colisiona con un enemigo
        {
            Destroy(collision.gameObject); // Destruir el enemigo
            Destroy(gameObject); // Destruir la bala
        }
    }
}
