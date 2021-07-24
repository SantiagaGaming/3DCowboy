using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObjectsMove : MonoBehaviour
{
    private float _speed = 2f;
    private float _timeToDisable = 25f;

    void Start()
    {
       
        StartCoroutine(SetDisabled());
    }
    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime, Space.World);

        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);

    }


    IEnumerator SetDisabled()
    {
        yield return new WaitForSeconds(_timeToDisable);
        Destroy(gameObject);
    }
}
