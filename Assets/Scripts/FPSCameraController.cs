using UnityEngine;

public class FPSCameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;    // ���콺 ����
    public Transform playerBody;             // �÷��̾� ������Ʈ�� Transform ������Ʈ
    public float moveSpeed = 5f;             // �¿�� ������ ���� �̵� �ӵ�

    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   // ���콺 Ŀ�� ����
    }

    private void Update()
    {
        // ���콺 �Է� ó��
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // ī�޶� ȸ��
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);   // ī�޶� ���� ����
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // �÷��̾� ȸ��
        playerBody.Rotate(Vector3.up * mouseX);

        // �¿� �̵�
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        playerBody.Translate(Vector3.right * horizontalMovement, Space.Self);
    }
}