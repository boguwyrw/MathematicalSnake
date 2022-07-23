using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    protected SnakeDirections SnakeDirection;
    protected Vector3 ActualPosition;

    [HideInInspector] public Vector3 PreviousPosition;

    protected const float MovementStep = 1.0f;
    protected const float RotationStep = 90.0f;

    protected virtual void Awake()
    {
        SnakeDirection = SnakeDirections.SNAKE_FORWARD;
    }

    protected virtual void Start()
    {
        ActualPosition = transform.localPosition;
    }

    protected virtual void Update()
    {
        if (SnakeManager.Instance.SnakeCanMove)
        {
            SnakeMovementSystem();
        }
    }

    private void LateUpdate()
    {
        if (SnakeManager.Instance.SnakeCanMove)
        {
            SnakeManager.Instance.SnakeCanMove = false;
        }
    }

    private void SnakeMovementSystem()
    {
        switch(SnakeDirection)
        {
            case SnakeDirections.SNAKE_FORWARD:
                PreviousPosition = ActualPosition;
                ActualPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + MovementStep);
                transform.localPosition = ActualPosition;
                break;
            case SnakeDirections.SNAKE_RIGHT:
                PreviousPosition = ActualPosition;
                ActualPosition = new Vector3(transform.localPosition.x + MovementStep, transform.localPosition.y, transform.localPosition.z);
                transform.localPosition = ActualPosition;
                break;
            case SnakeDirections.SNAKE_LEFT:
                PreviousPosition = ActualPosition;
                ActualPosition = new Vector3(transform.localPosition.x - MovementStep, transform.localPosition.y, transform.localPosition.z);
                transform.localPosition = ActualPosition;
                break;
            case SnakeDirections.SNAKE_BACK:
                PreviousPosition = ActualPosition;
                ActualPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - MovementStep);
                transform.localPosition = ActualPosition;
                break;
        }
    }
}
