using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaJugador : MonoBehaviour, Dañable
{
    [SerializeField] private int vidaMáxima;
    [SerializeField] private ControladorJuego controladorcito;

    private void Start()
    {
        if (ControladorJuego.controlador != null)
        {
            controladorcito = ControladorJuego.controlador;
        }
    }

    public void RecibirDaño(int daños)
    {
        vidaMáxima = vidaMáxima - daños;
        if (vidaMáxima <= 0)
        {
            controladorcito.CambiarEstado(ControladorJuego.GameState.Play);
            Destroy(gameObject);
        }
    }
}
