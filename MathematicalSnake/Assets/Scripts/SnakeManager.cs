using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    [SerializeField] private GameObject _bodyPrefab;

    private List<GameObject> _snakeElements = new List<GameObject>();

    private void Start()
    {
        _snakeElements.Add(transform.GetChild(0).gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SnakeController snakeController = _snakeElements[transform.childCount - 1].GetComponent<SnakeController>();

            Vector3 bodyClonePosition = snakeController.PreviousPosition;
            Quaternion bodyCloneRotation = _snakeElements[transform.childCount - 1].transform.localRotation;

            GameObject bodyClone = Instantiate(_bodyPrefab, bodyClonePosition, bodyCloneRotation);
        }
    }
}
