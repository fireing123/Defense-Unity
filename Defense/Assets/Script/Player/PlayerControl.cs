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
        
        mouseX += Input.GetAxis("Mouse X") * camaraRotation;//마우스 좌우움직임을 입력받아서 카메라의 Y축을 회전시킨다
       
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
        // 스페이스바를 누르면(또는 누르고 있으면)
        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            // body에 힘을 가한다(AddForce)
            // AddForce(방향, 힘을 어떻게 가할 것인가)
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
