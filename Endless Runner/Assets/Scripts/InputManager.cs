using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingleTon<InputManager>
{

    public Action action;
    

    void Update()
    {
        if (Input.anyKey == false) // 입력이 있냐 없느냐만 체크하면 돼서 효율 up
        {
            return; // 입력이 없으면 위로 올라감 
        }
        
        if(Input.anyKey == true) 
        {
            action.Invoke();
        }
    }
}
