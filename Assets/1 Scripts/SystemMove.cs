using UnityEngine;
using System.Collections;

namespace WEI
{
    /// <summary>
    /// 移動系統
    /// </summary>
    public class SystemMove : MonoBehaviour
    {
        /// <summary>
        /// 回合系統
        /// </summary>
        private SystemTurn systemTurn;

        public float moveDistance = 2;

        private void Awake()
        {
            systemTurn = GameObject.Find("回合系統").GetComponent<SystemTurn>();
            systemTurn.onTurnEnemy.AddListener(() => { StartCoroutine(Move()); });
        }

        private IEnumerator Move()
        {
            float moveCount = 10;   //移動10次

            float perDistance = moveDistance / moveCount;

            //print(gameObject+"往前移動");
            for (int i = 0; i < moveCount; i++)
            {
                transform.position -= new Vector3(0, 0, perDistance);//座標轉換
                yield return new WaitForSeconds(0.05f);
            }
            
            yield return new WaitForSeconds(1.5f);  //等待時間

            systemTurn.MoveEndSpawnEnemy();
        }
    }
}
