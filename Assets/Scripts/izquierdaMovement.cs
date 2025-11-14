using UnityEngine;

public class izquierdaMovement : IMovementStrategy
{
    private float velocidad = 5f; // Velocidad de movimiento del obstáculo

    public izquierdaMovement(float nuevaVelocidad)
    {
        this.velocidad = nuevaVelocidad; // Inicializa la velocidad de movimiento 
    }
    public void Move(Transform transform)
    {
        transform.position += Vector3.left * velocidad * Time.deltaTime; // Mueve el obstáculo hacia la izquierda
    }

}
    