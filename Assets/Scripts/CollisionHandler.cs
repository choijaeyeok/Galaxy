using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;

    GameSceneManager gameSceneManager;
    private void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        gameSceneManager.ReloadLevel();
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);// Quaternion.identity�� ȸ�� ����(0,0,0) �� ��Ÿ��
                                                                           // destroyedVFX��� ����Ʈ��, �� ������Ʈ�� ��ġ����, ȸ�� ���� ���� �����Ѵ�
        Destroy(this.gameObject);
    }
}

