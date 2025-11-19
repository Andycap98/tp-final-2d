using UnityEngine;

public class AgujeroNegro : MonoBehaviour
{
    [SerializeField] private float fuerzaGravitacional = 10f;
    [SerializeField] private float radioInfluencia = 5f;
    [SerializeField] private float velocidadCrecimiento = 0.1f;
    private Transform transformJugador;
    private Rigidbody2D rbJugador;
    void Start()
    {
        GameObject jugadorObj = GameObject.FindWithTag("Player");// Asegúrate de que el jugador tenga la etiqueta "Player"
        if (jugadorObj != null)
        {
            transformJugador = jugadorObj.transform;
            rbJugador = jugadorObj.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += Vector3.one * velocidadCrecimiento * Time.deltaTime;// ir aumentado de tamaño con el tiempo
    }

    private void FixedUpdate()
    {
        if (transformJugador != null && rbJugador != null)
        {
            float distancia = Vector2.Distance(transform.position, transformJugador.position);
            if (distancia < radioInfluencia)
            {
                Vector2 direccion = (transform.position - transformJugador.position).normalized;
                float fuerza = fuerzaGravitacional * (1 - (distancia / radioInfluencia));
                rbJugador.AddForce(direccion * fuerza);
            }
        }
    }
}

