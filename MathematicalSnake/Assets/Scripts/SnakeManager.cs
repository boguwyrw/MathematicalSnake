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

    private float FirstLevelSpeed = 1.1f;

    [HideInInspector] public float MovementSpeed = 0.0f;
    [HideInInspector] public bool SnakeCanMove = false;

    private void Start()
    {
        MovementSpeed = FirstLevelSpeed;
    }

    private void Update()
    {
        MovementSpeed -= Time.deltaTime;
        if (MovementSpeed <= 0.0f)
        {
            SnakeCanMove = true;
            MovementSpeed = FirstLevelSpeed;
        }
    }

    public void CreateSnakeBody()
    {
        GameObject bodyClone = Instantiate(_bodyPrefab);
        bodyClone.transform.parent = transform;

        MathematicalGenerator.Instance.GenerateMathematicalEquation();
    }
}
