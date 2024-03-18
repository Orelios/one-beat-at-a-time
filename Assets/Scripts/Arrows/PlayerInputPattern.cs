using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputPattern : Singleton<PlayerInputPattern>
{
    public Arrows[] playerInputArrows; 
    public GameObject[] playerInputPattens;
    public int reset;
    private void Update()
    {
        if(reset <= 0 || reset > 2)
        {
            reset = 0; 
        }
    }
    public void CheckPlayerInputSprites()
    {
        if (reset <= 0 || reset > 2)
        {
            reset = 0;
        }
        if (reset == 2)
        {
            for (int i = 0; i < 4; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite =
                   null;
            }
            reset = 0;
            //Debug.Log("aksja");
        }
    }
}
