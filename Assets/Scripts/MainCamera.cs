using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    private Vector3 offset = new Vector3(0, 24.5f, -16.5f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = playerGameObject.transform.position + this.offset;
    }
}
