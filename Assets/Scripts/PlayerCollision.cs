using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{

    private int score = 0; // 점수 변수
    public Text scoreText; // 점수를 표시할 Text UI

    private float pushForce = 10f; // 밀려나는 힘의 세기

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WALL"))
        {
            // 충돌한 오브젝트가 WALL 태그를 가진 경우
            // 충돌 방향과 반대 방향으로 힘을 가해 Player 오브젝트를 밀어냅니다.
            Vector3 pushDirection = collision.transform.position - transform.position;
            pushDirection.Normalize();
            GetComponent<Rigidbody>().AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("SNOW"))
        {
            // 충돌한 오브젝트가 SNOW 태그를 가진 경우
            // 점수를 차감합니다.
            score--;
            Debug.Log("Score: " + score); // 점수를 콘솔에 출력하거나 원하는 곳에 사용하실 수 있습니다.
            UpdateScoreText(); // 점수를 Text UI에 업데이트합니다.
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
        // Text UI에 점수를 표시합니다.
        scoreText.text = "Score: " + score;
    }
}