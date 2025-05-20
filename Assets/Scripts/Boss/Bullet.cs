using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float max;
    [SerializeField] private float min;
    private Transform Player;
    private Vector2 target;
    float maxdistance;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(Player.position.x, Player.position.y);
    }
    void Update()
    {
        if(Player != null)
        {
            maxdistance = Vector2.Distance(transform.position, Player.transform.position);
            
                transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
                if (transform.position.x == target.x && transform.position.y == target.y)
                {
                    DestroyPrjecttile();

                }
        }
    }
    void OTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DestroyPrjecttile();
        }
    }
    void DestroyPrjecttile()
    {
        Destroy(gameObject);
    }
}
