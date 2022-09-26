using UnityEngine;
using System.Collections;

namespace WEI
{
    /// <summary>
    /// ���ʨt��
    /// </summary>
    public class SystemMove : MonoBehaviour
    {
        /// <summary>
        /// �^�X�t��
        /// </summary>
        private SystemTurn systemTurn;

        public float moveDistance = 2;

        private void Awake()
        {
            systemTurn = GameObject.Find("�^�X�t��").GetComponent<SystemTurn>();
            systemTurn.onTurnEnemy.AddListener(() => { StartCoroutine(Move()); });
        }

        private IEnumerator Move()
        {
            float moveCount = 10;   //����10��

            float perDistance = moveDistance / moveCount;

            //print(gameObject+"���e����");
            for (int i = 0; i < moveCount; i++)
            {
                transform.position -= new Vector3(0, 0, perDistance);//�y���ഫ
                yield return new WaitForSeconds(0.05f);
            }
            
            yield return new WaitForSeconds(1.5f);  //���ݮɶ�

            systemTurn.MoveEndSpawnEnemy();
        }
    }
}
