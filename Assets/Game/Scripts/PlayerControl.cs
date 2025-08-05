using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("�ړ����x"), SerializeField]
    private float _moveSpeed;

    [Header("��]���x"), SerializeField]
    private float _rotateSpeed;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = Vector3.zero;

        // ��L�[���������Ƃ�
        if (Input.GetKey("right"))
        {
            this.transform.Rotate(0.0f, _rotateSpeed * Time.deltaTime, 0.0f);
        }
        // ���L�[���������Ƃ�
        else if (Input.GetKey("left"))
        {
            this.transform.Rotate(0.0f, -_rotateSpeed * Time.deltaTime, 0.0f);
        }


        // ��L�[���������Ƃ�
        if (Input.GetKey("up"))
        {
            velocity += transform.forward * _moveSpeed * Time.deltaTime;
        }
        // ���L�[���������Ƃ�
        else if (Input.GetKey("down"))
        {
            velocity -= transform.forward * _moveSpeed * Time.deltaTime;
        }

        // ���x��ݒ肷��
        rb.linearVelocity = new Vector3( velocity.x ,rb.linearVelocity.y , velocity.z);
    }
}
