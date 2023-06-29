using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerHP_Controller playerHP_Controller;
    private int life = 10;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("")) //적 무기 태그 설정
        {
            life--;
            if(life <= 0)
            {
                SceneManager.LoadScene("");  // GameOver Scene 불러오기
            }
        }
    }
}
