using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shoot, bonus;
    public void PlayShootSound()
    {
        audioSource.PlayOneShot(shoot);
    }
    public void PlayBonusSound()
    {
        audioSource.PlayOneShot(bonus);
    }
}
