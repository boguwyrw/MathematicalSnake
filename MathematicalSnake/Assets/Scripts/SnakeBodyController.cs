using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyController : SnakeController
{
    private SnakeController snakeController;

    protected override void Start()
    {
        snakeController = transform.parent.GetChild(transform.parent.childCount - 2).GetComponent<SnakeController>();
        SetNewPositions();
    }

    protected override void Update()
    {
        if (SnakeManager.Instance.SnakeCanMove)
        {
            Vector3 tempActualPosition = ActualPosition;
            Quaternion tempActualRotation = ActualRotation;
            SetNewPositions();
            PreviousPosition = tempActualPosition;
            PreviousRotation = tempActualRotation;
        }
    }

    private void SetNewPositions()
    {
        ActualPosition = snakeController.PreviousPosition;
        transform.localPosition = ActualPosition;
        ActualRotation = snakeController.PreviousRotation;
        transform.localRotation = ActualRotation;
    }
}
