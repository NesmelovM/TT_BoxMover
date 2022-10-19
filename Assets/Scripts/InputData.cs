using System.Globalization;
using TMPro;
using UnityEngine;

public class InputData : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputSpeed;
    [SerializeField] private TMP_InputField _inputDistance;
    [SerializeField] private TMP_InputField _inputTime;

    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _currentDistance;
    [SerializeField] private float _currentTime;

    public float CurrentSpeed { get => _currentSpeed; }
    public float CurrentDistance { get => _currentDistance; }
    public float CurrentTime { get => _currentTime; }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void SaveDistance()
    {
        _currentDistance = String2Float(_inputDistance.text); 
    }

    public void SaveSpeed()
    {
        _currentSpeed = String2Float(_inputSpeed.text);
    }

    public void SaveTime()
    {
        _currentTime = String2Float(_inputTime.text);
    }

    private float String2Float(string line)
    {
        float res;
        try
        {
            string sp = NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;
            line = line.Replace(".", sp);
            line = line.Replace(",", sp);
            res = float.Parse(line);
        }
        catch
        {
            res = 0f;
        }

        return res;
    }
}
