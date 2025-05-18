using System.Collections;
using UnityEngine;

public class UltiDamage : MonoBehaviour
{
    [SerializeField] private float radius = 7f;
    public int damage = 100;
    [SerializeField] private LayerMask enemyLayer;

    void Start()
    {
        Explode();
    }

    void Explode()
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);

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
