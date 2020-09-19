using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

// A class for combat interactions in the game.
public class PlayerCombat : MonoBehaviour
{
    public float ATTACK_RAD;
    public GameObject ATTACK_POINT;
    public GameObject SLASH;
    public float COOL_DOWN;

    private float x_direction = 0;
    private float y_direction = 0;

    private float last_known_x;
    private float last_known_y;
    private float current_cooldown;
    
    private bool attack_pressed;

    // Start is called before the first frame update
    void Start()
    {
        last_known_x = 0;
        last_known_y = 1;
        attack_pressed = false;
        current_cooldown = COOL_DOWN;
    }

    // Update is called once per frame
    void Update()
    {
        // Get X and Y directions, but leave it at the last known position if both are zero to prevent the attack being inside player
        x_direction = Input.GetAxisRaw("Horizontal");
        y_direction = Input.GetAxisRaw("Vertical");

        if (!(x_direction == 0 && y_direction == 0))
        {
            last_known_x = x_direction;
            last_known_y = y_direction;
        }

        // get whether space bar has been pressed
        attack_pressed = Input.GetKeyDown(KeyCode.Z);
    }

    private void FixedUpdate()
    {
        // Calculate the x and y position based on the direction of the last known input. Yay math!
        double angle = Math.Atan2(last_known_x, last_known_y);

        float x_coord = (float)(ATTACK_RAD * Math.Sin(angle));
        float y_coord = (float)(ATTACK_RAD * Math.Cos(angle));


        ATTACK_POINT.transform.position = new Vector2(x_coord + transform.position.x, y_coord + transform.position.y);

        // do an attack if the proper key has been pressed
        if (attack_pressed && current_cooldown == COOL_DOWN)
        {
            // by instantiating to the parent, it is changing the size of the slash, something to be aware of in case you need to fix later.
            Instantiate(SLASH, ATTACK_POINT.transform.position, Quaternion.Euler(0, 0, (float)(-angle * 180 / Math.PI) - 180), this.transform);
            current_cooldown = 0;
        }
        else if (current_cooldown < COOL_DOWN)
        {
            current_cooldown += 1;
        }
        else
        {
            current_cooldown = COOL_DOWN;
        }
    }
}
