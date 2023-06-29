using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;

    public float chaseDistance = 10f;
    private float chasingSpeed = 5f;
    private bool isChasing = false;

    public float movementSpeed = 3f;

    private int mVectorX = 1;

    void Update()
    {
        // Enemy와 Player 거리 계산
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseDistance && Mathf.Abs(player.position.y - transform.position.y) < 1 )
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        
    }

    private void FixedUpdate()
    {
        if (isChasing)
        {
            IsChasing();
        }
        else
        {
            IsMoving();
        }
    }

    private void IsChasing()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 movement = new Vector3(direction.x, 0, 0);

        transform.position += movement * chasingSpeed * Time.deltaTime;
    }

    private void IsMoving()
    {
        Vector3 movement = new Vector3(mVectorX, 0, 0);
        transform.localScale = new Vector3(mVectorX, 1, 1);

        transform.position += movement * movementSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndPoint"))
        {
            mVectorX *= -1;
            isChasing = false;
        }
    }
}
