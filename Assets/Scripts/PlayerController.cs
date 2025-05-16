using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _MovementSpeed;
    public Rigidbody2D _PlayyerRB;
    private Vector2 _MoveDirection;

    void Update()
    {
        ProcessInputs();
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
}
