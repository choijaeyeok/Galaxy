using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    private void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);// Quaternion.identity는 회전 없음(0,0,0)을 나타냄
        Destroy(this.gameObject);
    }
}
