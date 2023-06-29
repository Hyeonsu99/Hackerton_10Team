using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController_Standing : MonoBehaviour
{
    [SerializeField] private int hp = 10;

    Animator animator;
    SpriteRenderer spriter;
    Rigidbody2D rgb2d;
    Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        rgb2d = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    IEnumerator HitEffect()
    {
        spriter.color = new Color32(255, 255, 255, 160);
        yield return new WaitForSeconds(0.1f);
        spriter.color = new Color32(255, 255, 255, 255);
        yield return null;
    }

    public void HitDamage(int dmg)
    {
        hp -= dmg;

        if (hp > 0)
        {
            StartCoroutine("HitEffect");
        }
        else
        {
            // 적 죽음 애니메이션 or 이펙트
        }
    }
}
