using UnityEngine;
using System.Collections;
using TMPro;

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
        [Header("����t��"), Range(0, 500)]
        public float speedTurn = 10.5f;
        [Header("�u�]����")]
        public GameObject marble;
        [Header("�u�]�i�o�g�`��"), Range(0, 1000)]
        public int canShootMarbleTotal = 15;
        [Header("�u�]�ͦ��I")]
        public Transform traSpawnPoint;
        [Header("�������ѼƦW��")]
        private string parAttack = "Ĳ�o����";
        [Header("�u�]�o�g�t��"), Range(0, 5000)]
        private float speedMarble = 1000;
        [Header("�u�]�o�g���j"), Range(0, 10)]
        public float intervalMarble = 0.1f;
        [Header("�u�]�ƶq")]
        public TextMeshProUGUI textMableCount;

        private Animator ani;
        /// <summary>
        /// ��_�o�g�u�]
        /// </summary>
        private bool canShootMarble = true;
        /// <summary>
        /// �ഫ�ƹ�����v��
        /// </summary>
        private Camera cameraMouse;
        /// <summary>
        /// �y���ഫ����骫��
        /// </summary>
        private Transform traMouse;
        #endregion

        #region �ƥ�
        /// <summary>
        /// Awake�|�bStart�e����@��
        /// </summary>
        private void Awake()
        {
            ani = GetComponent<Animator>();
            textMableCount.text = "X" + canShootMarbleTotal;

            cameraMouse = GameObject.Find("�ഫ�ƹ��Ϊ���v��").GetComponent<Camera>();
            traMouse = GameObject.Find("�y���ഫ����骫��").transform;
        }

        private void Update()
        {
            ShootMarbleTotal();
            TurnChsrscter();
        }
        #endregion

        #region ��k
        /// <summary>
        /// �������
        /// </summary>
        private void TurnChsrscter()
        {
            // �p�G ����o�g �N���X
            if (!canShootMarble) return;
            
            // 1.�ƹ��y��
            Vector3 posMouse = Input.mousePosition;
            print("<clor=yellow>�ƹ��y��:" + posMouse + "</color>");
            // ����v���� Y �b�@��
            posMouse.z = 25;
            // 2.�ƹ��y���ର�@�ɮy��
            Vector3 pos = cameraMouse.ScreenToWorldPoint(posMouse);
            pos.y = 1.5f;
            // 3.�@�ɮy�е����骫��
            traMouse.position = pos;
            //  �������ܧΡA���V(�y���ഫ����骫��)
            transform.LookAt(traMouse);

        }
        /// <summary>
        /// �o�g�u�]
        /// </summary>
        private void ShootMarbleTotal()
        {
            if (!canShootMarble) return;

            // �ƹ����U����� �b�Y���
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                arrow.SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                // ����o�g�u�]
                canShootMarble = false;

                arrow.SetActive(false);
                StartCoroutine(SpawnMarble());
            }
        }
        /// <summary>
        /// �ͦ��u�]���a���j�ɶ�
        /// </summary>
        /// <returns></returns>
        private IEnumerator SpawnMarble()
        {
            int total = canShootMarbleTotal;
            for (int i = 0; i < canShootMarbleTotal; i++)
            {
                ani.SetTrigger(parAttack);
                //print("��}����");
                // �b�Y����
                arrow.SetActive(true);
                // Object ���O�i�ٲ����g
                // �����z�LObject�����W�٨ϥ�
                // �ͦ�(�u�])
                // Quaternion.identity �s�ר�
                GameObject tempMarble = Instantiate(marble, traSpawnPoint.position, Quaternion.identity);
                // ���s�u�] ���o���餸�� �K�[���O(�}��.�e��*�t��)
                // transform.forward �}�⪺�e��
                tempMarble.GetComponent<Rigidbody>().AddForce(transform.forward * speedMarble);

                total--;

                if (total > 0) textMableCount.text = "X" + total;
                else if (total == 0) textMableCount.text = "";


                yield return new WaitForSeconds(intervalMarble);

            }
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