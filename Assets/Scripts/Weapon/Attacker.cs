using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacker: MonoBehaviour
{
    private Vector2 forceDirection;

    private static Dictionary<Vector2, int> directionIntDict => new Dictionary<Vector2, int>()
    {
        {Vector2.left, 0},
        {Vector2.right, 1},
        {Vector2.down, 2},
        {Vector2.up, 3}
    };
    public void Attack(Vector2 direction)
    {
        forceDirection = -direction;
        Debug.Log(direction);
        Animate(directionIntDict[direction]);
    }

    public void StopAttack()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
    }

    private void Animate(int direction)
    {
     //   GetComponent<Animator>().SetInteger("x", direction);
    }

    private void Start()
    {
    }
}