using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCat : MoveBase
{
    GameObject player;
    float playerDistanceFind = 5.0f;
    private void Start() 
    {
        player = GameObject.Find("Player");
        SetSpeed();
    }
    protected override void SetSpeed()
    {
        Speed = 10.0f;
    }
    protected override void Jump()
    {
    }

    protected override void Move()
    {
        FollowGameObject(this.player, this.playerDistanceFind);
    }
}
