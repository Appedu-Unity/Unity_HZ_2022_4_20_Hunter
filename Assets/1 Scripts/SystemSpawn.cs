using UnityEngine;
using System.Collections.Generic;   // ��Ƶ��c �M�� List
using System.Linq;                  // �y����X�d��

namespace WEI
{
    /// <summary>
    /// �ͦ��Ǫ��t��
    /// </summary>
    public class SystemSpawn : MonoBehaviour
    {
        #region  ���
        // [] �}�C
        // SerializeField �N�p�H������ 
        [Header("�Ǫ��}�C"),SerializeField] private GameObject[] gaEnemys;
        [Header("�ͦ���l�ĤG�Ʈy��"),SerializeField]private Transform[] traSecondPlace;

        [Header("�ǦC�e��쪺�M��"),SerializeField] private List<Transform> listSceondPlace = new List<Transform>();
        #endregion

        #region  �ƥ�
        private void Awake()
        {
            SpawnRandomEnemy();
        }
        #endregion
        #region  ��k
        /// <summary>
        /// �H���ͦ��ĤH
        /// </summary>
        private void SpawnRandomEnemy()
        {
            int main = 2;                       //��l�ƶq���̤p��
            int max = traSecondPlace.Length - 1;//��l�ƶq���̤j��

            int randomCount = Random.Range(main, max);
            print("���o�H�����Ǫ��ƶq"+randomCount);

            //�M�� = �}�C.�ର�M��();
            listSceondPlace = traSecondPlace.ToList();
            //�s�W�@���H������
            System.Random random = new System.Random();
            // OrderBy �Ƨ�
            // random.Next �H�������
            // �M�� = �M�� �� �Ƨ�(�C�ӲM�椺�e => �H���Ƨ�) �]���M��
            listSceondPlace = listSceondPlace.OrderBy(x => random.Next()).ToList();

            //�n�������ƶq
            int sub = traSecondPlace.Length - randomCount;
            print("�n�������ƶq" + sub);

            // �j�� �R�� �n�������ƶq
            for (int i = 0; i < sub; i++)
            {
                // �R��������Ĥ@����� => 0
                listSceondPlace.RemoveAt(0);
            }
            // �ͦ��Ҧ��Ǫ� �P �u�]
            for (int i = 0; i < listSceondPlace.Count; i++)
            {
                // �p�G i ���� 0 �ͦ��u�]
                if (i == 0)
                {
                    Instantiate(
                    gaMarble,
                    listSceondPlace[i].position,
                    Quaternion.identity);
                }
                else
                {
                // �H���Ǫ�
                int randomIndex = Random.Range(0, gaEnemys.Length);
                // �ͦ��Ǫ�
                Instantiate(
                    gaEnemys[randomIndex],
                    listSceondPlace[i].position,
                    Quaternion.identity);
                }
            }
        }
        #endregion

        [Header("��l �u�]"), SerializeField] private GameObject gaMarble;
    }
}
