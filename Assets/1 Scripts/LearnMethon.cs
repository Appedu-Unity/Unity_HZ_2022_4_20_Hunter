using UnityEngine;

public class LearnMethon : MonoBehaviour
{
    //  �ۭq��k
    //  �ݭn�I�s�~�|����

    //  Unity ���J�f
    //  �}�l�ƥ� (�Ŧ�W��)
    //  ����C����|����@��
    //  ��l�Ƴ]�w:��l���B�B�T���R������
    private void Start()
    {
        Text();
        PrintColorText();
        print("�Ǧ^ 10 ��k�����G" + ReturnTen());
        print("�Ǧ^ ��k�����G" + CalculatePrice());

        Shoot("���y");
        Shoot("���y");
        Shoot("���y","���o");
        Shoot("���y", special:"���o");

        //  ��Z��������
        Attack(50);
        //  ���Z��������
        Attack(20.5f, "�}�b");
    }

    //  ��k�y�k
    //  �Ǧ^����  ��k�ۭq�W�� (�Ѽ�1,�Ѽ�2...) { ��k���e }
    //  �L
    //  ��k�W�� Unity �ߺD�Τj�g�}�Y
    private void Text()
    {
        //  ��X(��X�T��)
        print("Hello word");
    }
    #region ��k�m��
    /// <summary>
    /// �C���r��X�m��
    /// </summary>
    private void PrintColorText()
    {
        print("<color=yellow>����T��</color>");
        print("<color=#003399>�Ŧ�T��</color>");
    }
    
    // �Ǧ^��k
    // �����f�t return
    private int ReturnTen( )
    {
        return 10;
    }
    // �ө��t��:99���A�p��������ӫ~����
    public int countProduct = 10;
    public int countPrice = 99;

    private int CalculatePrice()
    {
        return countProduct * countPrice;
    }
    #endregion

    // �o�g���y �B �o�g�q�y
    public void shootFire()
    {
        print("�o�g���y");
        print("���񭵮�");
    }
    public void Shootlighting()
    {
        print("�o�g���y");
        print("���񭵮�");
    }

    private void Shoot(string type,string sound = "������",string special = "������")
    {
        print("�o�g:" + type);
        print("����:" + sound);
        print("�S��:" + special);
    }
    
    //  ��k���h�� overload
    //  �w�q:
    //  1. �ۦP�W�٪���k
    //  2. �����P�ƶq���ѼƩΪ̤��P�������Ѽ�
    private void IestMethod()
    {

    }
    private void IestMethod(int unmber)
    {

    }

    private void Attack(float atk)
    {
        print("��Z������,�����O:" + atk);
    }
    private void Attack(float atk, string ball)
    {
        print("���Z������,�����O:" + atk);
        print("�o�g����:" + ball);
    }
}
