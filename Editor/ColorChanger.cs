using UnityEditor;
using UnityEngine;

public class ColorChanger : EditorWindow
{
    public static Material _material;
    public static Color _color = Color.white;
     
    public static Material Material
    {
        get { return _material; }

        set
        {            
            if (value != _material)
            {
                _material = value;
                MaterialChange();
            }
        }
    }

    private static void MaterialChange()
    {
        if (_material)
        {
            _color = Material.color;
        }
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        GUILayout.Label("Настройки материала", EditorStyles.boldLabel);
        GUILayout.Space(10);
        ColorChanger.Material = EditorGUILayout.ObjectField("Материал", _material, typeof(Material)) as Material;
        _color = EditorGUILayout.ColorField("Цвет", _color);
        _color.r = EditorGUILayout.Slider("Красный", _color.r, 0, 1); 
        _color.g = EditorGUILayout.Slider("Зеленый", _color.g, 0, 1);
        _color.b = EditorGUILayout.Slider("Синий", _color.b, 0, 1);
        var button = GUILayout.Button("Сохранить");
        EditorGUILayout.EndVertical();
        if (button)
        {
            if (_material)
            {
                _material.color = _color;
            }
            else ShowNotification(new GUIContent("Нет материала что бы изменить его цвет"));
        }
    }
}
