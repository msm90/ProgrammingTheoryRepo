using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class MovePlayer : MoveBase
{    

    protected override void Move()
    {
        Vector3 moveHorizontal = Vector3.right * Input.GetAxisRaw("Horizontal");
        Vector3 moveVertical = Vector3.forward * Input.GetAxisRaw("Vertical");
        Move(moveHorizontal, moveVertical);
    }
    protected override void SetSpeed()
    {
        Speed = 5.0f;
    }
    

}
