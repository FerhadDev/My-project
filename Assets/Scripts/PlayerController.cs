using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool FaceinRight;
    public float _MovementSpeed;
    public Rigidbody2D _PlayyerRB;
    private Vector2 _MoveDirection;

    private void Start()
    {
        FaceinRight = true;
    }
    void Update()
    {
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
}
