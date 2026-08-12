using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Generador : MonoBehaviour
{
    public List<DatosOleadas> todasLasOleadas;
    public Transform[] puntosAparicion;
    [SerializeField] private int oleadaActual;
    //[SerializeField] private float esperaEntreEnemigos;
    [SerializeField] private int enemigosRestantes;
    public int enemigosPorMatar;

    [SerializeField] private Transform jugador;
    private ControladorJuego controladorcito;

    private void Start()
    {
        if (ControladorJuego.controlador != null)
        {
            controladorcito = ControladorJuego.controlador;
        }

        for (int i = 0; i < todasLasOleadas.Count; i++)
        {
            enemigosPorMatar = enemigosPorMatar + todasLasOleadas[i].cantidad;
        }
        //controladorcito.enemigosPorMatar = enemigosPorMatar;
        StartCoroutine(IniciarOleada());
    }

    IEnumerator IniciarOleada()
    {
        if (oleadaActual >= todasLasOleadas.Count)
        {
            Debug.Log("VICTORIA");
            //controladorcito.CambiarEstado(ControladorJuego.EstadoJuego.FinDelJuego);
            yield break;
        }

        DatosOleadas oleadaActualAuxiliari = todasLasOleadas[oleadaActual];
        enemigosRestantes = oleadaActualAuxiliari.cantidad;

        for (int i = 0; i < oleadaActualAuxiliari.cantidad; i++)
        {
            int auxiliari = Random.Range(0, 3);
            int auxiliari2 = Random.Range(0, 3);
            GameObject clon = Instantiate(oleadaActualAuxiliari.listaEnemigos[auxiliari].prefab, puntosAparicion[auxiliari2].position, puntosAparicion[auxiliari2].rotation);
            clon.GetComponent<ENEMIGO>().objetivo = jugador;
            clon.GetComponent<ENEMIGO>().controladorcete = controladorcito;
            enemigosRestantes--;
            yield return new WaitForSeconds(2f);
        }

        Debug.Log("Fin de oleada " + oleadaActual);
        yield return new WaitForSeconds(5f);
        Debug.Log("Inicio de oleada " + oleadaActual);
        oleadaActual++;

        StartCoroutine(IniciarOleada());
    }
}
