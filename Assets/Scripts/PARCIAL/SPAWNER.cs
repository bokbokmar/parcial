using UnityEngine;

public class SPAWNER : MonoBehaviour
{
    public GameObject prefabObstaculo;
    public float tiempoGeneracion = 2f;
    private float cronometro = 0f;

    public Transform[] puntosAparicion;

    void Update()
    {
        cronometro += Time.deltaTime;

        if (cronometro >= tiempoGeneracion)
        {
            GenerarObstaculo();
            cronometro = 0f;
        }
    }

    void GenerarObstaculo()
    {
        // Crea el obstáculo en la posición del Spawner
        int numero = Random.Range(0, 2);
        Instantiate(prefabObstaculo, puntosAparicion[numero].position, Quaternion.identity);
    }
}
