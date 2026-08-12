using UnityEngine;
using UnityEngine.AI;

public class ENEMIGO : MonoBehaviour, Dañable
{
    [SerializeField] private DatosEnemigos datitos;
    [SerializeField] private int vida;
    private int coraza;
    public Transform objetivo;

    private NavMeshAgent agente;
    [SerializeField] private bool objetivoAlcanzado;
    public ControladorJuego controladorcete;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.speed = datitos.velocidad;
        vida = datitos.vida;
        Debug.Log(datitos.tipo);
        switch (datitos.tipo)
        {
            case TipoEnemigo.mele:
                {
                    //Estos enemigos atacan como cuando los Hunos invadieron Roma
                    //De Huno en Huno
                    break;
                }

            case TipoEnemigo.rango:
                {
                    agente.stoppingDistance = datitos.rango;
                    break;
                }

            case TipoEnemigo.tanque:
                {
                    coraza = datitos.armadura;
                    break;
                }
        }
    }

    private void Update()
    {
        if (objetivo != null)
        {
            agente.destination = objetivo.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            other.GetComponent<Dañable>().RecibirDaño(datitos.daño);
        }
    }

    public void RecibirDaño(int daños)
    {
        daños = daños - coraza;
        vida = vida - daños;
        if (vida <= 0)
        {
            controladorcete.enemigosPorMatar--;
            Destroy(gameObject);
        }
    }
}
