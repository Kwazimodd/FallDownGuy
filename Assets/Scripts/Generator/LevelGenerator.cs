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
    [SerializeField] private int _countOfPartsWithCoins = 10;
    [SerializeField] private float _offset = 24f;
    [SerializeField] private GameObject[] _parts;

    private int _countOfFirstParts = 3;
    
    private int _currentIndex = -1; //because player starts before the first part

    private List<LevelPart> _tempParts = new List<LevelPart>();
   
    private Random _random = new Random();


    private void Start()
    {
        for (int i = 0; i < _countOfFirstParts; i++)
            CreateAndSetupPart(i, i);
    }

    public void Generate()
    {
        _currentIndex++;
           
        //because there is no parts before first one and there is no need to spawn level after boss level
        if (_currentIndex < 2) 
            return;

        if (_currentIndex > _countOfPartsWithCoins) 
        {
            SpawnBoss();
        }

        int rangeOfParts = _random.Next(1, _parts.Length - 2);

        //setting for the generation last level
        if (_currentIndex == _countOfPartsWithCoins)
            rangeOfParts = _parts.Length - 1;

        //instatiating next part of level, despite last part with boss
        CreateAndSetupPart((_currentIndex + 1), rangeOfParts);

        //removing part before previous
        _tempParts[_currentIndex - 2].gameObject.SetActive(false);
    }

    private void CreateAndSetupPart(int index, int partToGenerate) 
    {
        GameObject newPart = Instantiate(_parts[partToGenerate], new Vector3(0, -1 * index * _offset, 90), Quaternion.identity, _gridTransform);
        _tempParts.Add(newPart.GetComponent<LevelPart>());

        _tempParts[index].LevelGenerator = this;
    }

    private void SpawnBoss()
    {
        Transform boss = _tempParts[_currentIndex].gameObject.transform.Find("Boss");
        boss.gameObject.SetActive(true);
    }
}
