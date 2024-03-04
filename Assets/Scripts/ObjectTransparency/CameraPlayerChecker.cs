using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerChecker : MonoBehaviour
{
    public ObjectFader[] objects; 
    private ObjectFader _fader; 

    void Update()
    {
        FindPlayerLocation();
    }

    private void FindPlayerLocation()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            RaycastHit[] hits;
            Vector3 dir = player.transform.position - transform.position;
            Ray ray = new Ray(transform.position, dir);

            hits = Physics.RaycastAll(transform.position, dir);
            for (int i = 0; i < hits.Length; i++)
            {
                if(Physics.Raycast(ray,out hits[i]))
                {
                    if (hits[i].collider == null)
                        return; 

                    if(hits[i].collider.gameObject != player)
                    {
                        _fader = hits[i].collider.GetComponent<ObjectFader>();
                        if (_fader != null)
                        {
                            _fader.Fade();
                        }
                    }
                    else
                    {
                        for(int j =0; j<objects.Length; j++)
                        {
                            objects[j].ResetFade();
                        }
                    }                    
                }
            }
        }
    }
}
