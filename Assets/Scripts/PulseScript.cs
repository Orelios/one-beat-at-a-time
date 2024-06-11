using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseScript : MonoBehaviour
{
    private Vector3 _startScale, _endScale;
    [SerializeField] private float _pulseDuration = 0.5f;
    [SerializeField] private float _pulseSizeMultiplier = 1.15f;
    private float _pulseElapsedTime;

    private void Start()
    {
        _endScale = transform.localScale;
        _startScale = transform.localScale * _pulseSizeMultiplier;
    }

    public IEnumerator PulseCoroutine()
    {
        _pulseElapsedTime = 0;
        while (_pulseElapsedTime < _pulseDuration)
        {
            _pulseElapsedTime += Time.deltaTime;
            float percentageCompleted = _pulseElapsedTime / _pulseDuration;
            transform.localScale = Vector3.Lerp(_startScale, _endScale, percentageCompleted);
            yield return null;
        }
    }

    public void Pulse()
    {
        StartCoroutine(PulseCoroutine());
    }
}
