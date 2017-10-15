using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float MoveSpeed;
    // Use this for initialization
    void Start()
    {

    }

    void FixedUpdate()
    {
        transform.position += new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
    }
}