using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float HP { get; set; }
    public float Speed { get; set; }

    public Enemy(float HP, float Speed)
    {
        this.HP = HP;
        this.Speed = Speed;
    }
}
