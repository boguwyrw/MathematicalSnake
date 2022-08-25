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

    [SerializeField] private Camera _camera;

    private MathematicalStages mathematicalStage;

    private int _positionX = 0;
    private int _positionZ = 0;
    private int _randomFirstNumber = 0;
    private int _randomSecondNumber = 0;
    private int _result = 0;
    private int _operationIndex = 0;
    private int _minOperationsLength = 0;
    private string[] _mathematicalOperations = new string[5];
    private GameObject _numberCanvasClone;

    private void Start()
    {
        mathematicalStage = MathematicalStages.CHOOSE_FIRST_NO;

        _mathematicalOperations[0] = "+";
        _mathematicalOperations[1] = "-";
        _mathematicalOperations[2] = "x";
        _mathematicalOperations[3] = "/";
        _mathematicalOperations[4] = "=";

        _minOperationsLength = _mathematicalOperations.Length;

        GenerateMathematicalEquation();
    }

    private void CleanMathematicalEquations()
    {
        int mathematicalEquationsLength = transform.childCount;
        if (mathematicalEquationsLength > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void GenerateMathematicalEquation()
    {
        switch(mathematicalStage)
        {
            case MathematicalStages.CHOOSE_FIRST_NO:
                CleanMathematicalEquations();
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
                GenerateFakeResult();
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
        randPos.SetParent(transform);
        randPos.localPosition = new Vector3(_positionX, randPos.localPosition.y, _positionZ);
    }

    private void GenerateCanvasClone()
    {
        _numberCanvasClone = Instantiate(_numberCanvasPrefab);
    }

    private void SetCanvasCamera()
    {
        Canvas cloneCanvas = _numberCanvasClone.GetComponent<Canvas>();
        cloneCanvas.worldCamera = _camera;
    }

    private void GenerateFirstRandomNumber()
    {
        GenerateRandomPosition();

        Text numberText;
        if (transform.childCount > _minOperationsLength)
        {
            _numberCanvasClone = transform.GetChild(0).gameObject;
            numberText = _numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
            _numberCanvasClone.SetActive(true);
        }
        else
        {
            GenerateCanvasClone();
            numberText = _numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
            SetCanvasCamera();
        }
        _randomFirstNumber = Random.Range(0, 100) + 1;
        numberText.text = _randomFirstNumber.ToString();

        SetRandomPosition(_numberCanvasClone.transform);

        mathematicalStage = MathematicalStages.CHOOSE_OPERATION;
    }

    private void GenerateOperation()
    {
        GenerateRandomPosition();

        Text numberText;
        if (transform.childCount > _minOperationsLength)
        {
            _numberCanvasClone = transform.GetChild(1).gameObject;
            numberText = _numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
            _numberCanvasClone.SetActive(true);
        }
        else
        {
            GenerateCanvasClone();
            numberText = _numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
            numberText.fontSize = 23;
            SetCanvasCamera();
        }
        _operationIndex = Random.Range(0, _minOperationsLength - 1);
        numberText.text = _mathematicalOperations[_operationIndex];

        SetRandomPosition(_numberCanvasClone.transform);

        mathematicalStage = MathematicalStages.CHOOSE_SECOND_NO;
    }

    private void GenerateSecondRandomNumber()
    {
        GenerateRandomPosition();

        Text numberText;
        if (transform.childCount > _minOperationsLength)
        {
            _numberCanvasClone = transform.GetChild(2).gameObject;
            numberText = _numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
            _numberCanvasClone.SetActive(true);
        }
        else
        {
            GenerateCanvasClone();
            numberText = _numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
            SetCanvasCamera();
        }

        switch (_operationIndex)
        {
            case 0:
                _randomSecondNumber = Random.Range(0, 100) + 1;
                break;
            case 1:
                _randomSecondNumber = Random.Range(1, _randomFirstNumber);
                break;
            case 2:
                if (_randomFirstNumber > 10)
                {
                    _randomSecondNumber = Random.Range(0, 10) + 1;
                }
                else
                {
                    _randomSecondNumber = Random.Range(0, 100) + 1;
                }
                break;
            case 3:
                do
                {
                    _randomSecondNumber = Random.Range(0, _randomFirstNumber) + 1;
                }
                while ((_randomFirstNumber % _randomSecondNumber) != 0);
                break;
        }
        
        numberText.text = _randomSecondNumber.ToString();

        SetRandomPosition(_numberCanvasClone.transform);

        mathematicalStage = MathematicalStages.CHOOSE_EQUAL_SIGN;
    }

    private void GenerateEqualSign()
    {
        GenerateRandomPosition();

        Text numberText;
        if (transform.childCount > _minOperationsLength)
        {
            _numberCanvasClone = transform.GetChild(3).gameObject;
            numberText = _numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
            _numberCanvasClone.SetActive(true);
        }
        else
        {
            GenerateCanvasClone();
            numberText = _numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
            numberText.fontSize = 23;
            SetCanvasCamera();
        }
        numberText.text = _mathematicalOperations[4];

        SetRandomPosition(_numberCanvasClone.transform);

        mathematicalStage = MathematicalStages.CHOOSE_RESULT;
    }

    private void GenerateResult()
    {
        GenerateRandomPosition();

        Text numberText;
        _numberCanvasClone = null;

        if (transform.childCount > _minOperationsLength)
        {
            _numberCanvasClone = transform.GetChild(4).gameObject;
            numberText = _numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
            _numberCanvasClone.SetActive(true);
        }
        else
        {
            GenerateCanvasClone();
            _numberCanvasClone.layer = 9;
            numberText = _numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
            SetCanvasCamera();
        }

        switch (_operationIndex)
        {
            case 0:
                _result = _randomFirstNumber + _randomSecondNumber;
                break;
            case 1:
                _result = _randomFirstNumber - _randomSecondNumber;
                break;
            case 2:
                _result = _randomFirstNumber * _randomSecondNumber;
                break;
            case 3:
                _result = _randomFirstNumber / _randomSecondNumber;
                break;
        }
        
        numberText.text = _result.ToString();

        SetRandomPosition(_numberCanvasClone.transform);
    }

    private void GenerateFakeResult()
    {
        int snakeLength = SnakeManager.Instance.transform.childCount;
        int maxOperationsLength = transform.childCount;
        _numberCanvasClone = null;

        for (int i = 0; i < snakeLength; i++)
        {
            GenerateRandomPosition();

            Text numberText;
            int operationsLengthIndex = _minOperationsLength + i;
            
            if (operationsLengthIndex < maxOperationsLength)
            {
                _numberCanvasClone = transform.GetChild(operationsLengthIndex).gameObject;
                numberText = _numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
                _numberCanvasClone.SetActive(true);    
            }
            else
            {
                GenerateCanvasClone();
                numberText = _numberCanvasClone.transform.GetChild(0).GetComponent<Text>();
                SetCanvasCamera();
            }

            int fakeResult = (Random.Range(0, _result) + 1) + (Random.Range(1, _result + 1) + 1);
            int tempFakeResult = fakeResult;

            while (fakeResult == tempFakeResult)
            {
                int temprandomRange = Random.Range(1, 100) + 1;
                fakeResult = (Random.Range(0, _result) + 1) + (Random.Range(1, temprandomRange) + 1);
            }

            numberText.text = fakeResult.ToString();

            SetRandomPosition(_numberCanvasClone.transform);
        }

        mathematicalStage = MathematicalStages.CHOOSE_FIRST_NO;
    }
}
