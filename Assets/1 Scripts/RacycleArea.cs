using UnityEngine;
using UnityEngine.Events;   //�ƥ�

namespace WEI
{
    /// <summary>
    /// �^���ϰ�
    /// </summary>
    public class RacycleArea : MonoBehaviour
    {
        /// <summary>
        /// �^�����ݲy���ƥ�
        /// </summary>
        public UnityEvent onRecycle;
        #region ��k
        //��ӸI�����䤤�@�ӤĿ� Is Trigger
        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("���ݲy"))
            {
                //print("�^��");
                onRecycle.Invoke();
            }
        }
        #endregion
    }
}
