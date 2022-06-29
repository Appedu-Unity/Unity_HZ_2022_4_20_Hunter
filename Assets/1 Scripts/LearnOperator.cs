using UnityEngine;

/// <summary>
/// 學習運算子
/// 1. 學習運算子
/// 2. 比較運算子
/// 3. 邏輯運算子
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
        #region 數學運算子
        // 加 +
        // 減 -
        // 乘 *
        // 除 /
        // 餘 %
        print("加法:" + (a + b));
        print("減法:" + (a - b));
        print("乘法:" + (a + b));
        print("除法:" + (a + b));
        print("取餘數:" + (a % b));
        #endregion

        #region 比較運算子
        // 小於       <
        // 大於       >
        // 小於等於   <=
        // 大於等於   >=
        // 不等於     !=
        // 等於       ==

        // 比較運算的結果為布林值 : true、false 
        print("小於" + (c < d));          //false
        print("大於" + (c > d));          //true
        print("小於等於" + (c <= d));     //false
        print("大於等於" + (c >= d));     //true
        print("不等於" + (c != d));       //true
        print("等於" + (c == d));         //false
        #endregion

        #region 邏輯運算子

        // 邏輯運算子 . 針對布林值
        // 並且 &&:兩個不林值有一個 false 結果就是 false
        print("true true:" + (true && true));           //true
        print("true false:" + (true && false));         //false
        print("false true:" + (false && true));         //false
        print("false false:" + (false && false));       //false

        // 或者 || :兩個布林值有一個為 true 結果為 true
        print("true true:" + (true || true));           //true
        print("true false:" + (true || false));         //true
        print("false true:" + (false || true));         //true
        print("false false:" + (false || false));       //false

        // 遊戲條件:
        // 勝利條件:寶石 >= 3 並且 血量 > 0 才能過關
        print("是否過關:" + (diamond >= 3 && hp > 0));  //false

        // 顛倒運算子
        // 作用:將布林質變相反
        print("!true" + !true);
        print("!false" + !false);
        #endregion
    }
}