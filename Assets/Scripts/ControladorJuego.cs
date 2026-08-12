using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    public static ControladorJuego controlador;
    public GameState estadoActual;
    public int enemigosPorMatar;

    private void Awake()
    {
        if (controlador == null)
        {
            controlador = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (controlador != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        //CambiarEstado(EstadoJuego.MenuPrincipal);
        enemigosPorMatar = -1;
    }

    private void Update()
    {
        if (enemigosPorMatar == 0)
        {
            CambiarEstado(GameState.FinDelJuego);
        }
    }

    public void CambiarEstado(GameState nuevoEstado)
    {
        estadoActual = nuevoEstado;

        switch (estadoActual)
        {
            case GameState.MainMenu:
                {
                    SceneManager.LoadScene("MenuInicio");
                    break;
                }

            case GameState.Play:
                {
                    SceneManager.LoadScene("Jueguito");
                    Debug.Log("Cambio a " + estadoActual);
                    break;
                }

            case GameState.Pausa:
                {
                    break;
                }

            case GameState.FinDelJuego:
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    SceneManager.LoadScene("PantallaFinal");
                    break;
                }
        }
    }

    public enum GameState
    {
        MainMenu,
        Play,
        Pausa,
        FinDelJuego
    }
}
