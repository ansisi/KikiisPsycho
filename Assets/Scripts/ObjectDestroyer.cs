using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SNOW"))
        {
            // �浹�� ������Ʈ�� PLAYER �±׸� ���� ���
            // �ش� ������Ʈ�� �ı��մϴ�.
            Destroy(collision.gameObject);
        }
    }
}