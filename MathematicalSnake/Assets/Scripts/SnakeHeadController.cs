using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadController : SnakeController
{
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
        SnakeTurnRight();
        SnakeTurnLeft();
        base.Update();
    }

    private void SnakeTurnRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (SnakeDirection == SnakeDirections.SNAKE_FORWARD)
            {
                SnakeDirection = SnakeDirections.SNAKE_RIGHT;
                Quaternion snakeRotation = Quaternion.Euler(0.0f, RotationStep, 0.0f);
                transform.localRotation = snakeRotation;
            }
            else if (SnakeDirection == SnakeDirections.SNAKE_RIGHT)
            {
                SnakeDirection = SnakeDirections.SNAKE_BACK;
                float tempRotationStep = RotationStep * 2.0f;
                Quaternion snakeRotation = Quaternion.Euler(0.0f, tempRotationStep, 0.0f);
                transform.localRotation = snakeRotation;
            }
            else if (SnakeDirection == SnakeDirections.SNAKE_BACK)
            {
                SnakeDirection = SnakeDirections.SNAKE_LEFT;
                float tempRotationStep = RotationStep * 3.0f;
                Quaternion snakeRotation = Quaternion.Euler(0.0f, tempRotationStep, 0.0f);
                transform.localRotation = snakeRotation;
            }
            else if (SnakeDirection == SnakeDirections.SNAKE_LEFT)
            {
                SnakeDirection = SnakeDirections.SNAKE_FORWARD;
                float tempRotationStep = RotationStep * 0.0f;
                Quaternion snakeRotation = Quaternion.Euler(0.0f, tempRotationStep, 0.0f);
                transform.localRotation = snakeRotation;
            }
        }
    }

    private void SnakeTurnLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (SnakeDirection == SnakeDirections.SNAKE_FORWARD)
            {
                SnakeDirection = SnakeDirections.SNAKE_LEFT;
                Quaternion snakeRotation = Quaternion.Euler(0.0f, -RotationStep, 0.0f);
                transform.localRotation = snakeRotation;
            }
            else if (SnakeDirection == SnakeDirections.SNAKE_LEFT)
            {
                SnakeDirection = SnakeDirections.SNAKE_BACK;
                float tempRotationStep = RotationStep * 2.0f;
                Quaternion snakeRotation = Quaternion.Euler(0.0f, -tempRotationStep, 0.0f);
                transform.localRotation = snakeRotation;
            }
            else if (SnakeDirection == SnakeDirections.SNAKE_BACK)
            {
                SnakeDirection = SnakeDirections.SNAKE_RIGHT;
                float tempRotationStep = RotationStep * 3.0f;
                Quaternion snakeRotation = Quaternion.Euler(0.0f, -tempRotationStep, 0.0f);
                transform.localRotation = snakeRotation;
            }
            else if (SnakeDirection == SnakeDirections.SNAKE_RIGHT)
            {
                SnakeDirection = SnakeDirections.SNAKE_FORWARD;
                float tempRotationStep = RotationStep * 0.0f;
                Quaternion snakeRotation = Quaternion.Euler(0.0f, tempRotationStep, 0.0f);
                transform.localRotation = snakeRotation;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.gameObject.SetActive(false);
            SnakeManager.Instance.CreateSnakeBody();
            //MathematicalGenerator.Instance.GenerateMathematicalEquation();
        }

        if (other.gameObject.layer == 7)
        {
            Debug.Log("ZACZYNASZ OD POCZATKU");
        }
    }
}
