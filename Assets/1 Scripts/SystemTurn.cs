using UnityEngine;
using UnityEngine.Events;   //�R�W�Ŷ�

namespace WEI
{
    /// <summary>
    /// �^�X�t��:���a�μĤH�^�X�޲z
    /// </summary>
    public class SystemTurn : MonoBehaviour
    {
        /// <summary>
        /// �ĤH�^�X
        /// </summary>
        public UnityEvent onTurnEnemy;

        #region ���
        [Header("�u�]���")] private SystemControl systemControl;
        [Header("�ͦ��Ǫ��t��")] private SystemSpawn systemSpawn;
        [Header("�^���ϰ�")] private RacycleArea racycleArea;

        /// <summary>
        /// �u�]���`��
        /// </summary>
        private int totalCountMarble;
        /// <summary>
        /// �Ǫ����s���`��
        /// </summary>
        private int totalCountEnemylive;
        /// <summary>
        /// �^���u�]�ƶq
        /// </summary>
        private int totalRacycIeMarble;
        #endregion

        private bool canSpawn = true;

        private void Awake()
        {
            systemControl = GameObject.Find("�ɦ̤l").GetComponent<SystemControl>();
            systemSpawn = GameObject.Find("�ͦ��Ǫ��t��").GetComponent<SystemSpawn>();
            racycleArea = GameObject.Find("�^���ϰ�").GetComponent<RacycleArea>();

            //�^���ϰ�.���D�^���u�]�ƥ�ϧ_���o��.��ť��onRecycle�o���(��RacyInMarble�o���)
            racycleArea.onRecycle.AddListener(RacyInMarble);
        }
        private void RacyInMarble()
        {
            totalCountMarble = systemControl.canShootMarbleTotal;

            totalRacycIeMarble++;
            print("<Color == yellow>�u�]�`��" + totalRacycIeMarble + "</color>");

            if (totalRacycIeMarble == totalCountMarble)
            {
                print("�^�������A���ĤH�^�X");
                onTurnEnemy.Invoke();
            }
        }

        /// <summary>
        /// ���ʵ�����ͦ��}���M�u�]
        /// </summary>
        public void MoveEndSpawnEnemy()
        {
            if (!canSpawn) return;

            canSpawn = false;
            systemSpawn.SpawnRandomEnemy();
            Invoke("PlayerTrun", 1);    //1������ �i�����a���s�o�g�u�]�\��
        }
        /// <summary>
        /// �i�����a���s�o�g�u�]
        /// </summary>
        private void PlayerTrun()
        {
            systemControl.canShootMarble = true;
            canSpawn = true;
            totalRacycIeMarble = 0; //�k�s ���s�p��^���ƶq
        }
    }
}
