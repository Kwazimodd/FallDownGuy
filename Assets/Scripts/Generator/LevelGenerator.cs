using System;
using System.Collections.Generic;

using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    
    [Header("Level Parts")]
    [SerializeField] private GameObject[] _parts;

    private int _countOfFirstParts = 3;

    private float _offset = 11f;

    private List<LevelPart> _tempParts = new List<LevelPart>();

    private void Start()
    {
        for (int i = 0; i < _countOfFirstParts; i++) 
        {
            Instantiate(_parts[0], new Vector3(0, -1 * i * _offset, 90), Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {

    }
}
