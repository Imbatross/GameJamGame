using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [Range(1,2)]
    public int player = 1;
    public bool activated = false;
    private bool isFighting = false;
    private float speed = 1;
    private Vector2 movement;
    private Rigidbody2D rb;
    private int hp;
    private Upgrade myUpgrade;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        movement = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        if(activated && !isFighting)
        {
            movement.x = speed;
        }
        else
        {
            movement.x = 0;
        }
        if(player == 2)
        {
            movement.x *= -1;
        }
        rb.velocity = movement;
    }

    public void Activate()
    {
        activated = true;
    }

    private void Death()
    {

    }

    private void TakeDamage(int dmg)
    {
        hp -= dmg;
        if(hp <= 0)
        {
            Death();
        }
    }

    private void AddHealth(int add)
    {
        hp += add;
    }

    public void AddUpgrade(Upgrade upg)
    {
        upg.SetRobot(this);
        myUpgrade = upg;
    }

    public void SetSpeed(float spd)
    {
        speed = spd;
    }

}
