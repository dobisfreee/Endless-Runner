using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine  
{
    LEFT = -1, 
    MIDDLE, 
    RIGHT
}
public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine = RoadLine.MIDDLE;
   
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
