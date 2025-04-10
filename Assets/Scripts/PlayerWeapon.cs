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
        AimLasers();
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
    void MoveTargetPoint()// ���콺�� ����Ű�� ���� 3D ������Ʈ�� �ű�� �Լ� ���콺�� ����Ű�� ���� ��������
                          // ī�޶󿡼� ���� �Ÿ���ŭ ���ʿ� targetPoint ������Ʈ�� ���󰡰� ����� �Լ�
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);//���콺 ��ġ(x, y)�� targetDistance��� z��(����)�� ���ؼ� 3D ��ġ
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition); // Input.mousePosition�� ȭ�� ��ǥ, camera.main�� ���� ��(Scene)���� Main Camera�� �������� �ڵ�
                                                                                    // ScreenToWorldPoint()�� 2D ȭ�� ��ǥ(mousePosition)�� 3D ���� ��ǥ�� �ٲٱ� ���ؼ�
                                                                                    // ���콺 ��ġ �� ���� ��ġ�� ��ȯ�ؼ� �� ������Ʈ�� �װ��� ����
    }
    void AimLasers()//�� ������ ������Ʈ�� targetPoint�� ���ؼ� ȸ����Ű�� �Լ�
                    //��� ������ ������Ʈ�� targetPoint�� ���� ȸ�������ִ� ������ ��. ��, �ѱ��� Ÿ���� ���ϰ� ����� �ڵ�
                    //targetPoint��� ������Ʈ�� ���콺�� ���󰡴ϱ� ���콺�� ���ؼ� ������������Ʈ ȸ���� �ٲ�°�
    {
        foreach (GameObject laser in lasers)
        { Vector3 fireDirection = targetPoint.position - this.transform.position;//��ǥ ���� - �� ��ġ = ���� �� ����, fireDirection = ��ǥ ������ ����Ű�� ���� ,
                                                                                                                                       //   ���������� ���������� �����ϰ� �Ϸ��� �� laser.transform.position
                                                                                                                                         //  this.transform.position �� �������� ��ġ�� �� ��ũ��Ʈ�� �پ� �ִ� ������Ʈ�� ������ �ᵵ ��
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection); // Unity�� ȸ���� �ٷ� �� Quaternion �����, Quaternion.LookRotation(...)�� "�� ������ ���ϵ��� ȸ�� �����"
                                                                                                                                                  // ������Ʈ�� �� ����(fireDirection)���� ���� �ϰ� �;�!" ��� ��
            laser.transform.rotation = rotationToTarget; //�������� targetPoint�� ���ؼ� ��Ȯ�� �����ϰ� ��

        }
    }
}






