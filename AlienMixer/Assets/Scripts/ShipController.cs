using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D _rigidbody;
    private bool facingRight = true;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput < 0)
        {
            MoveLeft();
            if (facingRight) Flip(); // Flip to face left
        }
        else if (horizontalInput > 0)
        {
            MoveRight();
            if (!facingRight) Flip(); // Flip to face right
        }
        else
        {
            StopMoving();
        }

        // Ограничение позиции героя
        Camera camera = Camera.main;
        float minX = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane)).x;
        float maxX = camera.ViewportToWorldPoint(new Vector3(1, 0, camera.nearClipPlane)).x;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
    }

    private void MoveLeft()
    {
        _rigidbody.velocity = new Vector2(-speed, _rigidbody.velocity.y);
    }

    private void MoveRight()
    {
        _rigidbody.velocity = new Vector2(speed, _rigidbody.velocity.y);
    }

    private void StopMoving()
    {
        _rigidbody.velocity = Vector2.zero;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
