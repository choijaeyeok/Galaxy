using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.ParticleSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;//GameObject[]는 GameObject 타입의 여러 개 데이터를 한꺼번에 저장할 수 있는 그릇
                                         //Inspector에서 레이저 오브젝트들을 배열로 설정할 수 있게 해줌
                                         //foreach (GameObject laser in lasers)가 [SerializeField] GameObject[] lasers에서 왼쪽 오른쪽 레이저를 가져옴
    
    [SerializeField] RectTransform crosshair;// RectTransform는 Canvas 아래 UI 요소들에 사용 UI는 사용자가 게임/앱과 상호작용할 수 있도록 도와주는 모든 시각적 요소
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;
    
    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }
    private void Update()// 매 프레임 실행됨
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
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
        foreach (GameObject laser in lasers)//foreach 루프는 모든 레이저 오브젝트를 한 번에 처리
                                            //lasers 배열에 있는(Left, Right Laser)모든 레이저 오브젝트를 laser라는 변수로 하나씩 꺼냄
                                            //foreach (GameObject laser in lasers)rk 실행되면 Left, Right Laser에  var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
                                            //emmissionModule.enabled = isFiring; 이게 실행됨
        {

            var emmissionModule = laser.GetComponent<ParticleSystem>().emission; // var은 변수의 타입을 자동으로 결정해 주는 키워드
                                                                             // Laser 오브젝트에서 ParticleSystem 컴포넌트를 가져옴 -> emission 가져옴(emission는 입자 방출 모듈)

        emmissionModule.enabled = isFiring;//isFiring 값에 따라 레이저 발사 ON/OFF 예시) isFiring == true → emmissionModule.enabled = true → 총알 발사
    
        }

}
    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }
    void MoveTargetPoint()// 마우스가 가리키는 곳에 3D 오브젝트를 옮기는 함수 마우스가 가리키는 곳을 기준으로
                          // 카메라에서 일정 거리만큼 앞쪽에 targetPoint 오브젝트를 따라가게 만드는 함수
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);//마우스 위치(x, y)에 targetDistance라는 z값(깊이)을 더해서 3D 위치
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition); // Input.mousePosition은 화면 좌표, camera.main는 현재 씬(Scene)에서 Main Camera를 가져오는 코드
                                                                                    // ScreenToWorldPoint()는 2D 화면 좌표(mousePosition)를 3D 게임 좌표로 바꾸기 위해서
                                                                                    // 마우스 위치 → 게임 위치로 변환해서 → 오브젝트를 그곳에 놓기
    }
    void AimLasers()//각 레이저 오브젝트를 targetPoint를 향해서 회전시키는 함수
                    //모든 레이저 오브젝트를 targetPoint를 향해 회전시켜주는 역할을 함. 즉, 총구가 타겟을 향하게 만드는 코드
                    //targetPoint라는 오브젝트가 마우스를 따라가니깐 마우스를 향해서 레이저오브젝트 회전이 바뀌는것
    {
        foreach (GameObject laser in lasers)
        { Vector3 fireDirection = targetPoint.position - this.transform.position;//목표 지점 - 내 위치 = 가야 할 방향, fireDirection = 목표 방향을 가리키는 벡터 ,
                                                                                                                                       //   레이저마다 개별적으로 조준하게 하려면 → laser.transform.position
                                                                                                                                         //  this.transform.position 는 레이저의 위치가 이 스크립트가 붙어 있는 오브젝트와 같으면 써도 되
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection); // Unity는 회전을 다룰 때 Quaternion 사용함, Quaternion.LookRotation(...)는 "이 방향을 향하도록 회전 만들기"
                                                                                                                                                  // 오브젝트를 저 방향(fireDirection)으로 보게 하고 싶어!" 라는 뜻
            laser.transform.rotation = rotationToTarget; //레이저가 targetPoint를 향해서 정확히 조준하게 됨

        }
    }
}






