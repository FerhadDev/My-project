using System.Collections;
using UnityEngine;

public class UltiDamage : MonoBehaviour
{
    [SerializeField] private float radius = 7f;
    public int damage = 100;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask SlaveLayer;

    void Start()
    {
        Explode();
    }

    void Explode()
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);
        Collider2D[] Slave = Physics2D.OverlapCircleAll(transform.position, radius, SlaveLayer);

        foreach (Collider2D slave in Slave)
        {
            Animator animator = slave.GetComponent<Animator>();
            animator.SetBool("Happy", true);
        }
        foreach (Collider2D enemy in enemiesHit)
        {
            EnemyHealth health = enemy.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
