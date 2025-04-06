using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject laser;

    bool isFiring = false;

    private void Update()
    {
        ProcessFiring();
    }

    public void OnFire(InputValue value) //nput System의 "Fire" 액션이 실행될 때 자동으로 호출
                                         //(OnFire의 Fire은 인풋 액션 이름) 마우스를 클릭하거나 뗐을 때 실행되는 함수
                                         // value는 왼쪽 마우스 클릭에 대한 상태를 알려줌
    {
        isFiring = value.isPressed;//마우스를 눌렀는지 감지해서 isFiring에 저장 예시) value.isPressed == true → isFiring = true --->이 코드 덕분에 isFiring은 버튼처럼 동작하는 변수 
                                   //value.isPressed는 마우스 클릭했는지 (true), 손을 뗐는지 (false) 알려줌
                                   //클릭하면 isFiring = true, 손 떼면 isFiring = false
    }
    void ProcessFiring()
    {
        var emmissionModule = laser.GetComponent<ParticleSystem>().emission; // var은 변수의 타입을 자동으로 결정해 주는 키워드
                                                                             // Laser 오브젝트에서 ParticleSystem 컴포넌트를 가져옴 -> emission 가져옴(emission는 입자 방출 모듈)

        emmissionModule.enabled = isFiring;//isFiring 값에 따라 레이저 발사 ON/OFF 예시) isFiring == true → emmissionModule.enabled = true → 총알 발사
    
}
    

}




