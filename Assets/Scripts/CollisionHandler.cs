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
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);// Quaternion.identity는 회전 없음(0,0,0) 을 나타냄
                                                                           // destroyedVFX라는 이펙트를, 이 오브젝트의 위치에서, 회전 없이 새로 생성한다
        Destroy(this.gameObject);
    }
}

