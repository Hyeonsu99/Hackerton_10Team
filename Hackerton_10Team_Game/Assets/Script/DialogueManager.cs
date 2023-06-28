using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;       // 대화 내용을 표시할 Text 컴포넌트
    public Button continueButton;   // 다음 대화로 넘어가는 버튼

    private string[] dialogueData;  // 대화 데이터 배열
    private int currentDialogueIndex = 0;  // 현재 대화 인덱스

    void Start()
    {
        // 대화 데이터 초기화
        dialogueData = new string[]
        {
            "1",
            "2",
            "3",
            // 추가 대화 내용...
        };

        // 대화창 초기화
        ShowDialogue();
    }

    void Update()
    {
        // 터치 입력을 확인하여 다음 대화로 넘어감
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            NextDialogue();
        }
    }

    void ShowDialogue()
    {
        // 현재 대화 인덱스에 해당하는 대화 내용을 표시
        dialogueText.text = dialogueData[currentDialogueIndex];
    }

    public void NextDialogue()
    {
        // 다음 대화로 넘어가기 전에 대화 인덱스를 증가시킴
        currentDialogueIndex++;

        // 대화 인덱스가 대화 데이터의 범위를 벗어나면 대화 종료
        if (currentDialogueIndex >= dialogueData.Length)
        {
            EndDialogue();
            return;
        }

        // 다음 대화를 표시
        ShowDialogue();
    }

    void EndDialogue()
    {
        // 대화 종료 처리 (예: UI 비활성화 등)
        gameObject.SetActive(false);
    }
}
