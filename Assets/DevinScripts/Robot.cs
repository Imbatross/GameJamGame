using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public bool player1;
    private bool activated = false;
    private int speed;
    private int hp;
    private Upgrade myUpgrade;


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

    public void SetSpeed(int spd)
    {
        speed = spd;
    }

}
