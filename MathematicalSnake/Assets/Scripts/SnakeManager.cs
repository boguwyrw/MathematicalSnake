using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    #region SnakeManager_Singleton
    private static SnakeManager _instance;

    public static SnakeManager Instance
    {
        get
        {
            if (_instance == null) _instance = new SnakeManager();
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    [SerializeField] private GameObject _bodyPrefab;

    [SerializeField] private GameUIManager _gameUIManager;

    [SerializeField] private float _firstLevelSpeed = 1.1f;
    [SerializeField] private float _secondLevelSpeed = 0.9f;
    [SerializeField] private float _thirdLevelSpeed = 0.7f;
    [SerializeField] private float _fourthLevelSpeed = 0.5f;
    [SerializeField] private float _fifthLevelSpeed = 0.3f;

    [SerializeField] private int _levelStepIncrease = 2;

    private float[] _levelsSpeed = new float[5];
    private float _currentMovementSpeed;

    private int _levelSpeedIndex = 0;
    private int _actualSnakeLength = 0;

    [HideInInspector] public float MovementSpeed = 0.0f;
    [HideInInspector] public bool SnakeCanMove = false;

    private void Start()
    {
        _levelsSpeed[0] = _firstLevelSpeed;
        _levelsSpeed[1] = _secondLevelSpeed;
        _levelsSpeed[2] = _thirdLevelSpeed;
        _levelsSpeed[3] = _fourthLevelSpeed;
        _levelsSpeed[4] = _fifthLevelSpeed;
        _currentMovementSpeed = _levelsSpeed[_levelSpeedIndex];
        MovementSpeed = _currentMovementSpeed;

        _actualSnakeLength = transform.childCount;

        _gameUIManager.UpdateSnakeLengthText(_actualSnakeLength - 1);
    }

    private void Update()
    {
        MovementSpeed -= Time.deltaTime;
        if (MovementSpeed <= 0.0f)
        {
            SnakeCanMove = true;
            MovementSpeed = _currentMovementSpeed;
        }
    }

    public void CreateSnakeBody()
    {
        GameObject bodyClone = Instantiate(_bodyPrefab);
        bodyClone.transform.SetParent(transform);
    }

    public void SetNextLevelSpeed()
    {
        if (_levelSpeedIndex < _levelsSpeed.Length - 1)
        {
            int nextLevelStep = _levelStepIncrease + _actualSnakeLength;
            int snakeLength = transform.childCount;
            if (snakeLength == nextLevelStep)
            {
                _levelSpeedIndex += 1;
            Debug.Log("_levelSpeedIndex: " + _levelSpeedIndex);

                _currentMovementSpeed = _levelsSpeed[_levelSpeedIndex];
                //MovementSpeed = 0.0f;
            }
        }
        _actualSnakeLength = transform.childCount;

        _gameUIManager.UpdateSnakeLengthText(_actualSnakeLength - 1);
    }
}
