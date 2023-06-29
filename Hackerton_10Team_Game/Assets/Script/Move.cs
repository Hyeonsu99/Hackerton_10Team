using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   float moveSpeed= 20f;
   Rigidbody2D rig2d;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float playerMove=Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;

       if(Input.GetKeyDown(KeyCode.LeftArrow))
       {
        playerMove=moveSpeed*Time.deltaTime;
       }
       if(Input.GetKeyDown(KeyCode.RightArrow))
       {
        playerMove=-moveSpeed*Time.deltaTime;
       }

       this.transform.Translate(new Vector3(playerMove,0,0));
    }

    
}
