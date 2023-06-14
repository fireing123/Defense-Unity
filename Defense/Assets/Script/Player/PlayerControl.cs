using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 0.5f;
    public float jumpPow = 10f;
    private Rigidbody rb;
    public bool isJumping;

    public int camaraRotation = 3;
    private float mouseX = 0;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerRotation();
        Move();
        Jump(jumpPow);
    }

    void PlayerRotation()
    {
        
        mouseX += Input.GetAxis("Mouse X") * camaraRotation;//���콺 �¿�������� �Է¹޾Ƽ� ī�޶��� Y���� ȸ����Ų��
       
        transform.eulerAngles = new Vector3 (0, mouseX, 0);
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new(h, 0, v);
        transform.Translate(dir * speed);

    }

    public void Jump(float _jumpPower)
    {
        // �����̽��ٸ� ������(�Ǵ� ������ ������)
        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            // body�� ���� ���Ѵ�(AddForce)
            // AddForce(����, ���� ��� ���� ���ΰ�)
            rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            isJumping = true;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isJumping = false;
        }
    }
}
