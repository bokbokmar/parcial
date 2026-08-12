using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]

[CreateAssetMenu(fileName = "DatosOleadas", menuName = "SistemaOleadas/DatosOleadas")]
public class DatosOleadas : ScriptableObject
{
    public string nombreOleada;
    public List<DatosEnemigos> listaEnemigos = new List<DatosEnemigos>(3);
    public float esperaEntreEnemigos = 1f;
    public int cantidad;
}
