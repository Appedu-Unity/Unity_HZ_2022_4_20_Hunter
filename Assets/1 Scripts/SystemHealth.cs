using UnityEngine;
using UnityEngine.UI;   //介面    
using TMPro;            //TMP的文字介面

namespace WEI
{
    /// <summary>
    /// 血量系統:更新血量、介面與死亡處理
    /// </summary>
    public class SystemHealth : MonoBehaviour
    {
        [Header("畫布傷害物件"), SerializeField] private GameObject goDamage;
        [Header("圖片血量"), SerializeField] private Image imgHP;
        [Header("文字血量"), SerializeField] private TextMeshProUGUI textHP;

        // 碰撞事件
        // 1. 兩個物件必須有一個帶有 Rigidbody
        // 2. 兩個物件必須有碰撞器   Collider
        // 3. 是否有勾選 Is Trigger
        private void OnCollisionEnter(Collision collision)
        {
            print("碰撞到的物件:" + collision.gameObject);
        }

    }
}