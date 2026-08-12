using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private ControladorJuego controladorcito;
    [SerializeField] private GameObject canvasPausa;
    private bool juegoPausado;

    private void Start()
    {
        if (ControladorJuego.controlador != null)
        {
            controladorcito = ControladorJuego.controlador;
        }

        //canvasPausa = this.gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        Time.timeScale = 0f;
        canvasPausa.SetActive(true);
        juegoPausado = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Continuar()
    {
        Time.timeScale = 1f;
        canvasPausa.SetActive(false);
        juegoPausado = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        canvasPausa.SetActive(false);
        juegoPausado = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //SceneManager.LoadScene("MenuInicio");
        controladorcito.CambiarEstado(ControladorJuego.GameState.MainMenu);
    }
}
