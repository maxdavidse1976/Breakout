using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] float _ballSpeed = 4f;
    [SerializeField] float _bottomBounds = -4.8f;
    [SerializeField] GameObject _youWinPanel;
    [SerializeField] GameObject _gameOverPanel;

    public TMP_Text scoreText;
    public float score = 0;
    public int lives = 5;
    public GameObject[] livesImage;
    public int brickCount;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        DropBall();
    }

    void Update()
    {
        if (transform.position.y < _bottomBounds || Input.GetKeyDown(KeyCode.R))
        {
            lives--;
            if (lives <= 0) 
            { 
                _gameOverPanel.SetActive(true);
                Time.timeScale = 0;
            }
            livesImage[lives].SetActive(false);
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

            score += 10;
            scoreText.text = score.ToString("00000");
            brickCount--;

            if (brickCount <= 0)
            {
                _youWinPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
