using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMoving : MonoBehaviour
{
    private float _speed = 0.4f;
    [SerializeField] GameObject ghost;
    void Start()
    {
        StartCoroutine(Flying());  
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    IEnumerator Flying()
    {
        float y = -0.25f;

        while (y < 0)
        {
            ghost.transform.localPosition = new Vector3(0, y, 0);
            yield return new WaitForSeconds(0.002f);
            y += 0.01f;
        }
        while (y>-0.25f)
        {
            ghost.transform.localPosition = new Vector3(0, y, 0);
            yield return new WaitForSeconds(0.002f);
            y -= 0.01f;
        }

        StartCoroutine(Flying());

    }
}
