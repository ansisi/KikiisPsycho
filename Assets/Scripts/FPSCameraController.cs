using UnityEngine;

public class FPSCameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;    // 마우스 감도
    public Transform playerBody;             // 플레이어 오브젝트의 Transform 컴포넌트
    public float moveSpeed = 5f;             // 좌우로 움직일 때의 이동 속도

    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   // 마우스 커서 고정
    }

    private void Update()
    {
        // 마우스 입력 처리
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 카메라 회전
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);   // 카메라 각도 제한
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 플레이어 회전
        playerBody.Rotate(Vector3.up * mouseX);

        // 좌우 이동
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        playerBody.Translate(Vector3.right * horizontalMovement, Space.Self);
    }
}