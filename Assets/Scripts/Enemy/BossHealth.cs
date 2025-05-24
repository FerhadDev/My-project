using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField] int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Ölüm animasiyası və s.
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
}
