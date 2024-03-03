using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorImage : Singleton<IndicatorImage>
{
    public float returnDelay;
    public Sprite[] images;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeIndicatorImage(Arrows arrow)
    {
        switch (arrow)
        {
            case Arrows.None:
                GetComponent<SpriteRenderer>().sprite = images[0];
                break;
            case Arrows.Up:
                GetComponent<SpriteRenderer>().sprite = images[1];
                break;
            case Arrows.Down:
                GetComponent<SpriteRenderer>().sprite = images[2];
                break;
            case Arrows.Left:
                GetComponent<SpriteRenderer>().sprite = images[3];
                break;
            case Arrows.Right:
                GetComponent<SpriteRenderer>().sprite = images[4];
                break;
        }
        StartCoroutine(RetrunToOriginal());
    }

    private IEnumerator RetrunToOriginal()
    {
        yield return new WaitForSeconds(returnDelay);
        GetComponent<SpriteRenderer>().sprite = images[0];
    }
}
