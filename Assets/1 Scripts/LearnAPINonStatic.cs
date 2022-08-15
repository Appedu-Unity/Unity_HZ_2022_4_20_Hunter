using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 學習 非靜態API
/// API 文件上沒有 static
/// </summary>
public class LearnAPINonStatic : MonoBehaviour
{
    public Transform traA;
    public Light lightA;
    public Transform traB;
    void Start()
    {
        // 非靜態屬性 Properties
        // 1. 取得 get
        //條件
        // - 該類別類型欄位
        // - 欄位存放在實體物件
        print("A點座標:" + traA.position);

        // 2. 設定 set
        // 欄位名稱.非靜態屬性名稱 指定 值
        traA.position = new Vector3(1, 1, 1);
        lightA.color = new Color(1, 0, 0);
    }
    private void Update()
    {
        traB.Rotate(0, 10, 0); 
    }
}
