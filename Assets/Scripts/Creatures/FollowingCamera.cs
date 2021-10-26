using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    private new Transform transform;

    [SerializeField]
    private GameObject aimObject;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        GoToAimObject();
    }

    private void LateUpdate()
    {
       
    }

    private void GoToAimObject()
    {
        transform.position = new Vector3
        (
            transform.position.x,
            Math.Min(aimObject.GetComponent<Transform>().position.y, transform.position.y),
            transform.position.z
        );
    }
}
