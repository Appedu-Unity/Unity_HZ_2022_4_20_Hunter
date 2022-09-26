using UnityEngine;

namespace WEI
{
    public class SystemMarble : MonoBehaviour
    {
        [SerializeField, Header("怪物圖層")]
        private LayerMask layerEnemy;
        [SerializeField, Header("幾秒鐘沒碰到怪物要回收"), Range(0, 10)]
        private float timeRecycle = 5;
        [SerializeField, Header("回收速度")]
        private Vector3 V3SpeedRecycle;

        private float timer;
    }

}
