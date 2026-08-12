using UnityEngine;

[CreateAssetMenu(fileName = "DatosEnemigos", menuName = "Scriptable Objects/DatosEnemigos")]
public class DatosEnemigos : ScriptableObject
{
    public string nombreEnemigo;
    public int vida;
    public int daño;
    public int armadura;
    public int rango;
    public float velocidad;
    public TipoEnemigo tipo;
    public GameObject prefab;

    public bool auxiliari;

    public TipoEnemigo ReturnEnemigo()
    {
        return tipo;
    }
}

public enum TipoEnemigo { mele, rango, tanque }