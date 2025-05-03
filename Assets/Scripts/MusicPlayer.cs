using UnityEngine;

public class MusicPlayer : MonoBehaviour// �÷��̾ �׾� �ٽ� �����ص� ��������� �ٽ� ���������ʰ� ��� �̾����� ���ִ� �ڵ� 
{
    void Start()
    {
        int numOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;//���� ���� �ִ� MusicPlayer ��ũ��Ʈ�� ���� ��� ������Ʈ�� ������ ����.
                                                                                                //���� 2�� �̻��̸�? �� �ߺ��̴ϱ� �ϳ��� ���־��Ѵ�

        if (numOfMusicPlayers > 1)// MusicPlayer�� �ϳ�����	�����ϰ� DontDestroyOnLoad()�� ���� �ٲ� ����
                                  // MusicPlayer�� �̹� ���� (2��° ������)	���� ���� �� �ٷ� ����
        {
            Destroy(gameObject);
        }
        
        else
        {
            DontDestroyOnLoad(gameObject);// �̰� ����Ƽ���� "���� �ٲ㵵 �ı����� ����"�� ��� ���п� ��� ������ ������ �ʰ� ��� ���
        }

    }
}


