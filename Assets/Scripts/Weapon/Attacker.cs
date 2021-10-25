using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Attacker: MonoBehaviour
{
    private Vector2 forceDirection;
    [SerializeField] private float pushHeight;
    
    private List<String> collisionsList = new List<string>();

    private static Dictionary<Vector2, int> directionIntDict => new Dictionary<Vector2, int>()
    {
        {Vector2.left, 0},
        {Vector2.right, 1},
        {Vector2.down, 2},
        {Vector2.up, 3}
    };
    public void Attack()
    {
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
                
        }   
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
        }   
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
        }
    }

    public void StopAttack()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        collisionsList.Add(other.tag);
        if (other.tag.Equals("Spikes"))
        {
            PushUpParent();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        collisionsList.Remove(other.tag);
    }

    private void PushUpParent()
    {
        GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, pushHeight);
    }

    private void Animate(int direction)
    {
     //   GetComponent<Animator>().SetInteger("x", direction);
    }

    private void Start()
    {
    }
}