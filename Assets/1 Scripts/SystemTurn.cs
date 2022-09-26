using UnityEngine;
using UnityEngine.Events;   //�R�W�Ŷ�
using TMPro;

namespace WEI
{
    /// <summary>
    /// �^�X�t��:���a�μĤH�^�X�޲z
    /// </summary>
    public class SystemTurn : MonoBehaviour
    {

        #region ���

        private  SystemFinal systemFinal;

        /// <summary>
        /// �ĤH�^�X
        /// </summary>
        public UnityEvent onTurnEnemy;
        /// <summary>
        /// �h�ƼƦr
        /// </summary>
        private TextMeshProUGUI textFloorCount;
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


        private int countMarbleEat;
        /// <summary>
        /// ��l�h��
        /// </summary>
        private int countFloor = 1;

        [SerializeField, Header("��e�h�Ƴ̤j��"), Range(1, 100)]
        private int countFloorMax = 50;
        [SerializeField, Header("�S�����ʪ���åB����ͦ����ɶ�"), Range(0, 3)]
        private float noMoveObjectAndDelaySpawn = 1;

        private bool canSpawn = true;
        private bool isFloorCountMax;

        private void Awake()
        {
            systemControl = GameObject.Find("�ɦ̤l").GetComponent<SystemControl>();
            systemSpawn = GameObject.Find("�ͦ��Ǫ��t��").GetComponent<SystemSpawn>();
            racycleArea = GameObject.Find("�^���ϰ�").GetComponent<RacycleArea>();
            textFloorCount = GameObject.Find("�h�ƼƦr").GetComponent<TextMeshProUGUI>();

            //�^���ϰ�.���D�^���u�]�ƥ�ϧ_���o��.��ť��onRecycle�o���(��RacyInMarble�o���)
            racycleArea.onRecycle.AddListener(RacyInMarble);

            systemFinal = FindObjectOfType<SystemFinal>();
        }


        /// <summary>
        /// �^���u�]
        /// </summary>
        private void RacyInMarble()
        {
            totalCountMarble = systemControl.canShootMarbleTotal;

            totalRacycIeMarble++;
            //print("<Color == yellow>�u�]�`��" + totalRacycIeMarble + "</color>");

            if (totalRacycIeMarble == totalCountMarble)
            {
                //print("�^�������A���ĤH�^�X");
                onTurnEnemy.Invoke();

                //�p�G�S���ĤH�N���ʵ����åͦ��ĤH�P�u�]
                if (FindObjectsOfType<SystemMove>().Length == 0)
                {
                    Invoke("MoveEndSpawnEnemy", noMoveObjectAndDelaySpawn);
                }
            }
        }

        /// <summary>
        /// ���ʵ�����ͦ��}���M�u�]
        /// </summary>
        public void MoveEndSpawnEnemy()
        {
            if (!canSpawn) return;
            if (!isFloorCountMax)
            {
                canSpawn = false;
                systemSpawn.SpawnRandomEnemy();
            }
            Invoke("PlayerTrun", 1);    //1������ �i�����a���s�o�g�u�]�\��
        }

        /// <summary>
        /// ���a�^�X
        /// </summary>
        private void PlayerTrun()
        {
            systemControl.canShootMarble = true;
            canSpawn = true;
            totalRacycIeMarble = 0; //�k�s ���s�p��^���ƶq

            #region �u�]�ƶq�B�z
            systemControl.canShootMarbleTotal += countMarbleEat;
            countMarbleEat = 0;
            #endregion
            if (countFloor < countFloorMax)
            {
                //�קK�Ʀr�b�֥[
                countFloor++;
                textFloorCount.text = countFloor.ToString();
            }
            if (countFloor == countFloorMax) isFloorCountMax = true;

            if (isFloorCountMax)
            {
                if (FindObjectsOfType<SystemMove>().Length == 0)
                {
                    systemFinal.ShowFinalAndUpdateSubTitle("Congratulations on the successful challenge level!");
                    //print("�D�Ԧ��\");
                }
            }
        }
        public void MarbleEat()
        {
            countMarbleEat++;
        }
    }
}
