using UnityEngine;
using System.Collections.Generic;   // 資料結構 清單 List
using System.Linq;                  // 語言整合查詢

namespace WEI
{
    /// <summary>
    /// 生成怪物系統
    /// </summary>
    public class SystemSpawn : MonoBehaviour
    {
        #region  資料
        // [] 陣列
        // SerializeField 將私人欄位顯示 
        [Header("怪物陣列"),SerializeField] private GameObject[] gaEnemys;
        [Header("生成格子第二排座標"),SerializeField]private Transform[] traSecondPlace;

        [Header("序列畫欄位的清單"),SerializeField] private List<Transform> listSceondPlace = new List<Transform>();
        #endregion

        #region  事件
        private void Awake()
        {
            SpawnRandomEnemy();
        }
        #endregion
        #region  方法
        /// <summary>
        /// 隨機生成敵人
        /// </summary>
        private void SpawnRandomEnemy()
        {
            int main = 2;                       //格子數量的最小值
            int max = traSecondPlace.Length - 1;//格子數量的最大值

            int randomCount = Random.Range(main, max);
            print("取得隨機的怪物數量"+randomCount);

            //清單 = 陣列.轉為清單();
            listSceondPlace = traSecondPlace.ToList();
            //新增一個隨機物件
            System.Random random = new System.Random();
            // OrderBy 排序
            // random.Next 隨機的整數
            // 清單 = 清單 的 排序(每個清單內容 => 隨機排序) 設為清單
            listSceondPlace = listSceondPlace.OrderBy(x => random.Next()).ToList();

            //要扣除的數量
            int sub = traSecondPlace.Length - randomCount;
            print("要扣除的數量" + sub);

            // 迴圈 刪除 要扣掉的數量
            for (int i = 0; i < sub; i++)
            {
                // 刪除髓機的第一筆資料 => 0
                listSceondPlace.RemoveAt(0);
            }
            // 生成所有怪物 與 彈珠
            for (int i = 0; i < listSceondPlace.Count; i++)
            {
                // 如果 i 等於 0 生成彈珠
                if (i == 0)
                {
                    Instantiate(
                    gaMarble,
                    listSceondPlace[i].position,
                    Quaternion.identity);
                }
                else
                {
                // 隨機怪物
                int randomIndex = Random.Range(0, gaEnemys.Length);
                // 生成怪物
                Instantiate(
                    gaEnemys[randomIndex],
                    listSceondPlace[i].position,
                    Quaternion.identity);
                }
            }
        }
        #endregion

        [Header("格子 彈珠"), SerializeField] private GameObject gaMarble;
    }
}
