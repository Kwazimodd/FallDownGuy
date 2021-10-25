using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAtatck : IState
{
    private AngryBall parent;
    private float attackCooldown = 1;
    private float extraRange = .1f;
    
    public void Enter(AngryBall parent)
    {
        this.parent = parent;
        parent.Animator.SetFloat("x", parent.Rigi);
    }

    public void Update()
    {
            
    }
    
    public void Exit()
    {
        
    }
}
