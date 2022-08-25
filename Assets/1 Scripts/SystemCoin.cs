using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WEI {
    public class SystemCoin : MonoBehaviour
    {
        [Header("���𭸦�"), Range(0, 2), SerializeField] private float delayFly = 1.5f;
        [Header("����t��"), Range(0, 10), SerializeField] private float speed = 1.5f;
        /// <summary>
        /// �����n�e������m
        /// </summary>
        private Transform traCoinFlyTo;
        /// <summary>
        /// �}�l����
        /// </summary>
        private bool startFly;

        private ManagerCoin managerCoin;

        private void Awake()
        {
            Physics.IgnoreLayerCollision(6, 3);
            Physics.IgnoreLayerCollision(6, 6);
            Physics.IgnoreLayerCollision(6, 7);

            traCoinFlyTo = GameObject.Find("�����n���e����m").transform;
            managerCoin = GameObject.Find("�����޲z��").GetComponent<ManagerCoin>();

            Invoke("StartFly", delayFly);
        }
        private void Update()
        {
            Fly();
        }
        /// <summary>
        /// �}�l����
        /// </summary>
        private void StartFly()
        {
            startFly = true;
        }
        private void Fly()
        {
            if (!startFly) return;

            // ���� : �N A B ��Ӽƭȧ�X���������w��m
            Vector3 traCoin = transform.position;
            Vector3 traCoinTo = traCoinFlyTo.position;

            traCoin = Vector3.Lerp(traCoin, traCoinTo, 100);
            transform.position = traCoin;

            DestroyCoin();
        }
        private void DestroyCoin()
        {
            float dis = Vector3.Distance(transform.position, traCoinFlyTo.position);
            if (dis < .5f)
            {
                managerCoin.AddCoinAndUpdateUI();
                Destroy(gameObject);
            }
        }
    }
}