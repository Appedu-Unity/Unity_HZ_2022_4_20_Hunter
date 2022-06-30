using UnityEngine;

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
        [Header("旋轉速度"),Range(0,500)]
        public float speedTurn = 10.5f;
        [Header("彈珠物件")]
        public GameObject marble;
        [Header("彈珠可發射總數"),Range(0, 1000)]
        public int canShootMarbleTotal = 15;
        #endregion

        #region 事件
        #endregion

        #region 方法
        /// <summary>
        /// 角色選轉
        /// </summary>
        private void TurnChsrscter()
        { 
        }
        /// <summary>
        /// 發射彈珠
        /// </summary>
        private void ShootMarbleTotal()
        { 
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