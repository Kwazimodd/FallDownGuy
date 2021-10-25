using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public interface IState
{
    void Enter(AngryBall parent);
    void Exit();
    void Update();
}
