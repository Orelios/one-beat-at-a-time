using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECloseWindow : MonoBehaviour
{
    public GameObject bed;

    private void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        bed.GetComponent<Collider>().enabled = false;
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
    }
}
