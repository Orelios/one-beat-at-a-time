using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float groundDistance;

    [SerializeField] private LayerMask groundLayer; 
    void Update()
    {
        CheckGroundHeight(); 
        MovePlayer(); 
       
    }
    private void CheckGroundHeight()
    {
        RaycastHit hit;
        Vector3 castPosition = transform.position;
        castPosition.y += 1;

        if (Physics.Raycast(castPosition, -transform.up, out hit, Mathf.Infinity, groundLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePosition = transform.position;
                movePosition.y = hit.point.y + groundDistance;
                transform.position = movePosition;
            }
        }
    }
    private void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 movedirection = new Vector3(x, 0, y);
        gameObject.GetComponent<Rigidbody>().velocity = movedirection.normalized * speed;
        if(movedirection != Vector3.zero)
        {
            gameObject.transform.forward = movedirection;
            gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(0f, 0f, 0f); 
        }
    }
}
