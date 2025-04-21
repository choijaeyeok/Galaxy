using UnityEngine;
using TMPro;
public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText;
    int score = 0; //������ �����ϴ� ���� (�ʱⰪ 0)
    public void IncreaseScore(int amount) //������ �ø��� �Լ�
    {
        score += amount;// score = score + amount�Ͱ���, score(���� ����), amount(������ ����)
        scoreboardText.text = score.ToString();
    }
}
       

