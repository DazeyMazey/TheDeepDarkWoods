using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Jump_Speed;
    public float Walk_Speed;
    public float MAXSPEED;

    public double x_velocity;
    public double y_velocity;
    private float x_direction = 0;
    private float y_direction = 0;
    private Rigidbody2D rigid_bod; // this one will help with the character's position    
    
    // Start is called before the first frame update
    void Start()
    {
        rigid_bod = this.GetComponent<Rigidbody2D>();
        x_velocity = 0;
        y_velocity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from player 
        x_direction = Input.GetAxisRaw("Horizontal");
        y_direction = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // calculate position and check collisions
        switch (x_direction)
        {
            case 1: x_velocity = x_velocity < MAXSPEED ? x_velocity + (x_direction * Walk_Speed) : MAXSPEED; break;
            case -1: x_velocity = x_velocity > -MAXSPEED ? x_velocity + (x_direction * Walk_Speed) : -MAXSPEED; break;
            default: x_velocity = 0; break;
        }
        switch (y_direction)
        {
            case 1: y_velocity = y_velocity < MAXSPEED ? y_velocity + (y_direction * Walk_Speed) : MAXSPEED; break;
            case -1: y_velocity = y_velocity > -MAXSPEED ? y_velocity + (y_direction * Walk_Speed) : -MAXSPEED; break;
            default: y_velocity = 0; break;
        }

        // actually applying the transformation at the end after all collision checking and calculations

        rigid_bod.velocity = new Vector2((float)x_velocity, (float)y_velocity);
    }

}
