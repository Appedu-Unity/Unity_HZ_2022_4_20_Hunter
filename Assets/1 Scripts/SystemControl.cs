using UnityEngine;

//  �R�W�Ŷ� namespace �Ŷ��W�� { �ӪŶ������e }
namespace WEI
{
    /// <summary>
    /// ���a����t��
    /// �������B�o�g�u�]
    /// </summary>
    public class SystemControl : MonoBehaviour
    {
        #region ���
        [Header("�b�Y����")]
        public GameObject arrow;
        [Header("����t��"),Range(0,500)]
        public float speedTurn = 10.5f;
        [Header("�u�]����")]
        public GameObject marble;
        [Header("�u�]�i�o�g�`��"),Range(0, 1000)]
        public int canShootMarbleTotal = 15;
        #endregion

        #region �ƥ�
        #endregion

        #region ��k
        /// <summary>
        /// �������
        /// </summary>
        private void TurnChsrscter()
        { 
        }
        /// <summary>
        /// �o�g�u�]
        /// </summary>
        private void ShootMarbleTotal()
        { 
        }
        /// <summary>
        /// �^���u�]
        /// </summary>
        private void RecycleMarble()
        { 
        }
        #endregion
    }
}