using UnityEngine;

public class movimientodeObstaculos : MonoBehaviour
{
   
    public float velocidad = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);//Movimiento del obstaculo hacia la izquierda
    }
}
