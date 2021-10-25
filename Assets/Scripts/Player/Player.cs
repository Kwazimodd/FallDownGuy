using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.WSA;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private new Rigidbody2D rigidbody2D;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;

    private List<String> collisionsList = new List<string>();

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();        
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();
        Attack();
        if (Input.GetKey(KeyCode.Space) && collisionsList.Contains("Block"))
        {
            Jump();
        }
    }

    private void Attack()
    {
        GetComponentInChildren<Attacker>().Attack();
    }

    private void Move()
    {
        rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        rigidbody2D.velocity = new Vector2(0, jumpHeight);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        collisionsList.Add(other.gameObject.tag);
        if (collisionsList.Contains("Spikes"))
        {
            Death();
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        collisionsList.Remove(other.gameObject.tag);
    }

    private void Death()
    {
        Debug.Log("Death");
    }
}

