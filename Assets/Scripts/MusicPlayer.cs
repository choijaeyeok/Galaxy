using UnityEngine;

public class MusicPlayer : MonoBehaviour// 플레이어가 죽어 다시 시작해도 배경음악은 다시 시작하지않고 계속 이어지게 해주는 코드 
{
    void Start()
    {
        int numOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;//현재 씬에 있는 MusicPlayer 스크립트를 가진 모든 오브젝트의 개수를 센다.
                                                                                                //만약 2개 이상이면? → 중복이니까 하나를 없애야한다

        if (numOfMusicPlayers > 1)// MusicPlayer가 하나뿐임	유지하고 DontDestroyOnLoad()로 씬이 바뀌어도 유지
                                  // MusicPlayer가 이미 있음 (2개째 생성됨)	새로 생긴 건 바로 제거
        {
            Destroy(gameObject);
        }
        
        else
        {
            DontDestroyOnLoad(gameObject);// 이건 유니티에서 "씬을 바꿔도 파괴하지 마라"는 명령 덕분에 배경 음악이 끊기지 않고 계속 재생
        }

    }
}


