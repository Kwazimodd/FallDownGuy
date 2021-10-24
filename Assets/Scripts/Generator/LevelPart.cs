using System;
using System.Collections.Generic;
using UnityEngine;


public class LevelPart : MonoBehaviour
{

    public event EventHandler OnPlayerMiddleEnter;

    public LevelGenerator LevelGenerator { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelGenerator.Generate();
        }
    }
}

