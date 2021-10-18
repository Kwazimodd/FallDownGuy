using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private new Rigidbody2D rigidbody2D;
    
    [SerializeField] 
    private float speed;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryToAttackBottom();
        }
    }

    private void TryToAttackBottom()
    {
        
    }

    private void Move()
    {
        rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized * speed * Time.deltaTime;
    }
}
