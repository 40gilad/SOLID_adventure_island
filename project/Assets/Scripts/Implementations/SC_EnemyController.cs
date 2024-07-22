using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_EnemyController : SC_EnemyMovement
{
    public int touch_damage;
    public bool is_lives_weapon;

    private void Start()
    {
        is_moving = false;
    }
    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") // player collider touch 'my_collider'
        {
            PlayerCollide();
        }
    }

    private void PlayerCollide()
    {
        Debug.Log("PlayerCollide");
    }
}
