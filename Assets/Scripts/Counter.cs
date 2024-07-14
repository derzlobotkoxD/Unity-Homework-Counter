using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private float _delay = 0.5f;
    private bool _isWork = false;
    private IEnumerator coroutine;

    private void Start()
    {
        _text.text = "0";
        coroutine = IncreaseNumber(_delay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Switch();
    }

    private IEnumerator IncreaseNumber(float delay)
    {
        var Wait = new WaitForSeconds(delay);
        int currentNumber = 0;

        while (true)
        {
            currentNumber++;
            DisplayNumber(currentNumber);

            yield return Wait;
        }
    }

    private void Switch()
    {
        if (_isWork)
        {
            StopCoroutine(coroutine);
            _isWork = false;
        }
        else
        {
            StartCoroutine(coroutine);
            _isWork = true;
        }
    }

    private void DisplayNumber(int number) =>
        _text.text = number.ToString();
}
