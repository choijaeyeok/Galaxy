using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;   
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);// Quaternion.identity�� ȸ�� ����(0,0,0) �� ��Ÿ��
        Destroy(this.gameObject);
    }
}
