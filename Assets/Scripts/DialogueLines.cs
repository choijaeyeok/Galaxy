using TMPro;
using UnityEngine;
public class DialogueLines : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines; // ���� ���� �ڸ�(���)�� �����س��� �迭
    [SerializeField]  TMP_Text  dialogueText; //���� ȭ�鿡 �ڸ��� ����� TMP_Text ������Ʈ

    int currentLine = 0; // ���� �� ��° �� �ڸ��� �����ְ� �ִ��� ����ϴ� ����, ó���� 0�ٺ��� ����
    public void NextDialogueLine()// Ÿ�Ӷ��ο��� �ñ׳��� ���� ��, �� �ñ׳��� �� �Լ��� ȣ��
    {
        currentLine ++; //���� �ڸ����� �Ѿ�ڴٴ� ��
        dialogueText.text = timelineTextLines[currentLine]; //dialogueText.text = timelineTextLines[0]�� ù��° ���ڿ�, dialogueText.text = timelineTextLines[1]�� �ι�° ���ڿ�
    }
}

