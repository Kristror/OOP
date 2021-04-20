using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TestEnemy))]
public class KeyEditor : UnityEditor.Editor
{
    private bool _isPressButtonOk;

    public override void OnInspectorGUI()
    {
        TestEnemy testTarget = (TestEnemy)target;

        testTarget._hp = EditorGUILayout.IntField("��������", testTarget._hp);
        testTarget._isAlive = EditorGUILayout.Toggle("���", testTarget._isAlive);
        testTarget._damage = EditorGUILayout.IntField("����", testTarget._damage);
        testTarget._rechargeAttack = EditorGUILayout.FloatField("����������� �����", testTarget._rechargeAttack);
        testTarget._speed = EditorGUILayout.Slider("��������", testTarget._speed, 5, 50);
    }
}