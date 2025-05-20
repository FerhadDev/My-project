using UnityEngine;

public class BossAI : MonoBehaviour
{
    [SerializeField] private float EnemySpeed;
    [SerializeField] private float max = 7;
    [SerializeField] private float min = 1;
    [SerializeField] private GameObject Player;
    private float maxdistance;
    private Transform player;
    private float timeBTWShots;
    public float StarttimeBTWShots;
    public Transform projecttile;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBTWShots = StarttimeBTWShots;
    }
    void Update()
    {
        if (Player != null)
        {
            Vector3 direct = player.position - transform.position;
            if (direct.x > 0 && transform.localScale.x < 0)
            {
                Flip();
            }
            else if (direct.x < 0 && transform.localScale.x > 0)
            {
                Flip();
            }
            maxdistance = Vector2.Distance(transform.position, Player.transform.position);
            Vector2 direction = Player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (maxdistance < max && maxdistance > min)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, EnemySpeed * Time.deltaTime);
                transform.rotation = Quaternion.identity;

                if (timeBTWShots <= 0)
                {
                    Instantiate(projecttile, transform.position, Quaternion.identity);
                    timeBTWShots = StarttimeBTWShots;
                }
                else
                {
                    timeBTWShots -= Time.deltaTime;
                }
            }
        }
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
