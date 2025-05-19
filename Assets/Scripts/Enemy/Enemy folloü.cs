using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemyfolloü : MonoBehaviour
{
    [SerializeField] GameObject Sword;
    Animator anim;
    Transform player;
    [SerializeField] private GameObject Player;
    [SerializeField] private float Speed;
    private float maxdistance;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
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
        if (maxdistance < 7 && maxdistance > 1)
        {
            anim.SetBool("See", true);
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Speed * Time.deltaTime);
            transform.rotation = Quaternion.identity;
        }
        else
        {
            anim.SetBool("See", false);
        }
        if (maxdistance < 2)
        {
            StartCoroutine(Attack());
        }
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    IEnumerator Attack()
    {
        anim.SetTrigger("Atack");
        Sword.SetActive(true);
        yield return new WaitForSeconds(1);
        Sword.SetActive(false);
    }
}
