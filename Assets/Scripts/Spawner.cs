using UnityEngine;

public class Spawner : MonoBehaviour

{
    //definmos el tipo de variable es un array de posiciones
   public Transform[] spawnPoints;
    [SerializeField] GameObject meteoritoPrefab;
    [SerializeField] GameObject asteroidePrefab;
    public float spawninterval = 1.5f;         // definimos el intervalo de tiempo entre spawns


    private void Start()
    {
        InvokeRepeating("Spawn", 2.0f, spawninterval); // llama a la funcio spwn , cuanddo va a empezar y cada cuanto tiempo
    }
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


    
}


