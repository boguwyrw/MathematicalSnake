using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyController : SnakeController
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        ActualPosition = transform.localPosition;
        base.Start();
    }

    protected override void Update()
    {
        
    }
}
