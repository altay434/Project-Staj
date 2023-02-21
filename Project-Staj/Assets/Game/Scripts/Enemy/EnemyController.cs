using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    #region Variables
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private Animator animator;

    [SerializeField] private GameEvent EnemyOnDie;

    public float Damage
    {
        get
        {
            return damage;
        }
    }
    #endregion

    #region Monobehavior Functions
    private void Start()
    {
        health *= StatisticManager.Instance.enemyHealthMultiplier;
        animator.SetBool("isRunning", true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameManager.Instance.enemyControllers.Remove(this.gameObject.GetComponent<EnemyController>());
            Destroy(this.gameObject);
        }

        if (collision.collider.TryGetComponent(out BulletController bulletController))
        {
            health -= bulletController.BulletDamage;
            if (health <= 0)
            {
                Destroy(gameObject);
                EnemyOnDie.Invoke();
            }
        }
    }
    #endregion
}
