using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TestEnemy))]
public class KeyEditor : UnityEditor.Editor
{
    private bool _isPressButtonOk;

    public override void OnInspectorGUI()
    {
        TestEnemy testTarget = (TestEnemy)target;

        testTarget._hp = EditorGUILayout.IntField("Здоровье", testTarget._hp);
        testTarget._isAlive = EditorGUILayout.Toggle("Жив", testTarget._isAlive);
        testTarget._damage = EditorGUILayout.IntField("Урон", testTarget._damage);
        testTarget._rechargeAttack = EditorGUILayout.FloatField("Перезарядка удара", testTarget._rechargeAttack);
        testTarget._speed = EditorGUILayout.Slider("Скорость", testTarget._speed, 5, 50);
    }
}