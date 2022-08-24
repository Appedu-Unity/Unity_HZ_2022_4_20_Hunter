using UnityEngine;
using UnityEngine.Events;   //事件

namespace WEI
{
    /// <summary>
    /// 回收區域
    /// </summary>
    public class RacycleArea : MonoBehaviour
    {
        /// <summary>
        /// 回收金屬球的事件
        /// </summary>
        public UnityEvent onRecycle;
        #region 方法
        //兩個碰撞器其中一個勾選 Is Trigger
        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("金屬球"))
            {
                //print("回收");
                onRecycle.Invoke();
            }
        }
        #endregion
    }
}
