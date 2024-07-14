using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    public event UnityAction<int> Changed;

    private float _delay = 0.5f;
    private bool _isWork = false;
    private IEnumerator coroutine;

    private void Start()
    {
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
            Changed?.Invoke(currentNumber);

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
}
