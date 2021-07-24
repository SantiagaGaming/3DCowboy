using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] spawnObjects;
    private float _timeShoot = 18f;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_timeShoot);
        transform.position = new Vector3(transform.position.x, transform.position.y, Random.Range(6.4f, 9.5f));
        int rnd = Random.Range(0, spawnObjects.Length);
        Instantiate(spawnObjects[rnd], transform.position, transform.rotation);
        StartCoroutine(Spawn());
    }
}
