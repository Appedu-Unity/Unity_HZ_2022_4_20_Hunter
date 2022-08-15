using UnityEngine;
using System.Collections;
using TMPro;

//  命名空間 namespace 空間名稱 { 該空間的內容 }
namespace WEI
{
    /// <summary>
    /// 玩家控制系統
    /// 物件旋轉、發射彈珠
    /// </summary>
    public class SystemControl : MonoBehaviour
    {
        #region 資料
        [Header("箭頭物件")]
        public GameObject arrow;
        [Header("旋轉速度"), Range(0, 500)]
        public float speedTurn = 10.5f;
        [Header("彈珠物件")]
        public GameObject marble;
        [Header("彈珠可發射總數"), Range(0, 1000)]
        public int canShootMarbleTotal = 15;
        [Header("彈珠生成點")]
        public Transform traSpawnPoint;
        [Header("攻擊的參數名稱")]
        private string parAttack = "觸發攻擊";
        [Header("彈珠發射速度"), Range(0, 5000)]
        private float speedMarble = 1000;
        [Header("彈珠發射間隔"), Range(0, 10)]
        public float intervalMarble = 0.1f;
        [Header("彈珠數量")]
        public TextMeshProUGUI textMableCount;

        private Animator ani;
        /// <summary>
        /// 能否發射彈珠
        /// </summary>
        private bool canShootMarble = true;
        /// <summary>
        /// 轉換滑鼠用攝影機
        /// </summary>
        private Camera cameraMouse;
        /// <summary>
        /// 座標轉換後實體物件
        /// </summary>
        private Transform traMouse;
        #endregion

        #region 事件
        /// <summary>
        /// Awake會在Start前執行一次
        /// </summary>
        private void Awake()
        {
            ani = GetComponent<Animator>();
            textMableCount.text = "X" + canShootMarbleTotal;

            cameraMouse = GameObject.Find("轉換滑鼠用的攝影機").GetComponent<Camera>();
            traMouse = GameObject.Find("座標轉換後實體物件").transform;
        }

        private void Update()
        {
            ShootMarbleTotal();
            TurnChsrscter();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 角色選轉
        /// </summary>
        private void TurnChsrscter()
        {
            // 如果 不能發射 就跳出
            if (!canShootMarble) return;
            
            // 1.滑鼠座標
            Vector3 posMouse = Input.mousePosition;
            print("<clor=yellow>滑鼠座標:" + posMouse + "</color>");
            // 跟攝影機的 Y 軸一樣
            posMouse.z = 25;
            // 2.滑鼠座標轉為世界座標
            Vector3 pos = cameraMouse.ScreenToWorldPoint(posMouse);
            pos.y = 1.5f;
            // 3.世界座標給實體物件
            traMouse.position = pos;
            //  此物件的變形，面向(座標轉換後實體物件)
            transform.LookAt(traMouse);

        }
        /// <summary>
        /// 發射彈珠
        /// </summary>
        private void ShootMarbleTotal()
        {
            if (!canShootMarble) return;

            // 滑鼠按下左鍵時 箭頭顯示
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                arrow.SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                // 不能發射彈珠
                canShootMarble = false;

                arrow.SetActive(false);
                StartCoroutine(SpawnMarble());
            }
        }
        /// <summary>
        /// 生成彈珠附帶間隔時間
        /// </summary>
        /// <returns></returns>
        private IEnumerator SpawnMarble()
        {
            int total = canShootMarbleTotal;
            for (int i = 0; i < canShootMarbleTotal; i++)
            {
                ani.SetTrigger(parAttack);
                //print("放開左鍵");
                // 箭頭消失
                arrow.SetActive(true);
                // Object 類別可省略不寫
                // 直接透過Object成員名稱使用
                // 生成(彈珠)
                // Quaternion.identity 零度角
                GameObject tempMarble = Instantiate(marble, traSpawnPoint.position, Quaternion.identity);
                // 站存彈珠 取得鋼體元件 添加推力(腳色.前方*速度)
                // transform.forward 腳色的前方
                tempMarble.GetComponent<Rigidbody>().AddForce(transform.forward * speedMarble);

                total--;

                if (total > 0) textMableCount.text = "X" + total;
                else if (total == 0) textMableCount.text = "";


                yield return new WaitForSeconds(intervalMarble);

            }
        }
        /// <summary>
        /// 回收彈珠
        /// </summary>
        private void RecycleMarble()
        {
        }
        #endregion
    }
}