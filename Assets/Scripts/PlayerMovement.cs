using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.Controls.AxisControl;
public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;
    Vector2 movement;//movement�� �̵� ������ ����(�÷��̾ ���� ���� �˷��ִ� ��)
    void Update()
    {
        ProcessTranslation();
    }                                                                                                                                                        
    public void OnMove(InputValue value) //����Ƽ�� ���ο� Input System���� ���Ǵ� �Է� ó�� �Լ�, OnMove�� �÷��̾ Ű���峪 ���̽�ƽ�� ������ �� �����ϴ� �Լ�
    {                                                                      //InputValue value�� �÷��̾ �Է��� ���� ����(WASD, ����Ű, ���̽�ƽ ��)�� ����
        movement = value.Get<Vector2>();//�Է� ���� Vector2 �������� ������ /��)Ű���� W�� ������ (0, 1), A�� ������ (-1, 0) ���� ���� ����
    }
    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;//movement.x�� ���� ���� (AD) ���� ��Ÿ��, movement.x�� ���ϴ� ������ �̵� ������ ����ϱ� ���ؼ� -1�̸� ���� 1�̸� ������
        float rawXPos = transform.localPosition.x + xOffset;//transform.localPosition.x�� ���� �÷��̾ �ִ� ���� x ��ġ, xOffset�� Ű���带 ������ �̵��� �Ÿ�
                                                                                                         // rawXPos�� "�̵��Ϸ��� ��ġ" (�ƹ� ���� ���� ���� ��= ȭ�� ������ ���� �� ����)
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);//�÷��̾ ȭ�� ������ ������ ���ϰ� �����ִ� ����, -xClampRange �� �� �� �ִ� ���� ���� ��, xClampRange �� �� �� �ִ� ���� ������ ��
                                                                                                                   // Mathf.Clamp()�� rawXPos ���� �ּҰ�(-xClampRange)�� �ִ밪(xClampRange) ���̿� �ֵ��� ����.  clampedXPos �� "�̵� ������ ���� �ȿ��� ������ ��ġ"
        float yOffset = movement.y * controlSpeed * Time.deltaTime;//movement.y�� ���� ���� (WS) ���� ��Ÿ��
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);
        transform.localPosition = new Vector3 (clampedXPos, clampedYPos, 0f);//localPosition�� ���� ������Ʈ�� �θ� ��ü�� �������� �� ������� ��ġ�� �����ϴ� ������Ƽ
    }                                                                                                                                                                                                          //���� x ��ġ�� xOffset�� ���ؼ� ���ο� ��ġ�� ���, ���������� 1��ŭ ������ transform.localPosition.x + 1�� �ǰ�,
}                                                                                                                                                                                                                   // �������� 1��ŭ ������ transform.localPosition.x - 1�̵�.





