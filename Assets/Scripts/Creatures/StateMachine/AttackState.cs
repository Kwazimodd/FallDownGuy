using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class AttackState : IState
{
    private AngryBall parent;
    private float attackCooldown = 1;
    private float extraRange = .1f;
    public void Enter(AngryBall parent)
    {
        this.parent = parent;
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        if (!parent.IsAttacking)
        {
            parent.AttackTime += Time.deltaTime;
        } 
        if (parent.AttackTime >= attackCooldown && !parent.IsAttacking)
        {
            
            parent.AttackTime = 0;
            parent.StartCoroutine(Attack());
        }
        if (parent.Target != null)
        {
            float distance = Vector2.Distance(parent.transform.position, parent.Target.position);
            if(distance>=parent.AttackRange+extraRange&& !parent.IsAttacking)
            {
                parent.ChangeState(new FollowState());
            }
        }
        else
        {
            parent.ChangeState(new FollowState());
        }
    }

    public IEnumerator Attack()
    {
        parent.CanDoDamage = true;
        parent.IsAttacking = true;
        parent.Animator.SetBool("attack", true);
        yield return new WaitForSeconds(parent.Animator.GetCurrentAnimatorStateInfo(0).length);
        parent.Animator.SetBool("attack", false);
        parent.IsAttacking = false;
    }
}
