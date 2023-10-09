using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] float _paddleSpeed = 5f;
    float _movementHorizontal;

    void Update()
    {
        _movementHorizontal = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * _movementHorizontal * _paddleSpeed * Time.deltaTime;
    }
}
