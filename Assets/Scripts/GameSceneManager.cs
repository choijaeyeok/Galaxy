using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSceneManager : MonoBehaviour
{
   public void ReloadLevel()
   {
        StartCoroutine(ReloadLevelRoutine());//�ڷ�ƾ�� ����
                                             //�ڷ�ƾ�� "��� ��ٷȴٰ�" ���𰡸� �ϰ� ���� �� ���
                                             //���⼭�� 1�� ��ٷȴٰ� ���� �ٽ� �����Ϸ��� �ڷ�ƾ�� ���
    }

    IEnumerator ReloadLevelRoutine()// IEnumerator �� �ڷ�ƾ�� ����� ���� ��ȯ Ÿ��
    {
        yield return new WaitForSeconds(1f);//yield return�� "��� ����ٰ�, ������ �����Ǹ� �ٽ� �̾ ����"�϶�� ��ɾ�,
                                            //new WaitForSeconds(1f) �� "1�� ��ٸ��� Ÿ�̸� ��ü ����"
                                            //WaitForSeconds(1f)�� Ŭ���� �̸��̱� ������ new ���� ���� ���� ��ü�� ������ �ʾұ� ������ �۵����� ����
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;//currentSceneIndex�� ���� ���� ���� ���� ��ȣ(index)�� �����ϴ� ����
                                                                         //SceneManager.GetActiveScene()�� ����Ƽ���� ���� ����ǰ� �ִ� ��(Scene)�� �������� �Լ�.
                                                                         // .buildIndex�� �� ���� �� ��°���� Ȯ���Ѵ�
        SceneManager.LoadScene(currentSceneIndex);// SceneManager.LoadScene() �� ������ ���� �ҷ��Ͷ�, LoadScene(currentSceneIndex)�� �� ���� �÷��� ���� ���� �ٽ� �����ϴ� ��
    }
}



       


