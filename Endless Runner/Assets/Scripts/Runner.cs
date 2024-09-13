using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum RoadLine  
{
    LEFT = -1, 
    MIDDLE, 
    RIGHT
}
public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine = RoadLine.MIDDLE;

    private void OnEnable()
    {
        InputManager.Instance.action += OnKeyUpdate;
    }

    private void OnKeyUpdate()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(roadLine != RoadLine.LEFT)
            {
                roadLine--;
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(roadLine != RoadLine.RIGHT)
            {
                roadLine++;
            }
        }
    }

    private void OnDisable()
    {
        InputManager.Instance.action -= OnKeyUpdate;
    }
}
