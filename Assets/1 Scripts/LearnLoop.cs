using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �ǲ߰j�� ��P�{�� Coroution
/// </summary>
public class LearnLoop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �j�� : ���ư���
        // while �j��y�k
        // if (���L��) {�{��} ����@��
        // while (���L��) {�{��} ���ư���쥬�L�Ȭ� false

        int count = 0;

        while (count < 5 )
        {
            //print("while�j��!" + count);
            count++;
        }
        for (int i = 0; i < 5; i++)
        {
            //print("for�j��!" + i);
        }

        // ��P�{��
        // 1.�ޥΩR�W�Ŷ� System.Collections
        // 2.�w�q�Ǧ^���� IEnumerator ����k
        // 3.yield return ����
        // 4.StartCoroutine �Ұ�
        StartCoroutine(Test());
    }
    private IEnumerator Test()
    {
        //print("<color=yellow>�Ĥ@��</color>");
        //���������
        yield return new WaitForSeconds(1);
        //print("<color=yellow>�ĤG��</color>");
    }
    private IEnumerator forloop()
    {
        for (int i = 0; i < 10; i++)
        {
            //print("for�j��!" + i);
            yield return new WaitForSeconds(1);
        }
    }

}
