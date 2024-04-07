using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeOpacity : MonoBehaviour
{
    //public Image target;
    private float _elapsedTime;
    public float _duration;
    private Color visible, invisible;
    //private float alpha168 = ((168 / 255) * 100);
    public float desiredOpacity = 168f;

    private void OnEnable()
    {
        //target.gameObject.SetActive(true);
        StartCoroutine(CoroutineOpacity());
    }

    private IEnumerator CoroutineOpacity()
    {
        Image target = this.GetComponent<Image>();
        visible = new Color(target.color.r, target.color.g, target.color.b, (desiredOpacity / 255f) ); 
        invisible = new Color(target.color.r, target.color.g, target.color.b, 0f);
        target.color = invisible; //start as invisible
        _elapsedTime = 0;
        while (_elapsedTime < _duration)
        {
            _elapsedTime += Time.deltaTime;
            float percentageCompleted = _elapsedTime / _duration;
            target.color = Color.Lerp(invisible, visible, percentageCompleted); //Lerp from invisible to visible
            yield return null;
        }
    }
}
