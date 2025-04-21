using NUnit.Framework.Internal.Builders;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX; // 폭발 이펙트 프리팹(적이 죽을 때 생성할 이펙트)
    [SerializeField] int hitPoints = 3; // 적의 체력
    [SerializeField] int scoreValue = 10; // 적이 죽을 때 올라갈 점수

    Scoreboard scoreboard; // Scoreboard스크립트가 붙은 오브젝트를 찾아서  그 오브젝트를 scoreboard라는 변수에 반환해야 하기
                           // 때문에 Scoreboard타입의 변수를 써야한다.

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();//게임 씬에서 Scoreboard스크립트가 붙은 오브젝트를 찾고, 그 오브젝트를 scoreboard라는 변수에 반환
    }
    private void OnParticleCollision(GameObject other)//파티클에 맞으면	OnParticleCollision()이 호출됨 -> ProcessHit()호출됨 ->
                                                      //체력 감소	hitPoints-- -> 체력 0 되면	이펙트 생성 + 적 파괴
    {
        ProcessHit();
    }
    private void ProcessHit()
    {
        hitPoints--; // 체력 감소

        if (hitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue); // 점수 증가, (Scoreboard스크립트에서 IncreaseScore(int amount)함수 이용)
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);// 이펙트 생성, Quaternion.identity는 회전 없음(0,0,0)을 나타냄
            Destroy(this.gameObject); // 적 삭제
        }
    }
}




