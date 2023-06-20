using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10.0f;     // �����̴� �ӵ�. public���� �����Ͽ� ����Ƽ �����Ϳ��� ������ �� �ֽ��ϴ�.
    public float lookSpeed = 2.0f;      // ���콺 �þ� ȸ�� �ӵ�
    public float lookXLimit = 90.0f;    // �þ� ȸ�� ���� ����
    public float jumpForce = 5.0f;      // ���� ��
    private Rigidbody rb;
    private bool isGrounded = false;
    private float rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;   // ���콺 Ŀ�� ����
    }

    // �̵� ���� �Լ��� © ���� FixedUpdate���� Update�� �� ȿ�����Դϴ�.
    void Update()
    {
        // �÷��̾� �̵�
        float horizontalMovement = Input.GetAxis("Horizontal");   // ������
        float verticalMovement = Input.GetAxis("Vertical");       // ������

        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        // ����
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // ���콺 �þ� ȸ��
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