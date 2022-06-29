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
    // 加 +
    // 減 -
    // 乘 *
    // 除 /
    // 餘 %
    private void Start()
    {
        print("加法:" + (a + b));
        print("減法:" + (a - b));
        print("乘法:" + (a + b));
        print("除法:" + (a + b));
        print("取餘數:" + (a % b));
    }
}
