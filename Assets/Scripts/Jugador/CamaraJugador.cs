using UnityEngine;

public class CamaraJugador : MonoBehaviour
{
    [SerializeField] private float sensibilidad;
    [SerializeField] private float rotacion;
    private Transform cuerpoJugador;

    private float movX;
    private float movZ;
    [SerializeField] private float velocidad;
    private CharacterController controlJugador;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cuerpoJugador = transform.parent.transform;
        controlJugador = transform.parent.GetComponent<CharacterController>();
    }

    private void Update()
    {
        MoverCamara();
        Moverse();
    }

    private void MoverCamara()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensibilidad;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensibilidad;

        rotacion -= mouseY;
        rotacion = Mathf.Clamp(rotacion, -80, 80);

        transform.localRotation = Quaternion.Euler(rotacion, 0, 0);
        cuerpoJugador.Rotate(Vector3.up * mouseX);
    }

    private void Moverse()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        Vector3 moviemiento = transform.right * movX + transform.forward * movZ;
        moviemiento.y = 0; 

        controlJugador.Move(moviemiento * velocidad * Time.deltaTime);
    }
}
