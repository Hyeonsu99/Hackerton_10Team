using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public enum PlayerState
{
    idle,Run,Jump,Att,Death
}

public enum PlayerVector
{
    Left,Right
}

public class playerCtrl : MonoBehaviour
{
    
    public float f_jumpPower = 400f;
    public AudioClip[] Sound;
    public Animator anim;
    public PlayerState PS;
    public PlayerVector PV;
    public GameObject RenderObj;
    public bool LeftMove = false;
    public bool RightMove = false;
    float f_playerSpeed = 4.0f;
    Vector3 moveVelocity = Vector3.zero;
    int jumpCount = 0;
    // Update is called once per frame
  
    private void FixedUpdate()
    {
       if(LeftMove)
        {
            moveVelocity = new Vector3(-0.50f, 0, 0);
            transform.position += moveVelocity* f_playerSpeed * Time.deltaTime;
        }
       if(RightMove)
        {
            moveVelocity = new Vector3(+0.50f, 0, 0);
            transform.position += moveVelocity * f_playerSpeed * Time.deltaTime;
        }
    }

 
    public void ButtonDownLeft()
    {
        PS = PlayerState.Run;
        PV = PlayerVector.Left;
        LeftMove = true;
        anim.SetTrigger("Run");
        anim.SetBool("idel", false);
        RenderObj.GetComponent<SpriteRenderer>().flipX = true;
        
    }
    public void ButtonUpLeft()
    {

        anim.SetBool("idel", true);
        LeftMove = false;

    }
    public void ButtonDownRight()
    {
       RightMove = true;
       PS = PlayerState.Run;
       PV = PlayerVector.Right;
       anim.SetTrigger("Run");
       anim.SetBool("idel", false);
       RenderObj.GetComponent<SpriteRenderer>().flipX = false;
    }
    public void ButtonUpRight()
    {
        RightMove = false;
        anim.SetBool("idel", true);
    }
    
    public void ButtonDonwJump()
    {
        Jump();
    }

    public void ButtonAtt()
    {
        PS = PlayerState.Att;    
        anim.SetTrigger("Att");
        if (PV == PlayerVector.Left)
        {
            RenderObj.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (PV == PlayerVector.Right)
        {
            RenderObj.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    void Jump()
    {
        PS = PlayerState.Jump;
        jumpCount++;
        if(jumpCount ==1)
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,f_jumpPower,0));
        }
        
    }
    void GameOver()
    {
        PS = PlayerState.Death;
        SceneManager.LoadScene("");
    }
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Gound")
        {
            PS = PlayerState.Run;
            Debug.Log("땅바닥");
            jumpCount = 0;
        }
        if(col.gameObject.tag == "enemy" && PS == PlayerState.Att)
        {
            //적의 피를 깍음;
        }

    }
    private AudioClip GetAudioClip(int Num)
    {
        return Sound[Num];
    }
    void soundPlay(int Num, AudioClip audioClip)
    {
        GetComponent<AudioSource>().clip = audioClip;
        GetComponent<AudioSource>().Play();
    }
     [SerializeField] private PlayerHP_Controller playerHP_Controller;
    public int life = 10;

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

