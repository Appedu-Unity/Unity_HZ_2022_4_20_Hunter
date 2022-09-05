using UnityEngine;

namespace WEI
{
    /// <summary>
    /// �������
    /// </summary>
    [CreateAssetMenu(menuName = "WEI/Data Attack",fileName ="Data Attack")]
    public class DataAttack : ScriptableObject
    {
        [Header("�����O"),Range(0,10000)]
        public float attack;
        [Header("�����O�B��"),Range(0,100)]
        public float attackFloat;
    }
}