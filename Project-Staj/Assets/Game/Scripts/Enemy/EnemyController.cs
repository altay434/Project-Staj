using UnityEngine;
using ninjahero.events;
using Unity.VisualScripting;

public class EnemyController : MonoBehaviour
{


    [SerializeField] private Animator animator;
    [SerializeField] private GameEvent EnemyOnDie;
    [SerializeField] private GameEvent OnGoldChange;
    [SerializeField] private BulletData bulletData;
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private Resource gold;
    [SerializeField] private float health;
    private float damageFromSkill = 200f;

    private void Start()
    {
        health = enemyData.Health;
        animator.SetBool("isRunning", true);
    }

    public float GetDamage()
    {
        return enemyData.Damage;
    }

    public EnemyData GetEnemyData()
    {
        return enemyData;
    }
 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out PlayerController playerController))
        {
            Destroy(gameObject);
        }

        else if (collision.collider.TryGetComponent(out BulletController bulletController))
        {
            health -= bulletData.Damage;
            CheckForDie();
        }
    }
    public void GetDamageFromSkill()
    {
        health -= damageFromSkill;
        CheckForDie();
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    public void CheckForDie()
    {
        if (health <= 0)
        {
            gold.Amount += enemyData.Prize;
            EnemyOnDie.Invoke();
            Destroy(gameObject);
        }
    }
}
