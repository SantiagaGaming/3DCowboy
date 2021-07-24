using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField] GameObject ghost;
    [SerializeField] GameObject bat;
    private float _timeSpawn = 8f;
    void Start()
    {
        StartCoroutine(Spawn(ghost, _timeSpawn));
        StartCoroutine(Spawn(bat, _timeSpawn*2));

    }

    IEnumerator Spawn(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = new Vector3(transform.position.x,  transform.position.y, Random.Range(6.4f, 9.5f));
        Instantiate(obj, transform.position, transform.rotation);
        StartCoroutine(Spawn(obj,time));
    }


}
