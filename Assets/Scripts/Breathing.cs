using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Breathing : MonoBehaviour
{
    private float BeatManagerStep = 0.5f;
    public float breathCount = 4;
    [SerializeField]
    private float _breathDuration;
    [SerializeField]
    private bool _inhaling, _exhaling, _holding;
    [SerializeField]
    private Vector2 _startScale = new Vector2(1, 1), _endScale = new Vector2(5, 5);
    private float percentageCompleted, stopwatch = 0f;
    private Coroutine exhaleCo, inhaleCo;
    void Start()
    {
        _breathDuration = (60f / (BeatManager.Instance.GetBPM() * BeatManagerStep)) * breathCount;
        //inhaleCo = Inhale();
        //exhaleCo = Exhale();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CheckInhale();
        }
        
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            StopInhale();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CheckExhale();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            StopExhale();
        }
    }

    private void StopInhale()
    {
        StopCoroutine(inhaleCo);
        _inhaling = false;
        //transform.localScale = _startScale;
    }

    private void StopExhale()
    {
        StopCoroutine(exhaleCo);
        _exhaling = false;
        //transform.localScale = _startScale;
    }

    private void CheckInhale()
    {
        if (!_inhaling)
        {
            _inhaling = true;
            inhaleCo = StartCoroutine(Inhale());
        }
    }

    private void CheckExhale()
    {
        if (!_exhaling)
        {
            _exhaling = true;
            exhaleCo = StartCoroutine(Exhale());
        }
    }

    private IEnumerator Inhale()
    {
        stopwatch = 0;
        while (stopwatch < _breathDuration)
        {
            stopwatch += Time.deltaTime;
            percentageCompleted = stopwatch / _breathDuration;
            transform.localScale = Vector3.Lerp(_startScale, _endScale, percentageCompleted);
            yield return null;
        }
    }

    private IEnumerator Exhale()
    {
        stopwatch = 0;
        while (stopwatch < _breathDuration)
        {
            stopwatch += Time.deltaTime;
            percentageCompleted = stopwatch / _breathDuration;
            transform.localScale = Vector3.Lerp(_endScale, _startScale, percentageCompleted);
            yield return null;
        }
    }
}
