using UnityEngine;

namespace WEI
{
    /// <summary>
    /// �����t��
    /// </summary>
    public class SystemAttack : MonoBehaviour
    {
        [SerializeField, Header("�������")]
        private DataAttack dataAttack;
        /// <summary>
        /// �����ƭ�
        /// </summary>
        public float valueAttack;

        private void Awake()
        {
            // �����ƭ� = �����O + �d�� (-�����B�I�� , +�����B�I��)
            // �Ҧp: �����ƭ� = 100 + (-10, 10):�d�򸨦b 90~100
            valueAttack = dataAttack.attack - Random.Range(-dataAttack.attackFloat, dataAttack.attackFloat);
            valueAttack = Mathf.Floor(valueAttack);
        }
    }
}