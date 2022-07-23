using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyController : SnakeController
{
    private bool bodyCanTurnRight = false;
    private bool bodyCanTurnLeft = false;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.D))
        {
            bodyCanTurnRight = true;
        }

        if (bodyCanTurnRight)
        {
            BodyTurnRight();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            bodyCanTurnLeft = true;
        }

        if (bodyCanTurnLeft)
        {
            BodyTurnLeft();
        }
    }

    private void BodyTurnRight()
    {
        float previousBodyPositionX = SnakeManager.Instance.SnakeElements[transform.GetSiblingIndex() - 1].transform.localPosition.x;
        float previousBodyPositionZ = SnakeManager.Instance.SnakeElements[transform.GetSiblingIndex() - 1].transform.localPosition.z;

        if (SnakeDirection == SnakeDirections.SNAKE_FORWARD && transform.localPosition.z == previousBodyPositionZ)
        {
            SnakeDirection = SnakeDirections.SNAKE_RIGHT;
            Quaternion snakeRotation = Quaternion.Euler(0.0f, RotationStep, 0.0f);
            transform.localRotation = snakeRotation;
            bodyCanTurnRight = false;
        }
        else if (SnakeDirection == SnakeDirections.SNAKE_RIGHT && transform.localPosition.x == previousBodyPositionX)
        {
            SnakeDirection = SnakeDirections.SNAKE_BACK;
            float tempRotationStep = RotationStep * 2.0f;
            Quaternion snakeRotation = Quaternion.Euler(0.0f, tempRotationStep, 0.0f);
            transform.localRotation = snakeRotation;
            bodyCanTurnRight = false;
        }
        else if (SnakeDirection == SnakeDirections.SNAKE_BACK && transform.localPosition.z == previousBodyPositionZ)
        {
            SnakeDirection = SnakeDirections.SNAKE_LEFT;
            float tempRotationStep = RotationStep * 3.0f;
            Quaternion snakeRotation = Quaternion.Euler(0.0f, tempRotationStep, 0.0f);
            transform.localRotation = snakeRotation;
            bodyCanTurnRight = false;
        }
        else if (SnakeDirection == SnakeDirections.SNAKE_LEFT && transform.localPosition.x == previousBodyPositionX)
        {
            SnakeDirection = SnakeDirections.SNAKE_FORWARD;
            float tempRotationStep = RotationStep * 0.0f;
            Quaternion snakeRotation = Quaternion.Euler(0.0f, tempRotationStep, 0.0f);
            transform.localRotation = snakeRotation;
            bodyCanTurnRight = false;
        }
    }

    private void BodyTurnLeft()
    {
        float previousBodyPositionX = SnakeManager.Instance.SnakeElements[transform.GetSiblingIndex() - 1].transform.localPosition.x;
        float previousBodyPositionZ = SnakeManager.Instance.SnakeElements[transform.GetSiblingIndex() - 1].transform.localPosition.z;

        if (SnakeDirection == SnakeDirections.SNAKE_FORWARD && transform.localPosition.z == previousBodyPositionZ)
        {
            SnakeDirection = SnakeDirections.SNAKE_LEFT;
            Quaternion snakeRotation = Quaternion.Euler(0.0f, -RotationStep, 0.0f);
            transform.localRotation = snakeRotation;
            bodyCanTurnLeft = false;
        }
        else if (SnakeDirection == SnakeDirections.SNAKE_LEFT && transform.localPosition.x == previousBodyPositionX)
        {
            SnakeDirection = SnakeDirections.SNAKE_BACK;
            float tempRotationStep = RotationStep * 2.0f;
            Quaternion snakeRotation = Quaternion.Euler(0.0f, -tempRotationStep, 0.0f);
            transform.localRotation = snakeRotation;
            bodyCanTurnLeft = false;
        }
        else if (SnakeDirection == SnakeDirections.SNAKE_BACK && transform.localPosition.z == previousBodyPositionZ)
        {
            SnakeDirection = SnakeDirections.SNAKE_RIGHT;
            float tempRotationStep = RotationStep * 3.0f;
            Quaternion snakeRotation = Quaternion.Euler(0.0f, -tempRotationStep, 0.0f);
            transform.localRotation = snakeRotation;
            bodyCanTurnLeft = false;
        }
        else if (SnakeDirection == SnakeDirections.SNAKE_RIGHT && transform.localPosition.x == previousBodyPositionX)
        {
            SnakeDirection = SnakeDirections.SNAKE_FORWARD;
            float tempRotationStep = RotationStep * 0.0f;
            Quaternion snakeRotation = Quaternion.Euler(0.0f, tempRotationStep, 0.0f);
            transform.localRotation = snakeRotation;
            bodyCanTurnLeft = false;
        }
    }
}
