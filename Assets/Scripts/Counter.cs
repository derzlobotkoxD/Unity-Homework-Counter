using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    private float _delay = 0.5f;
    private bool _isWork = false;
    private IEnumerator _coroutine;

    public event UnityAction<int> Changed;

    private void Start()
    {
        _coroutine = IncreaseNumber(_delay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Switch();
    }

    private IEnumerator IncreaseNumber(float delay)
    {
        var wait = new WaitForSeconds(delay);
        int currentNumber = 0;

        while (true)
        {
            currentNumber++;
            Changed?.Invoke(currentNumber);

            yield return wait;
        }
    }

    private void Switch()
    {
        if (_isWork && _coroutine != null)
        {
            StopCoroutine(_coroutine);

            _isWork = false;
        }
        else
        {
            StartCoroutine(_coroutine);
            _isWork = true;
        }
    }
}
