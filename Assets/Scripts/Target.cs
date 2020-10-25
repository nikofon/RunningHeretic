using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static Target instance;
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(ReturnDistance() < 0.4f)
        {
            Win();
        }   
    }

    private void Win()
    {
        LevelLoader.instance.LoadWinScreen();
    }

    public float ReturnDistance()
    {
        return Vector3.Distance(transform.position, PlayerMovement.instance.transform.position);
    }
}
