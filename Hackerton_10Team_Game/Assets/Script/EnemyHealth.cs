using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 10;  // 적의 최대 체력
    private int currentHealth;   // 적의 현재 체력

    void Start()
    {
        currentHealth = maxHealth;  // 현재 체력을 최대 체력으로 초기화
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  // 데미지 값을 체력에서 차감

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // 적이 사망한 경우의 동작을 구현 (예: 오브젝트 삭제)
        Destroy(gameObject);
    }
}
