using UnityEngine;

public class movimientodeObstaculos : MonoBehaviour
{
   
   public float velocidad = 5f; // Velocidad de movimiento del obstáculo
    private Transform playerTransform;
    private IMovementStrategy movementStrategy;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;//busca el objeto con la etiqueta "Player" y obtiene su transform
        setMovementStrategy(new izquierdaMovement(velocidad));//le asigna la estrategia de patrullaje al obstaculo
    }

  void  setMovementStrategy (IMovementStrategy strategy)
    {
        movementStrategy = strategy;
    } //va a recibir una estrategia de movimiento y se la asigna a la variable movementStrategy
    void Update()
    {
      /*  if (playerTransform == null)
        {
            return; // Si no se encuentra el jugador, no hacer nada
        }
        transform.position=Vector2.MoveTowards(transform.position, playerTransform.position, velocidad * Time.deltaTime);//anda a atacar al jugador*/
        movementStrategy.Move(transform);//llama al metodo Move de la estrategia de movimiento asignada
    }
}
