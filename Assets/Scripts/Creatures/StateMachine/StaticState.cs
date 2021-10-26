using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class StaticState : IState
{
    private AngryBall parent;
    public void Enter(AngryBall parent)
    {
        this.parent = parent;
    }

    public void Exit()
    {

    }

    public void Update()
    {
        if (parent.Target != null)
        {
            parent.ChangeState(new FollowState());
        }
    }
}
