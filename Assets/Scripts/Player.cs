using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10.0f;     // 움직이는 속도. public으로 설정하여 유니티 에디터에서 조정할 수 있습니다.
    public float lookSpeed = 2.0f;      // 마우스 시야 회전 속도
    public float lookXLimit = 90.0f;    // 시야 회전 각도 제한
    public float jumpForce = 5.0f;      // 점프 힘
    private Rigidbody rb;
    private bool isGrounded = false;
    private float rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;   // 마우스 커서 고정
    }

    // 이동 관련 함수를 짤 때는 FixedUpdate보다 Update가 더 효율적입니다.
    void Update()
    {
        // 플레이어 이동
        float horizontalMovement = Input.GetAxis("Horizontal");   // 가로축
        float verticalMovement = Input.GetAxis("Vertical");       // 세로축

        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        // 점프
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // 마우스 시야 회전
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y + mouseX, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GROUND"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GROUND"))
        {
            isGrounded = false;
        }
    }
}