// Movimiento en patrulla horizontal
using UnityEngine;

public class PatrullajeMovement : IMovementStrategy
{
    private float speed = 2f;
    private float distance = 5f;
    private Vector3 startPos;
    private int direction = 1;

    public PatrullajeMovement(Vector3 startPosition)
    {
        startPos = startPosition;
    }

    public void Move(Transform transform)
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x - startPos.x) > distance)
        {
            direction *= -1;
        }
    }
}
