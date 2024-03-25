using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatSpriteChanger : Singleton<CatSpriteChanger>
{
    public Image[] catSprites;
    private void Start()
    {
        CatNormal();
    }
    public void CatNormal()
    {
        catSprites[0].gameObject.SetActive(true);
        catSprites[1].gameObject.SetActive(false);
        catSprites[2].gameObject.SetActive(false);
        catSprites[3].gameObject.SetActive(false);
    }
    public void CatEarlyOrLate()
    {
        catSprites[0].gameObject.SetActive(false);
        catSprites[1].gameObject.SetActive(false);
        catSprites[2].gameObject.SetActive(true);
        catSprites[3].gameObject.SetActive(false);
        StartCoroutine(RetrunToOriginal());
    }
    public void CatPerfect()
    {
        catSprites[0].gameObject.SetActive(false);
        catSprites[1].gameObject.SetActive(true);
        catSprites[2].gameObject.SetActive(false);
        catSprites[3].gameObject.SetActive(false);
        StartCoroutine(RetrunToOriginal());
    }
    public void CatTired()
    {
        catSprites[0].gameObject.SetActive(false);
        catSprites[1].gameObject.SetActive(false);
        catSprites[2].gameObject.SetActive(false);
        catSprites[3].gameObject.SetActive(true);
    }
    private IEnumerator RetrunToOriginal()
    {
        yield return new WaitForSeconds(0.5f);
        //GetComponent<SpriteRenderer>().color = Color.white;
        CatNormal();
    }


}
