using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{

    public int account = 0;

    public TMP_Text goldUi;
    public TMP_Text Select;
    
    public float speed = 0.5f;
    public float jumpPow = 10f;

    private Rigidbody rb;
    public bool isJumping;

    public int camaraRotation = 3;
    private float mouseX = 0;

    public GoldEvent onGoldChange;
    public SelectEvent onSelectChange;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        onGoldChange.AddListener(ChangeGoldUI);
        onSelectChange.AddListener(SetSelect);

        SetAccount(account);
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
        account = _account;
        onGoldChange.Invoke(account);
    }

    public void PlusGold(int gold)
    {
        account += gold;
        onGoldChange.Invoke(account);
    }
    public void SubGold(int gold)
    {
        account -= gold;
        onGoldChange.Invoke(account);
    }

    public void SetSelect(string selectName)
    {
        Select.text = "Select : " + selectName;
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
        if (collision.gameObject.layer.Equals(3))
        {
            isJumping = false;
        }
    }
}
