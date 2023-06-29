using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private Transform targetPlayer;
    [SerializeField] private GameObject enemyObj;
    [SerializeField] private GameObject EnemyBulletPrefab;

    [SerializeField] private Transform BulletLPos;
    [SerializeField] private Transform BulletRPos;

    [SerializeField] private float range = 0f;
    [SerializeField] private float distance;

    [SerializeField] private float maxTimer = 2f;
    [SerializeField] private float timer = 0f;

    private bool isTraceAtk = false;
    private GameObject e_Bullet;
    

    private void FixedUpdate()
    {
        Shooting();
    }

    private void Shooting()
    {
        Vector3 movevelocity = Vector3.zero;
        distance = Vector3.Distance(transform.position, targetPlayer.position);

        if (distance <= range)
        {
            isTraceAtk = true;
        }
        else if (distance > range)
        {
            isTraceAtk = false;
        }


        if (isTraceAtk)
        {
            Vector3 playerPos = targetPlayer.transform.position;
            movevelocity = Vector3.zero;

            timer += Time.deltaTime;
            if (timer >= maxTimer)
            {
                if (playerPos.x < transform.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);

                    e_Bullet = Instantiate(EnemyBulletPrefab);
                    e_Bullet.transform.position = BulletRPos.position;

                    e_Bullet.GetComponent<Rigidbody2D>().AddForce(new Vector3(-1000, 0, 0));

                }
                else if (playerPos.x > transform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);

                    e_Bullet = Instantiate(EnemyBulletPrefab);
                    e_Bullet.transform.position = BulletLPos.position;

                    e_Bullet.GetComponent<Rigidbody2D>().AddForce(new Vector3(1000, 0, 0));
                }

                //animator.SetTrigger(""); // 공격 애니메이션 추가 적용

                timer = 0;
            }
        }

    }
}
