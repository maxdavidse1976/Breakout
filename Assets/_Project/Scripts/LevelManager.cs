using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] BallController _ballController;
    [SerializeField] Vector2Int _size;
    [SerializeField] Vector2 _offset;
    [SerializeField] GameObject _brickPrefabRow1;
    [SerializeField] GameObject _brickPrefabRow2;
    [SerializeField] GameObject _brickPrefabRow3;
    [SerializeField] GameObject _brickPrefabRow4;
    [SerializeField] GameObject _brickPrefabRow5;
    [SerializeField] GameObject _youWinPanel;
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] GameObject _exitGamePanel;
    [SerializeField] GameObject _paddle;

    GameObject _newBrick;

    void Start()
    {
        DrawBricks();    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && 
            !_gameOverPanel.activeInHierarchy && 
            !_youWinPanel.activeInHierarchy) 
        {
            ExitGameOptions();
        }
    }

    void DrawBricks()
    {
        for (int i = 0; i < _size.x; i++)
        {
            for (int j = 2; j < _size.y; j++)
            {
                switch(j)
                {
                    case 2:
                        _newBrick = Instantiate(_brickPrefabRow1, transform);
                        break;
                    case 3:
                        _newBrick = Instantiate(_brickPrefabRow2, transform);
                        break;
                    case 4:
                        _newBrick = Instantiate(_brickPrefabRow3, transform);
                        break;
                    case 5:
                        _newBrick = Instantiate(_brickPrefabRow4, transform);
                        break;
                    case 6:
                        _newBrick = Instantiate(_brickPrefabRow5, transform);
                        break;
                }

                _newBrick.transform.position = transform.position + new Vector3((float)((_size.x - 1) * .5f - i) * _offset.x, j * _offset.y, 0);
            }
        }
        _ballController.brickCount = transform.childCount;
    }

    void UnhideBricks()
    {
        for (int i = 0; i <= transform.childCount - 1; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        _ballController.brickCount = transform.childCount;
    }

    public void PlayAgain()
    {
        _youWinPanel.SetActive(false);
        _gameOverPanel.SetActive(false);
        for (int i =0; i <= 4; i++)
        {
            _ballController.livesImage[i].SetActive(true);
        }
        _ballController.lives = 5;
        _ballController.score = 0;
        _ballController.scoreText.text = _ballController.score.ToString("00000");
        _paddle.transform.position = new Vector3(0, _paddle.transform.position.y, _paddle.transform.position.z);
        _ballController.ResetBall();
        Time.timeScale = 1;
        UnhideBricks();
    }

    void ExitGameOptions()
    {
        Time.timeScale = 0;
        _exitGamePanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NoExitGame()
    {
        Time.timeScale = 1;
        _exitGamePanel.SetActive(false);
    }
}
