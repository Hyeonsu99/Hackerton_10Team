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
        if (collision.CompareTag("")) //�� ���� �±� ����
        {
            life--;
            if(life <= 0)
            {
                SceneManager.LoadScene("");  // GameOver Scene �ҷ�����
            }
        }
    }
}
