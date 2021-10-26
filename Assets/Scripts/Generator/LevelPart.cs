using System;
using System.Collections.Generic;
using UnityEngine;


public class LevelPart : MonoBehaviour
{
    public LevelGenerator LevelGenerator { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelGenerator.Generate();
            Debug.Log("Entered");
        }

        GetComponent<Collider2D>().enabled = false;
    }
}

