using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] float _ballSpeed = 4f;
    [SerializeField] float _bottomBounds = -4.8f;
    [SerializeField] float _topBounds = 4.8f;
    [SerializeField] float _leftBounds = -7.8f;
    [SerializeField] float _rightBounds = -7.8f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        DropBall();
    }

    void Update()
    {
        if (transform.position.y < _bottomBounds)
        {
            ResetBall();
        }
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        DropBall();
    }

    void DropBall()
    {
        _rigidbody.velocity = Vector2.down * _ballSpeed;
    }
}
