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
        var emmissionModule = laser.GetComponent<ParticleSystem>().emission; // var�� ������ Ÿ���� �ڵ����� ������ �ִ� Ű����
                                                                             // Laser ������Ʈ���� ParticleSystem ������Ʈ�� ������ -> emission ������(emission�� ���� ���� ���)

        emmissionModule.enabled = isFiring;//isFiring ���� ���� ������ �߻� ON/OFF ����) isFiring == true �� emmissionModule.enabled = true �� �Ѿ� �߻�
    
}
    

}




