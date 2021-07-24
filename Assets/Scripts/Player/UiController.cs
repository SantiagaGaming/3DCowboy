using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public GameObject human;
    public GameObject isGunImg;
    public GameObject isBootImg;
    [SerializeField] Image[] HP;
    [SerializeField] Sprite isLife, nonLife;
    PlayerController _player;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        LifeController();


        //  text.text = Player.GetScore().ToString();

    }
    private void LifeController()
    {
        int curHp = _player.hp;
        for (int i = 0; i < HP.Length; i++)
        {
            if (curHp > i)
                HP[i].sprite = isLife;
            else HP[i].sprite = nonLife;

        }

    }
    }
