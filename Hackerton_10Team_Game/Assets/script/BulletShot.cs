using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
