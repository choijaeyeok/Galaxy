using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.ParticleSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;//GameObject[]�� GameObject Ÿ���� ���� �� �����͸� �Ѳ����� ������ �� �ִ� �׸�
                                         //Inspector���� ������ ������Ʈ���� �迭�� ������ �� �ְ� ����
                                         //foreach (GameObject laser in lasers)�� [SerializeField] GameObject[] lasers���� ���� ������ �������� ������
    
    [SerializeField] RectTransform crosshair;// RectTransform�� Canvas �Ʒ� UI ��ҵ鿡 ��� UI�� ����ڰ� ����/�۰� ��ȣ�ۿ��� �� �ֵ��� �����ִ� ��� �ð��� ���
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;
    
    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }
    private void Update()// �� ������ �����
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
    }

    public void OnFire(InputValue value) //nput System�� "Fire" �׼��� ����� �� �ڵ����� ȣ��
                                         //(OnFire�� Fire�� ��ǲ �׼� �̸�) ���콺�� Ŭ���ϰų� ���� �� ����Ǵ� �Լ�
                                         // value�� ���� ���콺 Ŭ���� ���� ���¸� �˷���
    {
        isFiring = value.isPressed;//���콺�� �������� �����ؼ� isFiring�� ���� ����) value.isPressed == true �� isFiring = true --->�� �ڵ� ���п� isFiring�� ��ưó�� �����ϴ� ���� 
                                   //value.isPressed�� ���콺 Ŭ���ߴ��� (true), ���� �ô��� (false) �˷���
                                   //Ŭ���ϸ� isFiring = true, �� ���� isFiring = false
    }
    void ProcessFiring()
    {
        foreach (GameObject laser in lasers)//foreach ������ ��� ������ ������Ʈ�� �� ���� ó��
                                            //lasers �迭�� �ִ�(Left, Right Laser)��� ������ ������Ʈ�� laser��� ������ �ϳ��� ����
                                            //foreach (GameObject laser in lasers)rk ����Ǹ� Left, Right Laser��  var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
                                            //emmissionModule.enabled = isFiring; �̰� �����
        {

            var emmissionModule = laser.GetComponent<ParticleSystem>().emission; // var�� ������ Ÿ���� �ڵ����� ������ �ִ� Ű����
                                                                             // Laser ������Ʈ���� ParticleSystem ������Ʈ�� ������ -> emission ������(emission�� ���� ���� ���)

        emmissionModule.enabled = isFiring;//isFiring ���� ���� ������ �߻� ON/OFF ����) isFiring == true �� emmissionModule.enabled = true �� �Ѿ� �߻�
    
        }

}
    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }
    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
}




