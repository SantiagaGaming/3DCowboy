using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IGameObject
{
    private int _hp = 1;
    private float _timeToDisable = 25f;
    private void Start()
    {
        StartCoroutine(SetDisabled());
    }
    public void Damage(int dmg)
    {
        _hp += dmg;
        if (_hp >= 0)
            Death();
    }

    public void Death()
    {
        StartCoroutine(DeathC());
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == Tags.PLAYER_TAG)
        {
            collision.gameObject.GetComponent<IGameObject>().Damage(-1);
          
        }
    }


    IEnumerator DeathC()
    { float scale = 0.9f;
        while (scale >= 0) 
        {
        yield return new WaitForSeconds(0.05f);
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
            scale -= 0.1f;
        }
        Destroy(gameObject);

    }

    IEnumerator SetDisabled()
    {
        yield return new WaitForSeconds(_timeToDisable);
        Destroy(gameObject);
    }
}
