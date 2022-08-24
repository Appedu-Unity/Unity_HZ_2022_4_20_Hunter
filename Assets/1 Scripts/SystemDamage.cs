using UnityEngine;
using TMPro;
using System.Collections; //��P�{�ǻݤޥ�

namespace WEI
{
    /// <summary>
    /// �ˮ`�߲�:��s�ˮ`�Ʀr�B�C��H�ΰʺA�ĪG
    /// </summary>
    public class SystemDamage : MonoBehaviour
    {
        #region ���
        public float damage;

        [Header("�j�� 100 �C��"), SerializeField] private Color coloeGratherThan100 = new Color(0.2f, 0.7f, 0.6f);
        [Header("�j�� 200 �C��"), SerializeField] private Color coloeGratherThan200 = new Color(0.8f, 0.4f, 0.5f);
        [Header("�ĪG���j"), SerializeField] private float interval = 0.025f;

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

            //��P�{�ǻݩI�s����
            StartCoroutine(MovementUp());
            StartCoroutine(MovementRight());
            StartCoroutine(ScaleEffect());
        }
        /// <summary>
        /// ��P�{�� ��r�V�W����
        /// </summary>
        /// <returns></returns>
        private IEnumerator MovementUp()
        {
            //��r���W�]
            for (int i = 0; i < 10; i++)
            {
                transform.position += transform.up * limitUp;
                yield return new WaitForSeconds(interval);
            }
            //���U�]
            for (int i = 0; i < 3; i++)
            {
                transform.position -= transform.up * limitUp;
                yield return new WaitForSeconds(interval);
            }
            //��r�H�X�ĪG
            for (int i = 0; i < 10; i++)
            {
                textDamage.color -= new Color(0, 0, 0, 0.1f);
                yield return new WaitForSeconds(interval);
            }
        }
        /// <summary>
        /// ��P�{�� ��r�V�k����
        /// </summary>
        /// <returns></returns>
        private IEnumerator MovementRight()
        {
            //��r�V�k����
            for (int i = 0; i < 10; i++)
            {
                transform.position += transform.right * limitRight;
                yield return new WaitForSeconds(0.02f);
            }
        }
        /// <summary>
        /// ��P�{�� ��r��j�Y�p
        /// </summary>
        /// <returns></returns>
        private IEnumerator ScaleEffect()
        {
            //��r�ؤo�W�[
            for (int i = 0; i < 5; i++)
            {
                transform.localScale += Vector3.one * 0.001f;
                yield return new WaitForSeconds(interval);
            }
            //��r�ؤo�Y�p
            for (int i = 0; i < 5; i++)
            {
                transform.localScale -= Vector3.one * 0.001f;
                yield return new WaitForSeconds(interval);
            }
        }
    }
}
