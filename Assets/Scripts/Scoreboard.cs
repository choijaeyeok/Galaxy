using UnityEngine;
using TMPro;
public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText;
    int score = 0; //점수를 저장하는 변수 (초기값 0)
    public void IncreaseScore(int amount) //점수를 올리는 함수
    {
        score += amount;// score = score + amount와같다, score(현재 점수), amount(증가할 점수)
        scoreboardText.text = score.ToString();
    }
}
       

