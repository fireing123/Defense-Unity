using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public int account = 0;

    public TMP_Text goldUi;
    public float speed = 0.5f;
    public float jumpPow = 10f;

    private Rigidbody rb;
    public bool isJumping;

    public int camaraRotation = 3;
    private float mouseX = 0;
    // Start is called before the first frame update
    void Awake()
    {
        account = PlayerPrefs.GetInt("Account");
        ChangeGoldUI(account);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerRotation();
        Move();
        Jump(jumpPow);
    }

    public void ChangeGoldUI(int gold)
    {
        goldUi.text = "Gold : " + gold.ToString();
    }

    public int GetAccount()
    {
        return account;
    }

    public void SetAccount(int _account)
    {
        PlayerPrefs.SetInt("Account", _account);
        account = _account;
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
        if (collision.gameObject.layer == 3)
        {
            isJumping = false;
        }
    }
}
