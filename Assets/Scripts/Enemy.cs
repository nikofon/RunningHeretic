using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class Enemy : MonoBehaviour
{
    public float looseRadius;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < looseRadius)
        {
            Loose();
        }   
    }

    private void Loose()
    {
        Debug.Log("You loose");
    }
}
