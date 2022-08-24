using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private Text _snakeLengthText;

    private void Start()
    {
        
    }


    private void Update()
    {
        
    }

    public void UpdateSnakeLengthText(int snakeLength)
    {
        _snakeLengthText.text = "Snake: " + snakeLength.ToString();
    }
}
