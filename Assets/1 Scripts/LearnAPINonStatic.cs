using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �ǲ� �D�R�AAPI
/// API ���W�S�� static
/// </summary>
public class LearnAPINonStatic : MonoBehaviour
{
    public Transform traA;
    public Light lightA;
    public Transform traB;
    void Start()
    {
        // �D�R�A�ݩ� Properties
        // 1. ���o get
        //����
        // - �����O�������
        // - ���s��b���骫��
        print("A�I�y��:" + traA.position);

        // 2. �]�w set
        // ���W��.�D�R�A�ݩʦW�� ���w ��
        traA.position = new Vector3(1, 1, 1);
        lightA.color = new Color(1, 0, 0);
    }
    private void Update()
    {
        traB.Rotate(0, 10, 0); 
    }
}
