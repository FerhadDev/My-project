using UnityEngine;

public class KamciVurus : MonoBehaviour
{
    [SerializeField] private ParticleSystem attackEffect;
    [SerializeField] private int _EnemyDamage = 10;
    [SerializeField] private Animator Bossanim;
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }
    void Attack()
    {
        if (!attackEffect.isPlaying)
        {
            attackEffect.Play();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attack();
            playerController.Damage(_EnemyDamage);
        }
    }
}
