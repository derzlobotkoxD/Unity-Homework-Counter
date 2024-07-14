using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _counter.Changed += DisplayNumber; 
    }

    private void OnDisable()
    {
        _counter.Changed -= DisplayNumber;
    }

    private void DisplayNumber(int number) =>
        _text.text = number.ToString();
}