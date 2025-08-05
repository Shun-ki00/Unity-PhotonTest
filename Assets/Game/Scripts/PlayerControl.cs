using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("移動速度"), SerializeField]
    private float _moveSpeed;

    [Header("回転速度"), SerializeField]
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

        // 上キーを押したとき
        if (Input.GetKey("right"))
        {
            this.transform.Rotate(0.0f, _rotateSpeed * Time.deltaTime, 0.0f);
        }
        // 下キーを押したとき
        else if (Input.GetKey("left"))
        {
            this.transform.Rotate(0.0f, -_rotateSpeed * Time.deltaTime, 0.0f);
        }


        // 上キーを押したとき
        if (Input.GetKey("up"))
        {
            velocity += transform.forward * _moveSpeed * Time.deltaTime;
        }
        // 下キーを押したとき
        else if (Input.GetKey("down"))
        {
            velocity -= transform.forward * _moveSpeed * Time.deltaTime;
        }

        // 速度を設定する
        rb.linearVelocity = new Vector3( velocity.x ,rb.linearVelocity.y , velocity.z);
    }
}
