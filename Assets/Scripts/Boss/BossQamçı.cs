using UnityEngine;

public class BossQamçı : MonoBehaviour
{
    [SerializeField] private ParticleSystem attackEffect;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }
    }
    void Attack()
    {
        if (!attackEffect.isPlaying)
        {
            attackEffect.Play();
        }
    }

}
