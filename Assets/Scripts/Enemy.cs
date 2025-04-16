using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    private void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);// Quaternion.identity�� ȸ�� ����(0,0,0)�� ��Ÿ��
        Destroy(this.gameObject);
    }
}
