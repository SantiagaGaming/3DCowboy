using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private float _speed = 5f;
    private float _timeToDisable = 5f;
    private PlayerController _player;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).GetComponent<PlayerController>();

    }
    private void Start()
    {
        StartCoroutine(SetDisabled());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == Tags.ENEMY_TAG)
        {
            collision.gameObject.GetComponent<IGameObject>().Damage(-1);
            _player.RecountScore(10);
            Destroy(gameObject);
      
        }
    }

    IEnumerator SetDisabled()
    {
        yield return new WaitForSeconds(_timeToDisable);
        Destroy(gameObject);
    }
}
