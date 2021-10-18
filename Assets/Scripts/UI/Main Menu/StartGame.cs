using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private new Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClick()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
        WaitUntil  waitUntilSceneLoaded = new WaitUntil(() => SceneManager.GetSceneByName("Game").isLoaded);

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game"));
    }
}
