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

    private void SnakeMovementSystem()
    {
        Vector3 tempActualPosition;
        Quaternion tempActualRotation;

        switch (SnakeDirection)
        {
            case SnakeDirections.SNAKE_FORWARD:
                tempActualPosition = ActualPosition;
                tempActualRotation = ActualRotation;
                ActualPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + MovementStep);
                ActualRotation = transform.localRotation;
                transform.localPosition = ActualPosition;
                PreviousPosition = tempActualPosition;
                PreviousRotation = tempActualRotation;
                break;
            case SnakeDirections.SNAKE_RIGHT:
                tempActualPosition = ActualPosition;
                tempActualRotation = ActualRotation;
                ActualPosition = new Vector3(transform.localPosition.x + MovementStep, transform.localPosition.y, transform.localPosition.z);
                ActualRotation = transform.localRotation;
                transform.localPosition = ActualPosition;
                PreviousPosition = tempActualPosition;
                PreviousRotation = tempActualRotation;
                break;
            case SnakeDirections.SNAKE_LEFT:
                tempActualPosition = ActualPosition;
                tempActualRotation = ActualRotation;
                ActualPosition = new Vector3(transform.localPosition.x - MovementStep, transform.localPosition.y, transform.localPosition.z);
                ActualRotation = transform.localRotation;
                transform.localPosition = ActualPosition;
                PreviousPosition = tempActualPosition;
                PreviousRotation = tempActualRotation;
                break;
            case SnakeDirections.SNAKE_BACK:
                tempActualPosition = ActualPosition;
                tempActualRotation = ActualRotation;
                ActualPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - MovementStep);
                ActualRotation = transform.localRotation;
                transform.localPosition = ActualPosition;
                PreviousPosition = tempActualPosition;
                PreviousRotation = tempActualRotation;
                break;
        }
    }
}
