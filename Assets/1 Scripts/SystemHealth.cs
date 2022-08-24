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
        #region 資料
        [Header("畫布傷害物件"), SerializeField] private GameObject goDamage;
        [Header("圖片血量"), SerializeField] private Image imgHP;
        [Header("文字血量"), SerializeField] private TextMeshProUGUI textHP;
        [Header("怪物資料"), SerializeField] private DataEnemy dataEnemy;
        [Header("怪物動畫控制器"), SerializeField] private Animator aniEnemy;

        private float hp;
        private string parDamage = "觸發";
        #endregion

        private SystemSpawn systemSpawn;

        private void Awake()
        {
            hp = dataEnemy.hp;
            textHP.text = hp.ToString();    //一開始的文字更新，可在一開始就抓取Data資料
            systemSpawn = GameObject.Find("生成怪物系統").GetComponent<SystemSpawn>();
        }
        // 碰撞事件
        // 1. 兩個物件必須有一個帶有 Rigidbody
        // 2. 兩個物件必須有碰撞器   Collider
        // 3. 是否有勾選 Is Trigger
        private void OnCollisionEnter(Collision collision)
        {
            //print("碰撞到的物件:" + collision.gameObject);
            GetDamage();
        }
        /// <summary>
        /// 受傷
        /// </summary>
        private void GetDamage()
        {
            float getDamage = 50;
            hp -= getDamage;
            //print("血量剩下" + hp);
            textHP.text = hp.ToString();    //將血量轉換為文字
            imgHP.fillAmount = hp / dataEnemy.hp;   //將血量百分比轉為福點數並對上相對應的血條圖片變化
            aniEnemy.SetTrigger(parDamage); //播放受傷動畫
            Vector3 pos = transform.position + Vector3.up;
            SystemDamage tempDamage = Instantiate(goDamage,pos,Quaternion.Euler(50,0,0)).GetComponent<SystemDamage>();
            tempDamage.damage = getDamage;  //更新傷害直

            if (hp <= 0)
            {
                Dead();
            }
        }

        private void Dead()
        {
            //print("死亡");
            Destroy(gameObject);
            systemSpawn.totalCountEnemylive--;
        }

    }
}