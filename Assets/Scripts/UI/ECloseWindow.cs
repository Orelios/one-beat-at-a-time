using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECloseWindow : MonoBehaviour
{
    public GameObject bed, a1,a2,a3,a4;

    private void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        bed.GetComponent<Collider>().enabled = false;
        a1.GetComponent<Collider>().enabled = false;
        a2.GetComponent<Collider>().enabled = false;
        a3.GetComponent<Collider>().enabled = false;
        a4.GetComponent<Collider>().enabled = false;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            StartCoroutine(TurnOnCollider());
        }
    }

    public void SetObjectToFalse() 
    {
        StartCoroutine(TurnOnCollider());
    }

    IEnumerator TurnOnCollider() 
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        bed.GetComponent<Collider>().enabled = true;
        a1.GetComponent<Collider>().enabled = true;
        a2.GetComponent<Collider>().enabled = true;
        a3.GetComponent<Collider>().enabled = true;
        a4.GetComponent<Collider>().enabled = true;
    }
}
