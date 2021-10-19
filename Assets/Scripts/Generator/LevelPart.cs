using System;
using System.Collections.Generic;
using UnityEngine;


public class LevelPart : MonoBehaviour
{

    public event EventHandler OnPlayerMiddleEnter;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPlayerMiddleEnter.Invoke(this, new EventArgs());
        }
    }
}

