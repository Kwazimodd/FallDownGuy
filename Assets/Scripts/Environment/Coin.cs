using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Coin : MonoBehaviour
{
    private Tilemap _tilemap;

    private void OnEnable()
    {
        _tilemap = GetComponentInParent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            UIManager.CoinsCount++;
        }
    }
}
