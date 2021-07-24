using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObject : MonoBehaviour
{
    [SerializeField] private bool isHeart;
    [SerializeField] private bool isBoots;
    [SerializeField] private bool isGun;
   private PlayerController _player;
   private SoundEffector _soundEffector;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).GetComponent<PlayerController>();
        _soundEffector= GameObject.FindGameObjectWithTag(Tags.SOUNDS_TAG).GetComponent<SoundEffector>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == Tags.PLAYER_TAG && isHeart)
        {
            _soundEffector.PlayBonusSound();
            collision.gameObject.GetComponent<IGameObject>().Damage(1);
            Destroy(gameObject);
         

        }
        if (collision.gameObject.tag == Tags.PLAYER_TAG && isBoots)
        {
            _soundEffector.PlayBonusSound();
            _player.isBoosted = true;
            Destroy(gameObject);
        

        }
        if (collision.gameObject.tag == Tags.PLAYER_TAG && isGun)
        {
            _soundEffector.PlayBonusSound();
            _player.isGun = true;
            Destroy(gameObject);

        }

    }

}
