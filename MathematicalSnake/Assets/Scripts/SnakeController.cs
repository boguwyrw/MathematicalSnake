using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    protected Vector3 ActualPosition;
    protected Quaternion ActualRotation;

    [HideInInspector] public SnakeDirections SnakeDirection;
    [HideInInspector] public Vector3 PreviousPosition;
    [HideInInspector] public Quaternion PreviousRotation;

    protected const float MovementStep = 1.0f;
    protected const float RotationStep = 90.0f;

    protected const int FutureValue = 0;
    protected const int PresentValue = 1;
    protected const int PastValue = 2;

    protected virtual void Awake()
    {
        SnakeDirection = SnakeDirections.SNAKE_FORWARD;
    }

    protected virtual void Start()
    {
        ActualPosition = transform.localPosition;
        ActualRotation = transform.localRotation;
    }

    protected virtual void Update()
    {
        if (SnakeManager.Instance.SnakeCanMove)
        {
            SnakeMovementSystem();
        }
    }

    protected virtual void LateUpdate()
    {
        if (SnakeManager.Instance.SnakeCanMove)
        {
            SnakeManager.Instance.SnakeCanMove = false;
        }
    }

    private void MoveSnake(Vector3 position)
    {
        Vector3 tempActualPosition = ActualPosition;
        Quaternion tempActualRotation = ActualRotation;
        
        ActualPosition = position;
        ActualRotation = transform.localRotation;
        transform.localPosition = ActualPosition;
        PreviousPosition = tempActualPosition;
        PreviousRotation = tempActualRotation;
    }

    private void SnakeMovementSystem()
    {
        switch (SnakeDirection)
        {
            case SnakeDirections.SNAKE_FORWARD:
                MoveSnake(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + MovementStep));
                break;
            case SnakeDirections.SNAKE_RIGHT:
                MoveSnake(new Vector3(transform.localPosition.x + MovementStep, transform.localPosition.y, transform.localPosition.z));
                break;
            case SnakeDirections.SNAKE_LEFT:
                MoveSnake(new Vector3(transform.localPosition.x - MovementStep, transform.localPosition.y, transform.localPosition.z));
                break;
            case SnakeDirections.SNAKE_BACK:
                MoveSnake(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - MovementStep));
                break;
        }
    }
}
