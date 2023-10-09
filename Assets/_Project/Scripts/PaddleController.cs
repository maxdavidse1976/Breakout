using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] float _paddleSpeed = 5f;
    [SerializeField] float _maxBounds = 7.5f;
    [SerializeField] float _minBounds = -7.5f;

    float _movementHorizontal;

    void Update()
    {
        _movementHorizontal = Input.GetAxis("Horizontal");
        if ((_movementHorizontal > 0 && transform.position.x < _maxBounds) || (_movementHorizontal < 0 && transform.position.x > _minBounds))
        {
            transform.position += Vector3.right * _movementHorizontal * _paddleSpeed * Time.deltaTime;
        }
    }
}
