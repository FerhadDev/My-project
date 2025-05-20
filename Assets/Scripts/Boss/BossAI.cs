using UnityEngine;

public class BossAI : MonoBehaviour
{
    [SerializeField] private float EnemySpeed;
    [SerializeField] private float Stopingdistance;
    [SerializeField] private float retreatDistance;
    private Transform Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if(Player != null)
        {
            if (Vector2.Distance(transform.position, Player.position) > Stopingdistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Player.position, EnemySpeed * Time.deltaTime);
                }
                else if (Vector2.Distance(transform.position, Player.position) < Stopingdistance && Vector2.Distance(transform.position, Player.position) > retreatDistance)
                {
                    transform.position = this.transform.position;
                }
                else if (Vector2.Distance(transform.position, Player.position) < retreatDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Player.position, -EnemySpeed * Time.deltaTime);
                }
        }
    }
}
