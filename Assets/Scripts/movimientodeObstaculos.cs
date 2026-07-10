using UnityEngine;

public class movimientodeObstaculos : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento del obstáculo
    private Transform playerTransform;
    private IMovementStrategy movementStrategy;
    private Animator animator;
    private bool destruido = false;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;//busca el objeto con la etiqueta "Player" y obtiene su transform
        setMovementStrategy(new izquierdaMovement(velocidad));//le asigna la estrategia de patrullaje al obstaculo
        animator = GetComponent<Animator>();
    }

    void setMovementStrategy(IMovementStrategy strategy)
    {
        movementStrategy = strategy;
        //va a recibir una estrategia de movimiento y se la asigna a la variable movementStrategy

    }
        void Update()
        {
            if (destruido)
                return;

            if (movementStrategy != null)
            {
                movementStrategy.Move(transform);
            }
        }

    public void RecibirDisparo()
    {
        if (destruido)
            return;

        destruido = true;

        animator.SetTrigger("Destroy"); // Debe existir un Trigger llamado "Destroy"

        GetComponent<Collider2D>().enabled = false;

       // Destroy(gameObject, 0.6f);
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }
}