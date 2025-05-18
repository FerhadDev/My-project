using System.Collections;
using UnityEngine;

public class GongPrefab : MonoBehaviour
{
    [SerializeField] private float radius = 17f;
    [SerializeField] private LayerMask enemyLayer;

    void Start()
    {
        Explode();
    }

    void Explode()
    {
        StartCoroutine(Stans());
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    IEnumerator Stans()
    {
        print("sa");
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);
        foreach (Collider2D enemy in enemiesHit)
        {
            Enemyfolloü follow = enemy.GetComponent<Enemyfolloü>();
            if (follow != null)
            {
                follow.enabled = false;
            }
        }
        yield return new WaitForSeconds(2);
        foreach (Collider2D enemy in enemiesHit)
        {
            print("as");
            Enemyfolloü follow = enemy.GetComponent<Enemyfolloü>();
            if (follow != null)
            {
                follow.enabled = true;
            }
        }
    }
}
