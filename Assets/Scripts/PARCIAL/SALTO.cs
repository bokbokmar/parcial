using UnityEngine;

public class SALTO : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocidadMovimiento;

    [Header("Salto")]
    public float fuerzaSalto = 7f;
    public float gravedad = 20f;

    [Header("Agacharse")]
    public float escalaAgachado = 0.2f;
    private float escalaOriginalY;
    private float alturaOriginalColisionador;
    private Vector3 centroOriginalColisionador;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Guardamos las dimensiones originales del personaje
        escalaOriginalY = transform.localScale.y;
        alturaOriginalColisionador = controller.height;
        centroOriginalColisionador = controller.center;
    }

    void Update()
    {
        // Aplicar gravedad constante si no está en el suelo
        if (controller.isGrounded)
        {
            velocidadMovimiento.y = -0.5f; // Mantiene al jugador pegado al suelo

            // Acción 1: Saltar (Tecla Flecha Arriba o W)
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                velocidadMovimiento.y = fuerzaSalto;
            }
        }
        else
        {
            // Aplica gravedad en el aire
            velocidadMovimiento.y -= gravedad * Time.deltaTime;
        }

        // Acción 2: Agacharse (Tecla Flecha Abajo o S)
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Agachar(true);
        }
        else
        {
            Agachar(false);
        }

        // Aplicar el movimiento final (solo en el eje Y ya que los obstáculos avanzan hacia él)
        controller.Move(velocidadMovimiento * Time.deltaTime);
    }

    void Agachar(bool estaAgachado)
    {
        // Cambiar escala visual del objeto
        Vector3 escalaActual = transform.localScale;
        escalaActual.y = estaAgachado ? escalaOriginalY * escalaAgachado : escalaOriginalY;
        transform.localScale = escalaActual;

        // Ajustar el colisionador para que los obstáculos altos no lo golpeen
        controller.height = estaAgachado ? alturaOriginalColisionador * escalaAgachado : alturaOriginalColisionador;

        // Ajustar el centro del colisionador para que no se hunda en el suelo al encogerse
        Vector3 nuevoCentro = centroOriginalColisionador;
        if (estaAgachado)
        {
            nuevoCentro.y = centroOriginalColisionador.y * escalaAgachado;
        }
        controller.center = nuevoCentro;
    }
}
