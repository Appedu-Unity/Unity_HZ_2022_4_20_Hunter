using UnityEngine;

namespace WEI
{
    /// �}���ƪ��� ScriptableObject:�}�����e�ܦ������Ʀs��b Project ��
    /// �����f�t CreateAssetMenu
    [CreateAssetMenu(menuName ="WEI/Data Enemy",fileName ="Data Enemy")]
    public class DataEnemy : ScriptableObject
    {
        [Header("��q"), Range(0, 10000)] public float hp;
        [Header("�ˮ`"), Range(0, 10000)] public float damage;
        [Header("���������w�s��")] public GameObject goCoin;
        [Header("���������d��")] public Vector2Int vector2Int;
    }
}