using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _coinsText;

    public static int CoinsCount { get; set; }

    private void Start()
    {
        CoinsCount = 0;
    }

    private void Update() 
    {
        _coinsText.text = "Coins: " + CoinsCount.ToString();
        if (CoinsCount>=80)
        {
            SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        }
    }
}
