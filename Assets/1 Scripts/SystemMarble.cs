using UnityEngine;

namespace WEI
{
    public class SystemMarble : MonoBehaviour
    {
        [SerializeField, Header("�Ǫ��ϼh")]
        private LayerMask layerEnemy;
        [SerializeField, Header("�X�����S�I��Ǫ��n�^��"), Range(0, 10)]
        private float timeRecycle = 5;
        [SerializeField, Header("�^���t��")]
        private Vector3 V3SpeedRecycle;

        private float timer;
    }

}
