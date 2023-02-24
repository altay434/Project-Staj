using UnityEngine;

public class Resetter : MonoBehaviour
{
    [SerializeField] private BulletData bulletData;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private EnemyData speedyData;
    [SerializeField] private EnemyData tankData;
    [SerializeField] private PowerUp attackSpeedPowerUp;
    [SerializeField] private PowerUp damagePowerUp;
    [SerializeField] private PowerUp numberOfShotsPowerUp;
    [SerializeField] private Resource gold;
    [SerializeField] private Resource time;
    [SerializeField] private Stat spawnInterval;
    [SerializeField] private Stat enemyHealthMultiplier;
    [SerializeField] private Stat spawnIntervalMultiplier;
    [SerializeField] private Transform playerTransform;


    private void Awake()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        attackSpeedPowerUp.Cost = 20;
        attackSpeedPowerUp.Level = 0;
        attackSpeedPowerUp.MaxLevel = 11;
        attackSpeedPowerUp.StatChangeAmount = 0.1f;

        damagePowerUp.Cost = 20;
        damagePowerUp.Level = 0;
        damagePowerUp.MaxLevel = 42;
        damagePowerUp.StatChangeAmount = 5;

        numberOfShotsPowerUp.Cost = 20;
        numberOfShotsPowerUp.Level = 0;
        numberOfShotsPowerUp.MaxLevel = 3;
        numberOfShotsPowerUp.StatChangeAmount = 1;

        gold.Amount = 1000;
        time.Amount = 120;

        spawnInterval.Amount = 3;
        enemyHealthMultiplier.Amount = 1.1f;
        spawnIntervalMultiplier.Amount = 1.1f;

        playerTransform.position = new Vector3(0, 0, 0);
    }

}
