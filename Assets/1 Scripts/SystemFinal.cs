using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

namespace WEI
{
    /// <summary>
    /// �C�������t�ΡG�ӧQ�P����
    /// </summary>
    public class SystemFinal : MonoBehaviour
    {
        #region ���
        /// <summary>
        /// �C�������e������
        /// </summary>
        private CanvasGroup groupFinal;
        /// <summary>
        /// �C�������p���D
        /// </summary>
        private TextMeshProUGUI textSubTitle;
        /// <summary>
        /// ���s�C��
        /// </summary>
        private Button btnReplay;
        /// <summary>
        /// ���}�C��
        /// </summary>
        private Button btnQuit;
        #endregion

        private void Awake()
        {
            groupFinal = GameObject.Find("�C�������e��������").GetComponent<CanvasGroup>();
            textSubTitle = GameObject.Find("�C�������p���D").GetComponent<TextMeshProUGUI>();
            btnReplay = GameObject.Find("���s�C��").GetComponent<Button>();
            btnQuit = GameObject.Find("���}�C��").GetComponent<Button>();
            btnReplay.onClick.AddListener(Replay);                                  // ���U���s�C�����s�� ���� Replay ��k
            btnQuit.onClick.AddListener(Quit);                                      // ���U�Q�}�C�����s�� ���� Quit ��k
        }

        /// <summary>
        /// ��ܵ����e���ç�s�p���D
        /// </summary>
        /// <param name="subTitle">�p���D��r</param>
        public void ShowFinalAndUpdateSubTitle(string subTitle)
        {
            textSubTitle.text = subTitle;
            StartCoroutine(ShowFinal());
        }

        /// <summary>
        /// ��ܤ���
        /// </summary>
        private IEnumerator ShowFinal()
        {
            for (int i = 0; i < 10; i++)
            {
                groupFinal.alpha += 0.1f;
                yield return new WaitForSeconds(0.03f);
            }

            groupFinal.interactable = true;     // �e���s��.���� = �Ұ�
            groupFinal.blocksRaycasts = true;   // �e���s��.�B�׮g�u = �Ұ�
        }

        /// <summary>
        /// ���s�C���\��
        /// </summary>
        private void Replay()
        {
            string nameCurrent = SceneManager.GetActiveScene().name;    // ���o���e�����W��
            SceneManager.LoadScene(nameCurrent);                        // �����޲z.���J����(�W��)
        }

        /// <summary>
        /// ���}���s�\��
        /// </summary>
        private void Quit()
        {
            Application.Quit();     // ���ε{��.���}()�F - �����C���AUnity ���L�@��
        }
    }
}