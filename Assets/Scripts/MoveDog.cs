using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class MoveDog : MoveBase
{ 
    GameObject player;
    float playerDistanceFind = 10.0f;
    private void Start() 
    {
        player = GameObject.Find("Player");
        SetSpeed();
    }
    protected override void SetSpeed()
    {
        Speed = 2.0f;
    }
    protected override void Jump()
    {
    }

    protected override void Move()
    {
        FollowGameObject(this.player, this.playerDistanceFind);
    }

}
