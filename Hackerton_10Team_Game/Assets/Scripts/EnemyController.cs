using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform targetPlayer;

    [SerializeField] private float patrolSpeed = 2f;
    [SerializeField] private float range = 6f;
    [SerializeField] private float distance;
    private Vector3 move;
    [SerializeField] private int moveFlag = 0;

    private Animator animator;
    private float chasingSpeed;
    private bool isChasing = false;
    private bool reachedEnd = false;

    private void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        StartCoroutine(PatrolMove());
    }

    IEnumerator PatrolMove()
    {
        moveFlag = Random.Range(-1, 2);
        if (moveFlag == 0)
        {
            // animator.SetBool("isPatrol", false);
        }
        else
        {
            // animator.SetBool("isPatrol", true);
        }

        yield return new WaitForSeconds(2f);

        StartCoroutine(PatrolMove());
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movevelocity = Vector3.zero;
        distance = Vector3.Distance(transform.position, targetPlayer.position);
        string distFlag = "";

        if (distance <= range)
        {
            isChasing = true;
        }
        else if (distance > range)
        {
            isChasing = false;
        }

        if (isChasing)
        {
            Vector3 playerPos = targetPlayer.transform.position;

            if (playerPos.x < transform.position.x)
            {
                distFlag = "Left";
            }
            else if (playerPos.x > transform.position.x)
            {
                distFlag = "Right";
            }
        }
        else
        {
            if (moveFlag == -1)
            {
                distFlag = "Left";
            }
            else if (moveFlag == 1)
            {
                distFlag = "Right";
            }
        }

        if (distFlag == "Left")
        {
            movevelocity = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (distFlag == "Right")
        {
            movevelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.position += movevelocity * patrolSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isChasing)
        {
            if (collision.CompareTag("R_EndPoint"))
            {
                isChasing = false;
                moveFlag = -1;
            }
            else if (collision.CompareTag("L_EndPoint"))
            {
                isChasing = false;
                moveFlag = 1;
            }
        }
        else {
            if (collision.CompareTag("R_EndPoint"))
            {
                moveFlag = -1;
            }
            else if (collision.CompareTag("L_EndPoint"))
            {
                moveFlag = 1;
            }
        }
    }
    
}


