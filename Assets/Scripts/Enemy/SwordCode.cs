using UnityEngine;

public class SwordCode : MonoBehaviour
{
    [SerializeField] private int _EnemyDamage = 10;
    private PlayerController playerController;
    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Player")
        {
            playerController.Damage(_EnemyDamage);
        }
    }
}
