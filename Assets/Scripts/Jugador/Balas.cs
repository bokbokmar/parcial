using UnityEngine;

public class Balas : MonoBehaviour
{
    [SerializeField] private int daños;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Destroy(collision.gameObject);
    //    Destroy(this.gameObject);
    //}
}
