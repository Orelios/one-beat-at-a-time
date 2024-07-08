using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneChangeDay : MonoBehaviour
{
    public GameObject dayIndicator;
    [SerializeField] private int previousDay, currentDay;
    [SerializeField] private float _moveDuration = 1f, _waitDuration = 1f;
    [SerializeField] private List<Vector3> dayIndicatorPositions = new List<Vector3>() { new Vector3(-450, -100, 0), new Vector3(-300, -100, 0), new Vector3(-150, -100, 0), new Vector3(0, -100, 0), new Vector3(150, -100, 0), new Vector3(300, -100, 0), new Vector3(450, -100, 0) };
    private float _moveElapsedTime, _waitElapsedTime;
    private Coroutine changeDayCo, waitAfterAnimateCo;

    void Start()
    {
        if (currentDay == 1)
        {
            if (PlayerData.Instance.day1Loaded == 0) // day1 not yet loaded
            {
                AnimateChangeDay(previousDay, currentDay);
                PlayerData.Instance.day1Loaded = 1;
                PlayerData.Instance.AddProductivity(6);
                PlayerData.Instance.Save();
            }
            else //day1 already loaded, for example going into a rhythm scene and returning
            {
                this.gameObject.SetActive(false); // no custscene
            }
        }
        else if (currentDay == 3)
        {
            if (PlayerData.Instance.day3Loaded == 0)
            {
                AnimateChangeDay(previousDay, currentDay);
                PlayerData.Instance.day3Loaded = 1;
                PlayerData.Instance.AddProductivity(6);
                PlayerData.Instance.Save();
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
        else if (currentDay == 5)
        {
            if (PlayerData.Instance.day5Loaded == 0)
            {
                AnimateChangeDay(previousDay, currentDay);
                PlayerData.Instance.day5Loaded = 1;
                PlayerData.Instance.AddProductivity(6);
                PlayerData.Instance.Save();
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            AnimateChangeDay(previousDay, currentDay);
        }
    }


    void Update()
    {
        
    }

    public IEnumerator MoveDayIndicator(int x, int y)
    {
        _moveElapsedTime = 0f;
        while (_moveElapsedTime < _moveDuration)
        {
            _moveElapsedTime += Time.deltaTime;
            float percentageCompleted = _moveElapsedTime / _moveDuration;
            dayIndicator.transform.localPosition = Vector3.Lerp(dayIndicatorPositions[x], dayIndicatorPositions[y], percentageCompleted);
            yield return null;
        }
        waitAfterAnimateCo = StartCoroutine(WaitAfterAnimateChangeDay());
    }

    public void AnimateChangeDay(int x, int y)
    {
        if (x != y) //previous day != current day
        {
            changeDayCo = StartCoroutine(MoveDayIndicator(x, y));
        }
        else
        {
            //no animation of change day, just make sure dayIndicator is at current day position then wait
            dayIndicator.transform.localPosition = dayIndicatorPositions[currentDay];
            waitAfterAnimateCo = StartCoroutine(WaitAfterAnimateChangeDay());
        }
        
    }

    public IEnumerator WaitAfterAnimateChangeDay()
    {
        _waitElapsedTime = 0f;
        while (_waitElapsedTime < _waitDuration)
        {
            _waitElapsedTime += Time.deltaTime;
            yield return null;
        }
        this.gameObject.SetActive(false);
    }
}
