using UnityEngine;

/// <summary>
/// �ǲ߹B��l
/// 1. �ǲ߹B��l
/// 2. ����B��l
/// 3. �޿�B��l
/// </summary>
public class LearnOperator : MonoBehaviour
{
    private float a = 10;
    private float b = 4;

    private int c = 99;
    private int d = 1;

    private int diamond = 1;
    private int hp = 100;

    private void Start()
    {
        #region �ƾǹB��l
        // �[ +
        // �� -
        // �� *
        // �� /
        // �l %
        print("�[�k:" + (a + b));
        print("��k:" + (a - b));
        print("���k:" + (a + b));
        print("���k:" + (a + b));
        print("���l��:" + (a % b));
        #endregion

        #region ����B��l
        // �p��       <
        // �j��       >
        // �p�󵥩�   <=
        // �j�󵥩�   >=
        // ������     !=
        // ����       ==

        // ����B�⪺���G�����L�� : true�Bfalse 
        print("�p��" + (c < d));          //false
        print("�j��" + (c > d));          //true
        print("�p�󵥩�" + (c <= d));     //false
        print("�j�󵥩�" + (c >= d));     //true
        print("������" + (c != d));       //true
        print("����" + (c == d));         //false
        #endregion

        #region �޿�B��l

        // �޿�B��l . �w�塞�L��
        // �åB &&:��Ӥ��L�Ȧ��@�� false ���G�N�O false
        print("true true:" + (true && true));           //true
        print("true false:" + (true && false));         //false
        print("false true:" + (false && true));         //false
        print("false false:" + (false && false));       //false

        // �Ϊ� || :��ӥ��L�Ȧ��@�Ӭ� true ���G�� true
        print("true true:" + (true || true));           //true
        print("true false:" + (true || false));         //true
        print("false true:" + (false || true));         //true
        print("false false:" + (false || false));       //false

        // �C������:
        // �ӧQ����:�_�� >= 3 �åB ��q > 0 �~��L��
        print("�O�_�L��:" + (diamond >= 3 && hp > 0));  //false

        // �A�˹B��l
        // �@��:�N���L���ܬۤ�
        print("!true" + !true);
        print("!false" + !false);
        #endregion
    }
}