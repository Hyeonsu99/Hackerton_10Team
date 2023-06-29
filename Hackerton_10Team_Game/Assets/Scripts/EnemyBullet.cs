using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;  // �Ѿ��� �ӵ�
    public int damage = 10;   // �Ѿ��� ������

    private float timer = 0f;  // �Ѿ��� ������ ������ �ð�

    void Update()
    {
        // �Ѿ��� �̵���Ŵ
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // �Ѿ��� ������ �����Ͽ� ���ѵ� �ð��� ������ ����
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
                enemyHealth.HitDamage(damage);  // �������� �����ϴ� �Լ� ȣ��
            }

            Destroy(gameObject);
        }
    }
}
