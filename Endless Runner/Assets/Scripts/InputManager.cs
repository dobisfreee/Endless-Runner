using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingleTon<InputManager>
{

    public Action action;
    

    void Update()
    {
        if (Input.anyKey == false) // �Է��� �ֳ� �����ĸ� üũ�ϸ� �ż� ȿ�� up
        {
            return; // �Է��� ������ ���� �ö� 
        }
        
        if(Input.anyKey == true) 
        {
            action.Invoke();
        }
    }
}
