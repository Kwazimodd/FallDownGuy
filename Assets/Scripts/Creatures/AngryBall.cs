using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBall : MonoBehaviour
{
    [SerializeField] private int health = 3;
    private Animator animator;

    public Animator Animator => this.animator;

    private IState currentState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(int damage)
    {
        health -= damage;
    }

    public void changeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter(this);
    }
}
