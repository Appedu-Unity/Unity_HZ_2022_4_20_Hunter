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
        [Header("�e���ˮ`����"), SerializeField] private GameObject goDamage;
        [Header("�Ϥ���q"), SerializeField] private Image imgHP;
        [Header("��r��q"), SerializeField] private TextMeshProUGUI textHP;

        // �I���ƥ�
        // 1. ��Ӫ��󥲶����@�ӱa�� Rigidbody
        // 2. ��Ӫ��󥲶����I����   Collider
        // 3. �O�_���Ŀ� Is Trigger
        private void OnCollisionEnter(Collision collision)
        {
            print("�I���쪺����:" + collision.gameObject);
        }

    }
}