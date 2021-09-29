using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// ABSTRACTION.
abstract public class MoveBase : MonoBehaviour
{

    private bool isGrounded = true;
    protected float jumpForce = 300f;
    private Rigidbody playerRigidBody;
    private float m_Speed;

    // ENCAPSULATION
    public float Speed 
    { 
        get {
            return m_Speed; 
        }
        protected set {
            if (value > 15.0f)
            {
                Debug.LogError("Speed cannot be greater than 15.0f.");
                m_Speed = 15.0f;
            } else if (value < 0f){
                value = 0.0f;
            }else {
                m_Speed = value;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Start()
    {
        this.playerRigidBody = this.GetComponent<Rigidbody>();
        SetSpeed();
    }

    // ABSTRACTION.
    protected abstract void SetSpeed();

    // POLYMORPHISM
    protected virtual void Move()
    {

    }

    // POLYMORPHISM
    protected void Move(Vector3 horizontalVector, Vector3 verticalVector)
    {
        this.transform.Translate((horizontalVector + verticalVector).normalized * Time.deltaTime * Speed);
    }
    
    // POLYMORPHISM
    protected void Move(Vector3 moveVector)
    {
        this.transform.Translate(moveVector.normalized * Time.deltaTime * Speed);
    }

    protected virtual void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            this.playerRigidBody.AddForce(Vector3.up * this.jumpForce, ForceMode.Impulse);
            this.isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Floor"))
            this.isGrounded = true;
        if (other.gameObject.CompareTag("Animal"))
            if (Application.isEditor)
                EditorApplication.ExitPlaymode();
            else
                Application.Quit();
    }


    protected void FollowGameObject(GameObject followingObject, float distanceFind)
    {
        Vector3 playerDistanceVector = followingObject.transform.position - this.transform.position;
        Debug.Log(playerDistanceVector);
        Vector3 moveVector;
        if (playerDistanceVector.magnitude <= distanceFind)
            moveVector = playerDistanceVector;
        else
            moveVector = Vector3.zero;
        Move(moveVector);
    }
}
