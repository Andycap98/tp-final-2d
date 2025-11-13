using UnityEngine;

public class SpawnerNivel1 : MonoBehaviour
{
    [SerializeField] GameObject meteoritoPrefab;
    [SerializeField] GameObject asteroidePrefab;
    [SerializeField] float ancho = 8f;          // rango horizontal
    [SerializeField] float cadaSegundos = 1.2f; // frecuencia de aparición
    [SerializeField, Range(0f, 1f)] float probMeteorito = 0.7f; // 70% mete, 30% ast

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0.5f, cadaSegundos);
    }

    void Spawn()
    {
        float x = Random.Range(-ancho * 0.5f, ancho * 0.5f);
        Vector3 pos = new Vector3(x, transform.position.y, 0);

        GameObject prefab = (Random.value <= probMeteorito) ? meteoritoPrefab : asteroidePrefab;
        Instantiate(prefab, pos, Quaternion.identity);
    }
}


