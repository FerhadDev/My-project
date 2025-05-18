using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float radius = 3f;
    public int damage = 50;
    [SerializeField] private LayerMask enemyLayer;

    void Start()
    {
        StartCoroutine(GrowExplosion());
        Explode();
    }
    void Update()
    {
        
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
    IEnumerator GrowExplosion()
{
    float duration = 0.5f;
    float timer = 0f;

    Vector3 initialScale = Vector3.zero;
    Vector3 targetScale = Vector3.one * radius * 2f;

    transform.localScale = initialScale;

    while (timer < duration)
    {
        timer += Time.deltaTime;
        transform.localScale = Vector3.Lerp(initialScale, targetScale, timer / duration);
        yield return null;
    }

    transform.localScale = targetScale;
}
}
