using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 學習迴圈 協同程序 Coroution
/// </summary>
public class LearnLoop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 迴圈 : 重複執行
        // while 迴圈語法
        // if (布林值) {程式} 執行一次
        // while (布林值) {程式} 重複執行到布林值為 false

        int count = 0;

        while (count < 5 )
        {
            //print("while迴圈!" + count);
            count++;
        }
        for (int i = 0; i < 5; i++)
        {
            //print("for迴圈!" + i);
        }

        // 協同程序
        // 1.引用命名空間 System.Collections
        // 2.定義傳回類型 IEnumerator 的方法
        // 3.yield return 等待
        // 4.StartCoroutine 啟動
        StartCoroutine(Test());
    }
    private IEnumerator Test()
    {
        //print("<color=yellow>第一行</color>");
        //延遲執行秒數
        yield return new WaitForSeconds(1);
        //print("<color=yellow>第二行</color>");
    }
    private IEnumerator forloop()
    {
        for (int i = 0; i < 10; i++)
        {
            //print("for迴圈!" + i);
            yield return new WaitForSeconds(1);
        }
    }

}
