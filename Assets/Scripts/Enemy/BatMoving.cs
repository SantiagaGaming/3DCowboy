using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMoving : MonoBehaviour
{
    private int _speed = 2;
   private float _rndDirection;
    private void Awake()
    {
         _rndDirection = Random.Range(-4, 4);
    }

    void Update()
    {
        transform.Translate(Vector3.right*_speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, _rndDirection, 0) * Time.deltaTime);
    }
}
