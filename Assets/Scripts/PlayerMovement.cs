using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 move;
    Animator am;
    Rigidbody2D player;
    public static PlayerMovement instance;
    public float movespeed;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        if(move.sqrMagnitude > 0.01)
        {
            am.Play("PlayerWalking");
        }
        else { am.Play("playerIdle"); }
    }
    private void FixedUpdate()
    {
        player.MovePosition(player.position + movespeed * move);
    }
}
