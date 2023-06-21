using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SNOW"))
        {
            // 충돌한 오브젝트가 PLAYER 태그를 가진 경우
            // 해당 오브젝트를 파괴합니다.
            Destroy(collision.gameObject);
        }
    }
}