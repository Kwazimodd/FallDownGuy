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
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<Renderer>().enabled = true;
        Animate(directionIntDict[direction]);
    }

    public void StopAttack()
    {
        GetComponent<Collider2D>().isTrigger = false;
        GetComponent<Renderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(forceDirection);
        if (other.tag.Contains("Spikes"))
        {
            GetComponentInParent<Rigidbody2D>().AddForce(forceDirection*100000);
        }
    }

    private void Animate(int direction)
    {
     //   GetComponent<Animator>().SetInteger("x", direction);
    }
}