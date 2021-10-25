using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _coinsText;

    public static int CoinsCount { get; set; }

    private void Update() 
    {
        _coinsText.text = "Coins: " + CoinsCount.ToString();
    }
}
