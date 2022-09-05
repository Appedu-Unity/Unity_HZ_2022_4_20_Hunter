using UnityEngine;

namespace WEI
{
    /// <summary>
    /// 攻擊資料
    /// </summary>
    [CreateAssetMenu(menuName = "WEI/Data Attack",fileName ="Data Attack")]
    public class DataAttack : ScriptableObject
    {
        [Header("攻擊力"),Range(0,10000)]
        public float attack;
        [Header("攻擊力浮動"),Range(0,100)]
        public float attackFloat;
    }
}