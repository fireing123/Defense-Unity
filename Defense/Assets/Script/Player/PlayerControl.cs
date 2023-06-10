using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    float speed = 1f;
    private Rigidbody rb;
    public bool isjumping;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        (float X, float Z) = GetInput();
        (float MX,  float MZ) = MulDouble(speed ,X, Z);
        rb.velocity = new Vector3(MX,0,MZ);
        Jump();
    }

    public (float, float) GetInput()
    {
        float xinput = Input.GetAxis("Horizontal");
        float zinput = Input.GetAxis("Vertical");
        return (xinput, zinput);
    }

    void Jump()
    {
        if (Input.GetButton("Jump")) //���� Ű�� ������ ��
        {
            if (isjumping == false) //���� ������ ���� ��
            {
                rb.AddForce(Vector3.up * 55, ForceMode.Impulse); //�������� ���� �ش�.
                isjumping = true;
            }
            else return; //���� ���� ���� �������� �ʰ� �ٷ� return.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isjumping = false;
        }
    }

    public (float, float) MulDouble(float speed, float x, float z)
    {
        return (
            x * speed,
            z * speed
            );
    }
}
