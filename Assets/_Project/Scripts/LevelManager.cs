using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Vector2Int _size;
    [SerializeField] Vector2 _offset;
    [SerializeField] GameObject _brickPrefabRow1;
    [SerializeField] GameObject _brickPrefabRow2;
    [SerializeField] GameObject _brickPrefabRow3;
    [SerializeField] GameObject _brickPrefabRow4;
    [SerializeField] GameObject _brickPrefabRow5;
    
    GameObject _newBrick;

    void Start()
    {
        DrawBricks();    
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
    }
}
