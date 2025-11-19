using UnityEngine;

public class Spawner : MonoBehaviour

{
    //definmos el tipo de variable es un array de posiciones
   public Transform[] spawnPoints;
    [SerializeField] GameObject meteoritoPrefab;
    [SerializeField] GameObject asteroidePrefab;
    public float spawninterval = 1.5f;         // definimos el intervalo de tiempo entre spawns
    private float timer = 0f;                  // definimos un temporizador para controlar el tiempo transcurrido

    
    void Spawn()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        int prefabIndex = Random.Range(0, 2); // Genera un número aleatorio entre 0 y 1
        if (prefabIndex == 0)
        {
            Instantiate(asteroidePrefab, spawnPoint.position, Quaternion.identity);//voy a instanciar el asteroide en la posicion y rotacion del spawnpoint seleccionado
            return;
        }
        Instantiate(meteoritoPrefab, spawnPoint.position, Quaternion.identity);//voy a instanciar el meteorito en la posicion y rotacion del spawnpoint seleccionado

    }


    private void Update()
    {
        timer += Time.deltaTime; // Incrementa el temporizador con el tiempo transcurrido desde el último frame
        if (timer > spawninterval)

        {
            Spawn(); // Llama a la función Spawn para crear un nuevo meteorito}
            timer = 0f; // Reinicia el temporizador
            spawninterval = Random.Range(0.1f, 2f); // Actualiza el intervalo de spawn a un valor aleatorio entre 1 y 3 segundos
        }
    }
}


