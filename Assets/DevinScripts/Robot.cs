using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [Range(1,2)]
    public int player = 1;
    public bool activated = false;
    private bool isFighting = false;
    public bool waiting = false;
    private float speed = 1;
    private Vector2 movement;
    private Rigidbody2D rb;
    private int hp = 5;
    private int dmg = 1;
    private Upgrade myUpgrade;
    private Robot rival;
    private Robot buddy;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        movement = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bot"))
        {
            Robot foundBot = collision.gameObject.GetComponent<Robot>();
            if (foundBot.player != this.player)
            {
                isFighting = true;
                rival = foundBot;
                foundBot.rival = this;
            }
            else
            {
                if(player == 1)
                {
                    if(collision.transform.position.x > this.transform.position.x)
                    {
                        foundBot.buddy = this;
                        waiting = true;
                    }
                }
                else
                {
                    if (collision.transform.position.x < this.transform.position.x)
                    {
                        foundBot.buddy = this;
                        waiting = true;
                    }
                }
            }
        }
    }

    private IEnumerator Fight()
    {
        yield return null;
    }

    private void FixedUpdate()
    {
        if(activated && !isFighting && !waiting)
        {
            movement.x = speed;
            if (player == 2)
            {
                movement.x *= -1;
            }
        }
        else
        {
            movement.x = 0;
        }
        rb.velocity = movement;
    }

    public void Activate()
    {
        activated = true;
    }

    private void Death()
    {
        buddy.waiting = false;
        rival.isFighting = false;
        Destroy(this.gameObject);
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
