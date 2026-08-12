using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstaculo : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        // Mueve el objeto hacia la izquierda (ajusta Vector3.left según tu eje de juego)
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            SceneManager.LoadScene("Parcial1");
        }
    }
}
