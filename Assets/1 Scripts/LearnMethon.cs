using UnityEngine;

public class LearnMethon : MonoBehaviour
{
    //  自訂方法
    //  需要呼叫才會執行

    //  Unity 的入口
    //  開始事件 (藍色名稱)
    //  播放遊戲後會執行一次
    //  初始化設定:初始金額、三條命等等等
    private void Start()
    {
        Text();
        PrintColorText();
        print("傳回 10 方法的結果" + ReturnTen());
        print("傳回 方法的結果" + CalculatePrice());

        Shoot("火球");
        Shoot("火球");
        Shoot("火球","哈囉");
        Shoot("火球", special:"哈囉");

        //  近距離的攻擊
        Attack(50);
        //  遠距離的攻擊
        Attack(20.5f, "弓箭");
    }

    //  方法語法
    //  傳回類型  方法自訂名稱 (參數1,參數2...) { 方法內容 }
    //  無
    //  方法名稱 Unity 習慣用大寫開頭
    private void Text()
    {
        //  輸出(輸出訊息)
        print("Hello word");
    }
    #region 方法練習
    /// <summary>
    /// 顏色文字輸出練習
    /// </summary>
    private void PrintColorText()
    {
        print("<color=yellow>黃色訊息</color>");
        print("<color=#003399>藍色訊息</color>");
    }
    
    // 傳回方法
    // 必須搭配 return
    private int ReturnTen( )
    {
        return 10;
    }
    // 商店系統:99元，計算全部的商品價格
    public int countProduct = 10;
    public int countPrice = 99;

    private int CalculatePrice()
    {
        return countProduct * countPrice;
    }
    #endregion

    // 發射火球 、 發射電球
    public void shootFire()
    {
        print("發射火球");
        print("播放音效");
    }
    public void Shootlighting()
    {
        print("發射光球");
        print("播放音效");
    }

    private void Shoot(string type,string sound = "咻咻咻",string special = "ㄚㄚㄚ")
    {
        print("發射:" + type);
        print("音效:" + sound);
        print("特效:" + special);
    }
    
    //  方法的多載 overload
    //  定義:
    //  1. 相同名稱的方法
    //  2. 有不同數量的參數或者不同類型的參數
    private void IestMethod()
    {

    }
    private void IestMethod(int unmber)
    {

    }

    private void Attack(float atk)
    {
        print("近距離攻擊,攻擊力:" + atk);
    }
    private void Attack(float atk, string ball)
    {
        print("遠距離攻擊,攻擊力:" + atk);
        print("發射物件:" + ball);
    }
}
