using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;   
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);// Quaternion.identity는 회전 없음(0,0,0) 을 나타냄
        Destroy(this.gameObject);
    }
}
