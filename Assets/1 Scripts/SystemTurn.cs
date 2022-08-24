using UnityEngine;
using UnityEngine.Events;   //命名空間

namespace WEI
{
    /// <summary>
    /// 回合系統:玩家或敵人回合管理
    /// </summary>
    public class SystemTurn : MonoBehaviour
    {
        /// <summary>
        /// 敵人回合
        /// </summary>
        public UnityEvent onTurnEnemy;

        #region 資料
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

        private bool canSpawn = true;

        private void Awake()
        {
            systemControl = GameObject.Find("玉米子").GetComponent<SystemControl>();
            systemSpawn = GameObject.Find("生成怪物系統").GetComponent<SystemSpawn>();
            racycleArea = GameObject.Find("回收區域").GetComponent<RacycleArea>();

            //回收區域.知道回收彈珠事件使否有發生.監聽器onRecycle這件事(做RacyInMarble這件事)
            racycleArea.onRecycle.AddListener(RacyInMarble);
        }
        private void RacyInMarble()
        {
            totalCountMarble = systemControl.canShootMarbleTotal;

            totalRacycIeMarble++;
            print("<Color == yellow>彈珠總數" + totalRacycIeMarble + "</color>");

            if (totalRacycIeMarble == totalCountMarble)
            {
                print("回收完畢，換敵人回合");
                onTurnEnemy.Invoke();
            }
        }

        /// <summary>
        /// 移動結束後生成迪任和彈珠
        /// </summary>
        public void MoveEndSpawnEnemy()
        {
            if (!canSpawn) return;

            canSpawn = false;
            systemSpawn.SpawnRandomEnemy();
            Invoke("PlayerTrun", 1);    //1秒後執行 可讓玩家重新發射彈珠功能
        }
        /// <summary>
        /// 可讓玩家重新發射彈珠
        /// </summary>
        private void PlayerTrun()
        {
            systemControl.canShootMarble = true;
            canSpawn = true;
            totalRacycIeMarble = 0; //歸零 重新計算回收數量
        }
    }
}
