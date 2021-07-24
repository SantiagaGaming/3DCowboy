using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private GameObject bulletLight;
    private bool _shootTime = true;
    [HideInInspector] public float timeToShoot = 3f;
    private PlayerMovement _playerMovement;
    [SerializeField]private SoundEffector soundEffector;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
   
    }


   public void Shoot()
    {if (_playerMovement.isAlive && _shootTime) { 
        Instantiate(bullet, bulletTransform.transform.position, transform.rotation);
        StartCoroutine(Shoter());
            soundEffector.PlayShootSound();
        }
    }

    IEnumerator Shoter()
    {
        bulletLight.SetActive(true);
        _shootTime = false;
        yield return new WaitForSeconds(0.2f);
        bulletLight.SetActive(false);
        yield return new WaitForSeconds(timeToShoot);
        _shootTime = true;
    }
    }
