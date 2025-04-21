using TMPro;
using UnityEngine;
public class DialogueLines : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines; // 여러 줄의 자막(대사)를 저장해놓는 배열
    [SerializeField]  TMP_Text  dialogueText; //실제 화면에 자막을 띄워줄 TMP_Text 컴포넌트

    int currentLine = 0; // 지금 몇 번째 줄 자막을 보여주고 있는지 기억하는 숫자, 처음엔 0줄부터 시작
    public void NextDialogueLine()// 타임라인에서 시그널을 보낼 때, 그 시그널이 이 함수를 호출
    {
        currentLine ++; //다음 자막으로 넘어가겠다는 뜻
        dialogueText.text = timelineTextLines[currentLine]; //dialogueText.text = timelineTextLines[0]는 첫번째 문자열, dialogueText.text = timelineTextLines[1]는 두번째 문자열
    }
}

