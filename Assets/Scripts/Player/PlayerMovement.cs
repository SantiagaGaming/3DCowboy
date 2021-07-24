using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private Rigidbody _rb;
    [HideInInspector] public float moveSpeed = 2f;
   [HideInInspector] public bool isAlive = true;
    private bool _isLeftMoving = false;
    private bool _isRightMoving = false;


    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_isLeftMoving)
        { Moving(-moveSpeed);
        }
        if (_isRightMoving)
        {
            Moving(moveSpeed);
        }
    }

    private void Moving(float move)
    {
        Vector3 movement = transform.right * move * Time.deltaTime;
        _rb.MovePosition(_rb.position + movement);
    }

    public void RightMoving()
    {
        _isRightMoving = true;


    }
    public void LeftMoving()
    {
        _isLeftMoving = true;

    }
    public void Idle()
    {
        _isLeftMoving = false;
        _isRightMoving = false;

    }
}
