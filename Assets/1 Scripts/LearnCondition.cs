using UnityEngine;

/// <summary>
///  ����(�P�_��)
/// 1. if
/// 2. switch
/// </summary>
public class LearnCondition : MonoBehaviour
{
    public bool openDoor;
    public int combo;
    private void Start()
    {
        #region if�j��
        if (true)
        {
            print("�ڦb�P�_�O if ��");
        }
        #endregion
    }

    private void Update()
    {
        // �p�G openDoor ���� true �N��}���A�_�h�N����
        // �p�G
        // if �y�k:
        // if (���L��) {���L�ȵ��� true �N����}
        // �_�h
        // else {���L�ȵ��� false �|����}
        // else �@�w�n��b if �U��A�����W�ϥ�
        if (openDoor)
        {
            print("�}��");
        }
        else
        {
            print("����");
        }
        // else if () ()
        // �s���� < 100 �����O + 0%
        // �s���� >= 100 �����O + 10%
        // �s���� >= 200 �����O + 20%
        if (combo <100)
        {
            print("�����O + 0%");
        }
        else if (combo >=200)
        {
            print("�����O + 20%");
        }
        else if (combo >= 100)
        {
            print("�����O + 10%");
        }
        
    }
}
