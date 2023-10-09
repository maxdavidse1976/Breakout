using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] float _ballSpeed = 4f;
    [SerializeField] float _bottomBounds = -4.8f;
    [SerializeField] float _score = 0;
    [SerializeField] int _lives = 5;
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] GameObject[] _livesImage;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        DropBall();
    }

    void Update()
    {
        if (transform.position.y < _bottomBounds || Input.GetKeyDown(KeyCode.R))
        {
            _lives--;
            _livesImage[_lives].SetActive(false);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);

            _score += 10;
            _scoreText.text = _score.ToString("00000");
        }
    }
}
