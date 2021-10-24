using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _gridTransform;


    [Header("Level Parts")]
    [SerializeField] private GameObject[] _parts;

    [SerializeField] private float _offset = 10f;

    private int _countOfFirstParts = 2;

    private int _currentIndex = 0;


    private List<LevelPart> _tempParts = new List<LevelPart>();

    private void Start()
    {
        for (int i = 0; i < _countOfFirstParts; i++) 
        {
            GameObject newPart = Instantiate(_parts[0], new Vector3(0, -1 * i * _offset, 90), Quaternion.identity, _gridTransform);
            _tempParts.Add(newPart.GetComponent<LevelPart>());
            _tempParts[i].LevelGenerator = this;
        }
    }

    private void FixedUpdate()
    {

    }

    public void Generate() 
    {
        _currentIndex++;

        //because there is no parts before first one
        if (_currentIndex == 1) return;

        //instatiating next part of level
        GameObject newPart = Instantiate(_parts[0], new Vector3(0, -1 * _currentIndex + 1 * _offset, 90), Quaternion.identity);
        
        _tempParts.Add(newPart.GetComponent<LevelPart>());
        _tempParts[_currentIndex+1].LevelGenerator = this;


        //removing previous part
        GameObject.Destroy(_tempParts[0]);
        _tempParts.RemoveAt(0);
    }
}
