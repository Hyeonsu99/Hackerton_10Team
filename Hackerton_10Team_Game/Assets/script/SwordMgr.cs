using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordMgr : MonoBehaviour
{
    public GameObject swordR;
    public GameObject swordL;
    public Transform swordRPos;
    public Transform swordLPos;
    public GameObject player;
   
   

    public void buttonDownAtt()
    {
        if (player.GetComponent<playerCtrl>().PV == PlayerVector.Right)
        {
            sword = Instantiate(swordRPos);
            sword.SetActive(true);
            sword.transform.position = swordRPos.transform.position;
            Vector3 bulletVelocity = new Vector2(1.0f, 0);
            Destroy(sword, 0.5f);
        }
        else if (player.GetComponent<playerCtrl>().PV == PlayerVector.Left)
        {
            sword = Instantiate(swordLPos);
            sword.SetActive(true);
            sword.transform.position = swordLPos.transform.position;
            Vector3 bulletVelocity = new Vector2(1.0f, 0);
            Destroy(sword, 0.5f);
        }
    }
   

}
