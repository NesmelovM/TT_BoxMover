using Scritps;
using System.Collections;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private InputData _inputData;
    private BoxFactory _boxFactory;


    private Vector3 _direction;
    private bool _canMove;

    private float _startTime;
    private float _journeyLength;
    private Vector3 _endMarker;
    private Vector3 _startMarker;

    private void Start()
    {
        _inputData = gameObject.GetComponent<InputData>();
        _boxFactory = FindObjectOfType<BoxFactory>();

        _canMove = false;
        _direction = ChoiseDirection();
        _startMarker = new Vector3(4.5f, 0, -4.5f);

        StartCoroutine(BoxLoop());
    }
    private void Update()
    {
        if (_canMove)
        {
            if (_boxFactory._box.transform.position != _endMarker)
            {
                float distCovered = (Time.time - _startTime) * _inputData.CurrentSpeed;
                float fracJourney = distCovered / _journeyLength;
                _boxFactory._box.transform.position = Vector3.Lerp(_startMarker, _endMarker, fracJourney);
            }
            else
            {
                _canMove = false;
                _boxFactory._poolOfBoxies.Release(_boxFactory._box);
            }
        }
        else
        {
            _canMove = false;
        }
    }

    IEnumerator BoxLoop()
    {
        while (true)
        {
            if (_canMove == false)
            {
                yield return new WaitForSeconds(_inputData.CurrentTime);

                _boxFactory._box = _boxFactory._poolOfBoxies.Get();
                Debug.Log("Создан кубик");

                _boxFactory._box.transform.position = _startMarker;

                _direction = ChoiseDirection();
                _endMarker = _startMarker + _direction * _inputData.CurrentDistance;
                _startTime = Time.time;

                _journeyLength = Vector3.Distance(_startMarker, _endMarker);
                _canMove = true;
            }
            else
            {
                yield return new WaitForSeconds(_inputData.CurrentTime);
            }

        }
    }
    private Vector3 ChoiseDirection()
    {
        var random = Random.Range(1, 2);
        switch (random)
        {
            case 1: return Vector3.left;
            case 2: return Vector3.forward;
            default: return Vector3.left;
        }

    }

}
