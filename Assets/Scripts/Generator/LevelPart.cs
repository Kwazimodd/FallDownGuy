using System;
using System.Collections.Generic;
using UnityEngine;


public class LevelPart : MonoBehaviour
{

    public event EventHandler OnPlayerMiddleEnter;

    private LevelGenerator levelGenerator;

    void Start()
    {

    }

    void Update()
    {

    }

    public LevelPart(LevelGenerator levelGenerator) 
    {
        this.levelGenerator = levelGenerator;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPlayerMiddleEnter.Invoke(this, new EventArgs());
        }
    }
}

