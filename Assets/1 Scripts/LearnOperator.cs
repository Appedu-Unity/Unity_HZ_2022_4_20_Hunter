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
    // �[ +
    // �� -
    // �� *
    // �� /
    // �l %
    private void Start()
    {
        print("�[�k:" + (a + b));
        print("��k:" + (a - b));
        print("���k:" + (a + b));
        print("���k:" + (a + b));
        print("���l��:" + (a % b));
    }
}
