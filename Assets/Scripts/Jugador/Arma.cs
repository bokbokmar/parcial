using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] private GameObject bala;
    [SerializeField] private Transform puntoDisparito;
    [SerializeField] private float fuerza;

    private void Start()
    {
        puntoDisparito = transform.GetChild(0).transform;
    }

    private void Update()
    {
        Disparar();
    }

    private void Disparar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject balita = Instantiate(bala, puntoDisparito.position, puntoDisparito.rotation);
            Rigidbody rbBala = balita.GetComponent<Rigidbody>();
            rbBala.AddForce(puntoDisparito.forward * fuerza);
            Destroy(balita,5f);
        }
    }
}
