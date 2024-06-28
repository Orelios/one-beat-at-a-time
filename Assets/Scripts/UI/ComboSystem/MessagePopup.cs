using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePopup : MonoBehaviour
{
    public GameObject[] convos; 
    void Start()
    {
        convos[0].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        convos[0].gameObject.transform.GetChild(1).gameObject.SetActive(false);
        convos[0].gameObject.transform.GetChild(2).gameObject.SetActive(false);

        convos[1].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        convos[1].gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
    public void ComboHit()
    {
        StartCoroutine(HitCombo());
    }

    public void MissCombo()
    {
        StartCoroutine(ComboMiss());
    }

    IEnumerator HitCombo()
    {
        for(int x =0; x < 3; x++)
        {
            convos[0].gameObject.transform.GetChild(x).gameObject.SetActive(true);
            yield return new WaitForSeconds(1.5f);
        }

        yield return new WaitForSeconds(4);

        for (int x = 0; x < 3; x++)
        {
            convos[0].gameObject.transform.GetChild(x).gameObject.SetActive(false);
        }
    }

    IEnumerator ComboMiss()
    {
        for (int x = 0; x < 2; x++)
        {
            convos[1].gameObject.transform.GetChild(x).gameObject.SetActive(true);
            yield return new WaitForSeconds(1.5f);
        }

        yield return new WaitForSeconds(4);

        for (int x = 0; x < 2; x++)
        {
            convos[1].gameObject.transform.GetChild(x).gameObject.SetActive(false);
        }
    }
}
