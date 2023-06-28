using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class GunShot : MonoBehaviour
{

    public float f_bulletPower = 10.0f;
    public float f_BulletSpeed = 5.0f;
    public GameObject Bullet;
    public Transform BulletPos;
    GameObject bullet;

    public void buttonDownAtt()
    {
        bullet = Instantiate(Bullet);
        bullet.transform.position = BulletPos.position;
        Vector3 bulletVelocity = new Vector3(1.0f,0,0);
        bullet.GetComponent<Rigidbody>().AddForce(new Vector3(1000, 0, 0));
        Destroy(bullet, 3.0f);
    }

    
}