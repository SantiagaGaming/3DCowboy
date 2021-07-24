using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour, IGameObject
{
    [HideInInspector] public int hp = 3;
    [HideInInspector] public bool isBoosted = false;
    [HideInInspector] public bool isGun = false;
    [SerializeField] private Text scoreText;
    private int _score;
    private UiController _uiController;
    private PlayerMovement _playerMOvement;
   private Shooting _shooting;
    private void Awake()
    {
        _uiController = GetComponent<UiController>();
        _playerMOvement = GetComponent<PlayerMovement>();
        _shooting = GetComponent<Shooting>();

    }

    public void Damage(int dmg)
    {
        hp += dmg;
        Mathf.Clamp(hp, 0, 3);
        if (hp <= 0)
            Death();
    }

    public void Death()
    {
        _playerMOvement.isAlive = false;
        StartCoroutine(DeathC());
    }

    void Update()
    {
   BonusStarter();
        ScoreToString();
    }
 IEnumerator SpeedBoost()
    {
        _uiController.isBootImg.SetActive(true);
        _playerMOvement.moveSpeed = 4;
            yield return new WaitForSeconds(10);
        _playerMOvement.moveSpeed = 2;
        _uiController.isBootImg.SetActive(false);
        isBoosted = false;

    }
  IEnumerator ShootBonus()
    {
        _uiController.isGunImg.SetActive(true);
        _shooting.timeToShoot = 0.5f;
        yield return new WaitForSeconds(10f);
        _shooting.timeToShoot = 3f;
        _uiController.isGunImg.SetActive(false);
        isGun = false;

    }
    private void BonusStarter()
    {
        if (isBoosted)
            StartCoroutine(SpeedBoost());
        if (isGun)
            StartCoroutine(ShootBonus());

    }
    IEnumerator DeathC()
    {
        int y = 3;
        while (y <= 100) {

            _uiController.human.transform.position = new Vector3(_uiController.human.transform.position.x, y, _uiController.human.transform.position.z);
        yield return new WaitForSeconds(0.1f);
            y++;
            print("DMG");
        }
    }
   private void ScoreToString()
    {
        scoreText.text = _score.ToString();
    }
    public void RecountScore(int newScore)
    {
        _score += newScore;
    }
}
