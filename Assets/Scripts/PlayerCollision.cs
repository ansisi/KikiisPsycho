using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{

    private int score = 0; // ���� ����
    public Text scoreText; // ������ ǥ���� Text UI

    private float pushForce = 10f; // �з����� ���� ����

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WALL"))
        {
            // �浹�� ������Ʈ�� WALL �±׸� ���� ���
            // �浹 ����� �ݴ� �������� ���� ���� Player ������Ʈ�� �о���ϴ�.
            Vector3 pushDirection = collision.transform.position - transform.position;
            pushDirection.Normalize();
            GetComponent<Rigidbody>().AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("SNOW"))
        {
            // �浹�� ������Ʈ�� SNOW �±׸� ���� ���
            // ������ �����մϴ�.
            score--;
            Debug.Log("Score: " + score); // ������ �ֿܼ� ����ϰų� ���ϴ� ���� ����Ͻ� �� �ֽ��ϴ�.
            UpdateScoreText(); // ������ Text UI�� ������Ʈ�մϴ�.
        }

        if (collision.gameObject.CompareTag("GAMJA"))
        {
            Vector3 pushDirection = transform.position - collision.transform.position;
            pushDirection.Normalize();
            GetComponent<Rigidbody>().AddForce(pushDirection * pushForce, ForceMode.Impulse);

        }
    }
    private void UpdateScoreText()
    {
        // Text UI�� ������ ǥ���մϴ�.
        scoreText.text = "Score: " + score;
    }
}