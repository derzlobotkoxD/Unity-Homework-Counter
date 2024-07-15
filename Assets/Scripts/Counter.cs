using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    private int _currentNumber = 0;
    private float _delay = 0.5f;

    private Coroutine _coroutine;

    public event UnityAction<int> Changed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Switch();
    }

    private void Switch()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        else
        {
            _coroutine = StartCoroutine(IncreaseNumber(_delay));
        }
    }

    private IEnumerator IncreaseNumber(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            _currentNumber++;
            Changed?.Invoke(_currentNumber);

            yield return wait;
        }
    }
}
