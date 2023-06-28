using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        if (timer >= 3f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
         // 데미지를 입히기 위해 Health 컴포넌트를 가져옴
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);  // 데미지를 적용하는 함수 호출
        }

        Destroy(gameObject);
    }
}   
