using UnityEngine;

public class GongStan : MonoBehaviour
{
    [SerializeField] GameObject GongPrefab;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(GongPrefab, transform.position, Quaternion.identity, transform);
        }
    }
}
