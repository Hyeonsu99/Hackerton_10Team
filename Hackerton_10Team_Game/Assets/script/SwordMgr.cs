using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordMgr : MonoBehaviour
{
    public GameObject swordRPos;
    public GameObject swordLPos;
    public GameObject player;
   
    private void Start()
    {
        swordRPos.SetActive(false);
        swordLPos.SetActive(false);
    }

    public void buttonDownAtt()
    {
        if (player.GetComponent<playerCtrl>().PV == PlayerVector.Right)
        {
            swordRPos.SetActive(true);
            Invoke("RActiveAtt", 0.5f);
        }
        else if (player.GetComponent<playerCtrl>().PV == PlayerVector.Left)
        {
            swordLPos.SetActive(true);
            Invoke("LActiveAtt", 0.5f);
        }
    }

    void RActiveAtt()
    {
        swordRPos.SetActive(false);
    }
    void LActiveAtt()
    {
        swordLPos.SetActive(false);
    }
   

}
