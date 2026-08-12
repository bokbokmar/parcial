using UnityEditor;

[CustomEditor(typeof(DatosEnemigos))]
public class DatosEnemigosEditor : Editor
{
    SerializedProperty _nombre;
    SerializedProperty _vida;
    SerializedProperty _daño;
    SerializedProperty _tipo;
    SerializedProperty _armadura;
    SerializedProperty _velocidad;
    SerializedProperty _rango;
    SerializedProperty _prefab;

    public void OnEnable()
    {
        _tipo = serializedObject.FindProperty("tipo");
        _vida = serializedObject.FindProperty("vida");
        _daño = serializedObject.FindProperty("daño");
        _armadura = serializedObject.FindProperty("armadura");
        _velocidad = serializedObject.FindProperty("velocidad");
        _rango = serializedObject.FindProperty("rango");
        _nombre = serializedObject.FindProperty("nombreEnemigo");
        _prefab= serializedObject.FindProperty("prefab");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Configuración General", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_nombre);
        EditorGUILayout.PropertyField(_vida);
        EditorGUILayout.PropertyField(_daño);
        EditorGUILayout.PropertyField(_velocidad);
        EditorGUILayout.PropertyField(_prefab);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Categoría de Enemigo", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_tipo);
        EditorGUILayout.Space();

        TipoEnemigo tipoActual = (TipoEnemigo)_tipo.enumValueIndex;

        switch (tipoActual)
        {
            case TipoEnemigo.mele:
                {
                    EditorGUILayout.HelpBox("Datos Guerreros", MessageType.None);
                    EditorGUILayout.HelpBox("Los guerreros no tienen especialidad", MessageType.Info);
                    break;
                }

            case TipoEnemigo.rango:
                {
                    EditorGUILayout.HelpBox("Datos Jabalineros", MessageType.None);
                    EditorGUILayout.PropertyField(_rango);
                    break;
                }

            case TipoEnemigo.tanque:
                {
                    EditorGUILayout.HelpBox("Datos Tanques", MessageType.None);
                    EditorGUILayout.PropertyField(_armadura);
                    break;
                }
        }


        serializedObject.ApplyModifiedProperties();
    }
}
