using NUnit.Framework.Internal.Builders;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX; // ���� ����Ʈ ������(���� ���� �� ������ ����Ʈ)
    [SerializeField] int hitPoints = 3; // ���� ü��
    [SerializeField] int scoreValue = 10; // ���� ���� �� �ö� ����

    Scoreboard scoreboard; // Scoreboard��ũ��Ʈ�� ���� ������Ʈ�� ã�Ƽ�  �� ������Ʈ�� scoreboard��� ������ ��ȯ�ؾ� �ϱ�
                           // ������ ScoreboardŸ���� ������ ����Ѵ�.

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();//���� ������ Scoreboard��ũ��Ʈ�� ���� ������Ʈ�� ã��, �� ������Ʈ�� scoreboard��� ������ ��ȯ
    }
    private void OnParticleCollision(GameObject other)//��ƼŬ�� ������	OnParticleCollision()�� ȣ��� -> ProcessHit()ȣ��� ->
                                                      //ü�� ����	hitPoints-- -> ü�� 0 �Ǹ�	����Ʈ ���� + �� �ı�
    {
        ProcessHit();
    }
    private void ProcessHit()
    {
        hitPoints--; // ü�� ����

        if (hitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue); // ���� ����, (Scoreboard��ũ��Ʈ���� IncreaseScore(int amount)�Լ� �̿�)
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);// ����Ʈ ����, Quaternion.identity�� ȸ�� ����(0,0,0)�� ��Ÿ��
            Destroy(this.gameObject); // �� ����
        }
    }
}




