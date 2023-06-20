using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;        // �̵� �ӵ�
    public Animator animator;           // �ִϸ����� ������Ʈ

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Ű �Է� ó��
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // �̵� ���� ���
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed;

        // �̵� ����
        rb.velocity = movement;

        // �̵� �ӵ��� ���� �ִϸ��̼� ���
        float speed = movement.magnitude;
        animator.SetFloat("Speed", speed);
    }
}
