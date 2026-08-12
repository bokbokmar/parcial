using UnityEngine;

public class MOV : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody rb;
    private CharacterController controller;
    private float movZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        movZ = Input.GetAxis("Vertical");

        Vector3 moviemiento = transform.forward * movZ;
        moviemiento.y = 0;
        moviemiento.x = 0;

        controller.Move(moviemiento * velocidad * Time.deltaTime);
    }
}
