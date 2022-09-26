using UnityEngine;
using UnityEngine.Events;   //命名空間
using TMPro;

namespace WEI
{
    /// <summary>
    /// 回合系統:玩家或敵人回合管理
    /// </summary>
    public class SystemTurn : MonoBehaviour
    {

        #region 資料

        private  SystemFinal systemFinal;

        /// <summary>
        /// 敵人回合
        /// </summary>
        public UnityEvent onTurnEnemy;
        /// <summary>
        /// 層數數字
        /// </summary>
        private TextMeshProUGUI textFloorCount;
        [Header("彈珠資料")] private SystemControl systemControl;
        [Header("生成怪物系統")] private SystemSpawn systemSpawn;
        [Header("回收區域")] private RacycleArea racycleArea;

        /// <summary>
        /// 彈珠的總數
        /// </summary>
        private int totalCountMarble;
        /// <summary>
        /// 怪物的存活總數
        /// </summary>
        private int totalCountEnemylive;
        /// <summary>
        /// 回收彈珠數量
        /// </summary>
        private int totalRacycIeMarble;
        #endregion


        private int countMarbleEat;
        /// <summary>
        /// 初始層數
        /// </summary>
        private int countFloor = 1;

        [SerializeField, Header("當前層數最大值"), Range(1, 100)]
        private int countFloorMax = 50;
        [SerializeField, Header("沒有移動物件並且延遲生成的時間"), Range(0, 3)]
        private float noMoveObjectAndDelaySpawn = 1;

        private bool canSpawn = true;
        private bool isFloorCountMax;

        private void Awake()
        {
            systemControl = GameObject.Find("玉米子").GetComponent<SystemControl>();
            systemSpawn = GameObject.Find("生成怪物系統").GetComponent<SystemSpawn>();
            racycleArea = GameObject.Find("回收區域").GetComponent<RacycleArea>();
            textFloorCount = GameObject.Find("層數數字").GetComponent<TextMeshProUGUI>();

            //回收區域.知道回收彈珠事件使否有發生.監聽器onRecycle這件事(做RacyInMarble這件事)
            racycleArea.onRecycle.AddListener(RacyInMarble);

            systemFinal = FindObjectOfType<SystemFinal>();
        }


        /// <summary>
        /// 回收彈珠
        /// </summary>
        private void RacyInMarble()
        {
            totalCountMarble = systemControl.canShootMarbleTotal;

            totalRacycIeMarble++;
            //print("<Color == yellow>彈珠總數" + totalRacycIeMarble + "</color>");

            if (totalRacycIeMarble == totalCountMarble)
            {
                //print("回收完畢，換敵人回合");
                onTurnEnemy.Invoke();

                //如果沒有敵人就移動結束並生成敵人與彈珠
                if (FindObjectsOfType<SystemMove>().Length == 0)
                {
                    Invoke("MoveEndSpawnEnemy", noMoveObjectAndDelaySpawn);
                }
            }
        }

        /// <summary>
        /// 移動結束後生成迪任和彈珠
        /// </summary>
        public void MoveEndSpawnEnemy()
        {
            if (!canSpawn) return;
            if (!isFloorCountMax)
            {
                canSpawn = false;
                systemSpawn.SpawnRandomEnemy();
            }
            Invoke("PlayerTrun", 1);    //1秒後執行 可讓玩家重新發射彈珠功能
        }

        /// <summary>
        /// 玩家回合
        /// </summary>
        private void PlayerTrun()
        {
            systemControl.canShootMarble = true;
            canSpawn = true;
            totalRacycIeMarble = 0; //歸零 重新計算回收數量

            #region 彈珠數量處理
            systemControl.canShootMarbleTotal += countMarbleEat;
            countMarbleEat = 0;
            #endregion
            if (countFloor < countFloorMax)
            {
                //避免數字在累加
                countFloor++;
                textFloorCount.text = countFloor.ToString();
            }
            if (countFloor == countFloorMax) isFloorCountMax = true;

            if (isFloorCountMax)
            {
                if (FindObjectsOfType<SystemMove>().Length == 0)
                {
                    systemFinal.ShowFinalAndUpdateSubTitle("Congratulations on the successful challenge level!");
                    //print("挑戰成功");
                }
            }
        }
        public void MarbleEat()
        {
            countMarbleEat++;
        }
    }
}
