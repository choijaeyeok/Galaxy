using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSceneManager : MonoBehaviour
{
   public void ReloadLevel()
   {
        StartCoroutine(ReloadLevelRoutine());//코루틴을 실행
                                             //코루틴은 "잠깐 기다렸다가" 무언가를 하고 싶을 때 사용
                                             //여기서는 1초 기다렸다가 씬을 다시 시작하려고 코루틴을 사용
    }

    IEnumerator ReloadLevelRoutine()// IEnumerator → 코루틴을 만들기 위한 반환 타입
    {
        yield return new WaitForSeconds(1f);//yield return은 "잠깐 멈췄다가, 조건이 충족되면 다시 이어서 실행"하라는 명령어,
                                            //new WaitForSeconds(1f) → "1초 기다리는 타이머 객체 생성"
                                            //WaitForSeconds(1f)는 클래스 이름이기 때문에 new 없이 쓰면 실제 객체를 만들지 않았기 때문에 작동하지 않음
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;//currentSceneIndex는 현재 실행 중인 씬의 번호(index)를 저장하는 변수
                                                                         //SceneManager.GetActiveScene()는 유니티에서 지금 실행되고 있는 씬(Scene)을 가져오는 함수.
                                                                         // .buildIndex는 그 씬이 몇 번째인지 확인한다
        SceneManager.LoadScene(currentSceneIndex);// SceneManager.LoadScene() → 지정한 씬을 불러와라, LoadScene(currentSceneIndex)는 → 지금 플레이 중인 씬을 다시 시작하는 것
    }
}



       


