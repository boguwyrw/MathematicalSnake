using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathematicalGenerator : MonoBehaviour
{
    #region MathematicalGenerator_Singleton
    private static MathematicalGenerator _instance;

    public static MathematicalGenerator Instance
    {
        get
        {
            if (_instance == null) _instance = new MathematicalGenerator();
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    [SerializeField] private GameObject _numberCanvasPrefab;

    private MathematicalStages mathematicalStage;

    private int _positionX = 0;
    private int _positionZ = 0;
    private int randomFirstNumber = 0;
    private int randomSecondNumber = 0;
    private int _result = 0;
    private string[] _mathematicalOperations = new string[5];

    private void Start()
    {
        mathematicalStage = MathematicalStages.CHOOSE_FIRST_NO;

        _mathematicalOperations[0] = "+";
        _mathematicalOperations[1] = "-";
        _mathematicalOperations[2] = "x";
        _mathematicalOperations[3] = "/";
        _mathematicalOperations[4] = "=";

        GenerateMathematicalEquation();
    }

    public void GenerateMathematicalEquation()
    {
        switch(mathematicalStage)
        {
            case MathematicalStages.CHOOSE_FIRST_NO:
                GenerateFirstRandomNumber();
                break;
            case MathematicalStages.CHOOSE_OPERATION:
                GenerateOperation();
                break;
            case MathematicalStages.CHOOSE_SECOND_NO:
                GenerateSecondRandomNumber();
                break;
            case MathematicalStages.CHOOSE_EQUAL_SIGN:
                GenerateEqualSign();
                break;
            case MathematicalStages.CHOOSE_RESULT:
                GenerateResult();
                break;
        }
    }

    private void GenerateRandomPosition()
    {
        _positionX = Random.Range(0, 21) + 1;
        _positionZ = Random.Range(0, 21) + 1;
    }

    private void SetRandomPosition(Transform randPos)
    {
        randPos.parent = transform;
        randPos.localPosition = new Vector3(_positionX, randPos.localPosition.y, _positionZ);
    }

    private void GenerateFirstRandomNumber()
    {
        GenerateRandomPosition();

        GameObject numberCanvasClone = Instantiate(_numberCanvasPrefab);

        Text numberText = numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
        randomFirstNumber = Random.Range(0, 100) + 1;
        numberText.text = randomFirstNumber.ToString();

        SetRandomPosition(numberCanvasClone.transform);

        mathematicalStage = MathematicalStages.CHOOSE_OPERATION;
    }

    private void GenerateOperation()
    {
        GenerateRandomPosition();

        GameObject numberCanvasClone = Instantiate(_numberCanvasPrefab);

        Text numberText = numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
        numberText.text = _mathematicalOperations[0];

        SetRandomPosition(numberCanvasClone.transform);

        mathematicalStage = MathematicalStages.CHOOSE_SECOND_NO;
    }

    private void GenerateSecondRandomNumber()
    {
        GenerateRandomPosition();

        GameObject numberCanvasClone = Instantiate(_numberCanvasPrefab);

        Text numberText = numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
        randomSecondNumber = Random.Range(0, 100) + 1;
        numberText.text = randomSecondNumber.ToString();

        SetRandomPosition(numberCanvasClone.transform);

        mathematicalStage = MathematicalStages.CHOOSE_EQUAL_SIGN;
    }

    private void GenerateEqualSign()
    {
        GenerateRandomPosition();

        GameObject numberCanvasClone = Instantiate(_numberCanvasPrefab);

        Text numberText = numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
        numberText.text = _mathematicalOperations[4];

        SetRandomPosition(numberCanvasClone.transform);

        mathematicalStage = MathematicalStages.CHOOSE_RESULT;
    }

    private void GenerateResult()
    {
        GenerateRandomPosition();

        GameObject numberCanvasClone = Instantiate(_numberCanvasPrefab);

        Text numberText = numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
        _result = randomFirstNumber + randomSecondNumber; // trzeba zmienic aby odpowiadalo pozniejszemu losowaniu dzialania matematycznego
        numberText.text = _result.ToString();

        SetRandomPosition(numberCanvasClone.transform);

        mathematicalStage = MathematicalStages.CHOOSE_FIRST_NO;
    }
}
