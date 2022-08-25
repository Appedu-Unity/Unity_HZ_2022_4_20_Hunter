using UnityEngine;
using TMPro;

namespace WEI {
    /// <summary>
    /// 管理金幣:更新金幣數量
    /// </summary>
    public class ManagerCoin : MonoBehaviour
    {
        /// <summary>
        /// 金幣數量
        /// </summary>
        private TextMeshProUGUI textCoin;
        /// <summary>
        /// 金幣總數
        /// </summary>
        private int totalCoin;
        private void Awake()
        {
            textCoin = GameObject.Find("金幣數量").GetComponent<TextMeshProUGUI>();
        }
        public void AddCoinAndUpdateUI()
        {
            totalCoin++;
            textCoin.text = totalCoin.ToString();
        }
    }
    
}
