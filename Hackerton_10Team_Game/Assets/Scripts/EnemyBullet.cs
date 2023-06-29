using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;  // 총알의 속도
    public int damage = 10;   // 총알의 데미지

    private float timer = 0f;  // 총알이 생성된 이후의 시간

    void Update()
    {
        // 총알을 이동시킴
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // 총알의 수명을 측정하여 제한된 시간이 지나면 삭제
        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemyController enemyHealth = collision.GetComponent<EnemyController>();

            if (enemyHealth != null)
            {
                enemyHealth.HitDamage(damage);  // 데미지를 적용하는 함수 호출
            }

            Destroy(gameObject);
        }
    }
}
