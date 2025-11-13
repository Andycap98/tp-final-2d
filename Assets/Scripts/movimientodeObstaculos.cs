using UnityEngine;

public class movimientodeObstaculos : MonoBehaviour
{
   
   public float velocidad = 5f; // Velocidad de movimiento del obstáculo
    private Transform playerTransform;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;//busca el objeto con la etiqueta "Player" y obtiene su transform
    }
    void Update()
    {
        if (playerTransform == null)
        {
            return; // Si no se encuentra el jugador, no hacer nada
        }
        transform.position=Vector2.MoveTowards(transform.position, playerTransform.position, velocidad * Time.deltaTime);//anda a atacar al jugador
    }
}
