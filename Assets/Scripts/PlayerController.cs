using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;        // 이동 속도
    public Animator animator;           // 애니메이터 컴포넌트

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 키 입력 처리
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // 이동 벡터 계산
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed;

        // 이동 적용
        rb.velocity = movement;

        // 이동 속도에 따라 애니메이션 재생
        float speed = movement.magnitude;
        animator.SetFloat("Speed", speed);
    }
}
