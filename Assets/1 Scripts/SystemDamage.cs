using UnityEngine;
using TMPro;
using System.Collections; //協同程序需引用

namespace WEI
{
    /// <summary>
    /// 傷害喜統:更新傷害數字、顏色以及動態效果
    /// </summary>
    public class SystemDamage : MonoBehaviour
    {
        #region 資料
        public float damage;

        [Header("大於 100 顏色"), SerializeField] private Color coloeGratherThan100 = new Color(0.2f, 0.7f, 0.6f);
        [Header("大於 200 顏色"), SerializeField] private Color coloeGratherThan200 = new Color(0.8f, 0.4f, 0.5f);
        [Header("效果間隔"), SerializeField] private float interval = 0.025f;

        private float limitUp;
        private float limitRight;

        private TextMeshProUGUI textDamage;
        #endregion

        private void Start()
        {
            textDamage = GetComponentInChildren<TextMeshProUGUI>();

            textDamage.text = damage.ToString();

            if (damage >= 200) textDamage.color = coloeGratherThan200;
            else if (damage >= 100) textDamage.color = coloeGratherThan100;

            limitUp = Random.Range(0.5f, 0.8f);

            int r = Random.Range(0, 2);
            if (r == 0) limitRight = -0.1f;
            else if (r == 1) limitRight = 0.3f;

            //協同程序需呼叫應用
            StartCoroutine(MovementUp());
            StartCoroutine(MovementRight());
            StartCoroutine(ScaleEffect());
        }
        /// <summary>
        /// 協同程序 文字向上移動
        /// </summary>
        /// <returns></returns>
        private IEnumerator MovementUp()
        {
            //文字往上跑
            for (int i = 0; i < 10; i++)
            {
                transform.position += transform.up * limitUp;
                yield return new WaitForSeconds(interval);
            }
            //往下跑
            for (int i = 0; i < 3; i++)
            {
                transform.position -= transform.up * limitUp;
                yield return new WaitForSeconds(interval);
            }
            //文字淡出效果
            for (int i = 0; i < 10; i++)
            {
                textDamage.color -= new Color(0, 0, 0, 0.1f);
                yield return new WaitForSeconds(interval);
            }
        }
        /// <summary>
        /// 協同程序 文字向右移動
        /// </summary>
        /// <returns></returns>
        private IEnumerator MovementRight()
        {
            //文字向右移動
            for (int i = 0; i < 10; i++)
            {
                transform.position += transform.right * limitRight;
                yield return new WaitForSeconds(0.02f);
            }
        }
        /// <summary>
        /// 協同程序 文字放大縮小
        /// </summary>
        /// <returns></returns>
        private IEnumerator ScaleEffect()
        {
            //文字尺寸增加
            for (int i = 0; i < 5; i++)
            {
                transform.localScale += Vector3.one * 0.001f;
                yield return new WaitForSeconds(interval);
            }
            //文字尺寸縮小
            for (int i = 0; i < 5; i++)
            {
                transform.localScale -= Vector3.one * 0.001f;
                yield return new WaitForSeconds(interval);
            }
        }
    }
}
