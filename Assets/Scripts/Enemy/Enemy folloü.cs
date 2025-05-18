using Unity.VisualScripting;
using UnityEngine;

public class Enemyfolloü : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float Speed;
    private float maxdistance;

    void Update()
    {
        maxdistance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (maxdistance < 7 && maxdistance > 2)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}
