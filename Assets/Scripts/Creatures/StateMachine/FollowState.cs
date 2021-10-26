using System;
using UnityEngine;

class FollowState : IState
{
    private AngryBall parent;
    public void Enter(AngryBall parent)
    {
        this.parent = parent;
    }

    public void Exit()
    {
        parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void Update()
    {   
        parent.Animator.SetInteger("x", (int)parent.GetComponent<Rigidbody2D>().velocity.normalized.x);
        if(parent.Target!=null)
        {
            parent.MoveTo(new Vector2(parent.Target.transform.position.x - parent.transform.position.x, 0));
            float distance = Vector2.Distance(parent.transform.position, parent.Target.position);
            if(distance<=parent.AttackRange)
            {
                parent.ChangeState(new AttackState());
            }
        }
    }
}
