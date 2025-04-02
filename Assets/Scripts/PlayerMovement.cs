using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.Controls.AxisControl;
public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;

    [SerializeField] float controlPitchFactor = 10f;
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float rotationSpeed = 10f;
    Vector2 movement;//movement는 이동 방향을 저장(플레이어가 어디로 갈지 알려주는 값)
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }                                                                                                                                                        
    public void OnMove(InputValue value) //유니티의 새로운 Input System에서 사용되는 입력 처리 함수, OnMove는 플레이어가 키보드나 조이스틱을 눌렀을 때 반응하는 함수
    {                                                                      //InputValue value는 플레이어가 입력한 방향 정보(WASD, 방향키, 조이스틱 등)가 저장
        movement = value.Get<Vector2>();//입력 값을 Vector2 형식으로 가져옴 /예)키보드 W를 누르면 (0, 1), A를 누르면 (-1, 0) 같은 값이 나옴
    }
    void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;//movement.x는 수평 방향 (AD) 값을 나타냄, movement.x를 곱하는 이유는 이동 방향을 계산하기 위해서 -1이면 왼쪽 1이면 오른쪽
        float rawXPos = transform.localPosition.x + xOffset;//transform.localPosition.x는 지금 플레이어가 있는 현재 x 위치, xOffset는 키보드를 눌러서 이동할 거리
                                                                                                         // rawXPos는 "이동하려는 위치" (아무 제한 없이 계산된 값= 화면 밖으로 나갈 수 있음)
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);//플레이어가 화면 밖으로 나가지 못하게 막아주는 역할, -xClampRange → 갈 수 있는 제일 왼쪽 끝, xClampRange → 갈 수 있는 제일 오른쪽 끝
                                                                                                                   // Mathf.Clamp()는 rawXPos 값이 최소값(-xClampRange)과 최대값(xClampRange) 사이에 있도록 조정.  clampedXPos → "이동 가능한 범위 안에서 조정된 위치"
        float yOffset = movement.y * controlSpeed * Time.deltaTime;//movement.y는 수평 방향 (WS) 값을 나타냄
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);
        transform.localPosition = new Vector3 (clampedXPos, clampedYPos, 0f);//localPosition은 게임 오브젝트의 부모 객체를 기준으로 한 상대적인 위치를 설정하는 프로퍼티
    }                                                                                                                                                                                                          //현재 x 위치에 xOffset을 더해서 새로운 위치를 계산, 오른쪽으로 1만큼 가려면 transform.localPosition.x + 1이 되고,

    void ProcessRotation()
    {
        float pitch = controlPitchFactor * movement.y;
        float roll = -controlRollFactor * movement.x;
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);//Quaternion.Lerp(시작 회전, 목표 회전, 부드럽게 변하는 속도);
    }
}                                                                                                                                                                                                                   // 왼쪽으로 1만큼 가려면 transform.localPosition.x - 1이됨.



