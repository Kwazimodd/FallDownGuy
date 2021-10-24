using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    [Header("Required Transforms")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _gridTransform;

    [Header("Level Parts")]
    [SerializeField] private float _offset = 24f;
    [SerializeField] private GameObject[] _parts;

    private int _countOfFirstParts = 2;
    private int _currentIndex = -1; //because player starts before the first part

    private List<LevelPart> _tempParts = new List<LevelPart>();
   
    private Random _random = new Random();


    private void Start()
    {
        for (int i = 0; i < _countOfFirstParts; i++)
            CreateAndSetupPart(i, _random.Next(0, _parts.Length-1));
    }

    public void Generate()
    {
        _currentIndex++;

        //because there is no parts before first one
        if (_currentIndex == 0) return;

        //instatiating next part of level ()
        CreateAndSetupPart((_currentIndex + 1), _random.Next(0, _parts.Length-1));

        //removing previous part
        _tempParts[_currentIndex - 1].gameObject.SetActive(false);
        //_tempParts.RemoveAt(0);
    }

    private void CreateAndSetupPart(int index, int partToGenerate) 
    {
        GameObject newPart = Instantiate(_parts[partToGenerate], new Vector3(0, -1 * index * _offset, 90), Quaternion.identity, _gridTransform);
        _tempParts.Add(newPart.GetComponent<LevelPart>());

        _tempParts[index].LevelGenerator = this;
    }
}
