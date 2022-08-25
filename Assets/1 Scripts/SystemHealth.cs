using UnityEngine;
using UnityEngine.UI;   //����    
using TMPro;            //TMP����r����

namespace WEI
{
    /// <summary>
    /// ��q�t��:��s��q�B�����P���`�B�z
    /// </summary>
    public class SystemHealth : MonoBehaviour
    {
        #region ���
        [Header("�e���ˮ`����"), SerializeField] private GameObject goDamage;
        [Header("�Ϥ���q"), SerializeField] private Image imgHP;
        [Header("��r��q"), SerializeField] private TextMeshProUGUI textHP;
        [Header("�Ǫ����"), SerializeField] private DataEnemy dataEnemy;
        [Header("�Ǫ��ʵe���"), SerializeField] private Animator aniEnemy;

        private float hp;
        private string parDamage = "Ĳ�o";
        #endregion

        private SystemSpawn systemSpawn;

        private void Awake()
        {
            hp = dataEnemy.hp;
            textHP.text = hp.ToString();    //�@�}�l����r��s�A�i�b�@�}�l�N���Data���
            systemSpawn = GameObject.Find("�ͦ��Ǫ��t��").GetComponent<SystemSpawn>();
        }
        // �I���ƥ�
        // 1. ��Ӫ��󥲶����@�ӱa�� Rigidbody
        // 2. ��Ӫ��󥲶����I����   Collider
        // 3. �O�_���Ŀ� Is Trigger
        private void OnCollisionEnter(Collision collision)
        {
            //print("�I���쪺����:" + collision.gameObject);
            GetDamage();
        }
        /// <summary>
        /// ����
        /// </summary>
        private void GetDamage()
        {
            float getDamage = 50;
            hp -= getDamage;
            //print("��q�ѤU" + hp);
            textHP.text = hp.ToString();    //�N��q�ഫ����r
            imgHP.fillAmount = hp / dataEnemy.hp;   //�N��q�ʤ����ର���I�ƨù�W�۹���������Ϥ��ܤ�
            aniEnemy.SetTrigger(parDamage); //������˰ʵe
            Vector3 pos = transform.position + Vector3.up;
            SystemDamage tempDamage = Instantiate(goDamage, pos, Quaternion.Euler(50, 0, 0)).GetComponent<SystemDamage>();
            tempDamage.damage = getDamage;  //��s�ˮ`��

            if (hp <= 0)
            {
                Dead();
            }
        }

        private void Dead()
        {
            //print("���`");
            Destroy(gameObject);
            systemSpawn.totalCountEnemylive--;
            DropCoin();
        }
        /// <summary>
        /// ��������
        /// </summary>
        private void DropCoin()
        {
            int range = Random.Range(dataEnemy.vector2Int.x, dataEnemy.vector2Int.y);
            for (int i = 0; i < range; i++)
            {
                //�H���e�ᥪ�k
                float x = Random.Range(-1, 1);
                float z = Random.Range(-1, 1);

                Instantiate(
                    dataEnemy.goCoin,
                    transform.position + new Vector3(0, 2.5f, z),
                    Quaternion.Euler(90, 180, 0));
            }
        }

    }
}