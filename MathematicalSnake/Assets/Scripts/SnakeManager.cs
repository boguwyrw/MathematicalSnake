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
    [HideInInspector] public List<GameObject> SnakeElements = new List<GameObject>();

    private void Start()
    {
        MovementSpeed = FirstLevelSpeed;
        SnakeElements.Add(transform.GetChild(0).gameObject);
    }

    private void Update()
    {
        MovementSpeed -= Time.deltaTime;
        if (MovementSpeed <= 0.0f)
        {
            SnakeCanMove = true;
            MovementSpeed = FirstLevelSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            SnakeController snakeController = SnakeElements[transform.childCount - 1].GetComponent<SnakeController>();

            Vector3 bodyClonePosition = snakeController.PreviousPosition;
            Quaternion bodyCloneRotation = SnakeElements[transform.childCount - 1].transform.localRotation;

            GameObject bodyClone = Instantiate(_bodyPrefab, bodyClonePosition, bodyCloneRotation);
            bodyClone.transform.parent = transform;
        }
    }
}
