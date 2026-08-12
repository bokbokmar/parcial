using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    [SerializeField] private ControladorJuego controlador;

    public void Iniciar()
    {
        controlador.CambiarEstado(ControladorJuego.GameState.Play);
        //SceneManager.LoadScene("Jueguito");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
