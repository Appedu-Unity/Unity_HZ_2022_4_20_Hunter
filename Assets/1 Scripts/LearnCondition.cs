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
    public string prop;

    // 1. �w�q�C�|���e
    // 2. �w�q���

    // �C�|�y�k:
    // �׹��� �C�| �C�|�W�� { �C�|���e }
    public enum StatePlayer
    {
        Idle,Walk,Run,Hunt,Attack,Dead
    }
    // �w�q���:
    // �׹��� �C�|�W�� ���W��;
    public StatePlayer statePlayer;

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
        #region �P�_�OIF
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
        #endregion

        #region �P�_��Switch
        // Switch �y�k
        // switch (������B�⦡)
        // {
        //      case ��:
        //          �{�����e
        //          break;
        // }
        switch (prop)
        {
            case "�����Ĥ�":
                print("�ɦ�");
                break;
            case "�Ŧ��Ĥ�":
                print("���]");
                break;
            case "�����Ĥ�":
                print("����O");
                break;

            default:
                print("�S�����D��");
                break;
        }

        // 1 switch + Tab * 2
        // 2. ��J�C�|�W�� statePlayer
        // 3. Enter
        switch (statePlayer)
        {
            case StatePlayer.Idle:
                print("����");
                break;
            case StatePlayer.Walk:
                print("����");
                break;
            case StatePlayer.Run:
                print("�]�B");
                break;
            case StatePlayer.Hunt:
                print("����");
                break;
            case StatePlayer.Attack:
                print("����");
                break;
            case StatePlayer.Dead:
                print("���`");
                break;
            default:
                break;
        }
        #endregion
    }
}
