using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    bool FaceinRight;
    public float _MovementSpeed;
    public Rigidbody2D _PlayyerRB;
    private Vector2 _MoveDirection;
    [SerializeField] private Animator _Playeranim;

    [Header("Explosion Damage")]
    [SerializeField] private float ExplosioncooldownTime = 5f;
    private float ExplosionnextAttackTime = 0f;
    [SerializeField] private GameObject ExplosionPrefab;

    [Header("Player Health")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Heal Settings")]
    public float healCooldown = 5f; // 5 saniyəlik cooldown
    private float nextHealTime = 0f;
    [Header("Ultimate Damage")]
    [SerializeField] private float UltimatecooldownTime = 5f;
    private float UltimatenextAttackTime = 0f;
    [SerializeField] private GameObject UltimateUltimatePrefab;
    [SerializeField] private Image HealBar;

    private void Start()
    {
        FaceinRight = true;
        currentHealth = maxHealth;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= ExplosionnextAttackTime)
        {
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform);
            ExplosionnextAttackTime = Time.time + ExplosioncooldownTime;
            _Playeranim.SetBool("İsAttack", true);
        }
        if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextHealTime)
        {
            Heal(20);
            nextHealTime = Time.time + healCooldown;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && Time.time >= UltimatenextAttackTime)
        {
            Instantiate(UltimateUltimatePrefab, transform.position, Quaternion.identity, transform);
            UltimatenextAttackTime = Time.time + UltimatecooldownTime;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Damage(20);
        }
            ProcessInputs();
        FlipManager();
    }
    void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        float _moveX = Input.GetAxisRaw("Horizontal");
        float _moveY = Input.GetAxisRaw("Vertical");
        _MoveDirection = new Vector2(_moveX, _moveY).normalized;
    }
    private void Move()
    {
        _PlayyerRB.linearVelocity = new Vector2(_MoveDirection.x * _MovementSpeed, _MoveDirection.y * _MovementSpeed);

        if (_MoveDirection != Vector2.zero)
        {
            _Playeranim.SetBool("IsWalking", true);
            _Playeranim.SetBool("İsAttack", false);
        }
        else
        {
            _Playeranim.SetBool("IsWalking", false);
            _Playeranim.SetBool("İsAttack", false);
        }   
    }
    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
    private void FlipManager()
    {
        if (_MoveDirection.x < 0 && FaceinRight)
        {
            Flip();
            FaceinRight = !FaceinRight;
        }
        else if (_MoveDirection.x > 0 && !FaceinRight)
        {
            Flip();
            FaceinRight = !FaceinRight;
        }
    }
    public void Heal(int amount)
    {
        currentHealth += amount;
        HealBar.fillAmount += 0.2f;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        Debug.Log("Healing applied! Current health: " + currentHealth);
    }
    public void Damage(int amount)
    {
        HealBar.fillAmount -= 0.2f;
        currentHealth -= amount;
    }
}

