using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WEI {
    public class SystemCoin : MonoBehaviour
    {
        [Header("延遲飛行"), Range(0, 2), SerializeField] private float delayFly = 1.5f;
        [Header("飛行速度"), Range(0, 10), SerializeField] private float speed = 1.5f;
        /// <summary>
        /// 金幣要前往的位置
        /// </summary>
        private Transform traCoinFlyTo;
        /// <summary>
        /// 開始飛行
        /// </summary>
        private bool startFly;

        private ManagerCoin managerCoin;

        private void Awake()
        {
            Physics.IgnoreLayerCollision(6, 3);
            Physics.IgnoreLayerCollision(6, 6);
            Physics.IgnoreLayerCollision(6, 7);

            traCoinFlyTo = GameObject.Find("金幣要往前的位置").transform;
            managerCoin = GameObject.Find("金幣管理器").GetComponent<ManagerCoin>();

            Invoke("StartFly", delayFly);
        }
        private void Update()
        {
            Fly();
        }
        /// <summary>
        /// 開始飛行
        /// </summary>
        private void StartFly()
        {
            startFly = true;
        }
        private void Fly()
        {
            if (!startFly) return;

            // 插植 : 將 A B 兩個數值抓出中間的指定位置
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