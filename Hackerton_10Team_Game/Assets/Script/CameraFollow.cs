using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public GameObject target;
   public float moveSpeed;
   private Vector2 targetPosition; 

    private void Start()
    {
        
    }

    void Update()
    {
        if(target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y);

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed*Time.deltaTime);
        }
    }
}
