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
    public float jumpPow = 1f;

    private Rigidbody rb;
    public Transform X;

    public int camaraRotation = 3;
    private float mouseX = 0;
    private float mouseY = 0;   

    public GoldEvent onGoldChange;
    public SelectEvent onSelectChange;


    // Start is called before the first frame update
    void Awake()
    {
        TryGetComponent(out rb);
        onGoldChange.AddListener(ChangeGoldUI);
        onSelectChange.AddListener(SetSelect);

        SetAccount(account);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerRotation();
        Vector3 vector = Vector3.zero;
        vector += Move();
        vector += Jump(jumpPow);
        transform.Translate(vector);
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
        
        mouseX += Input.GetAxis("Mouse X") * camaraRotation; //마우스 좌우움직임을 입력받아서 카메라의 Y축을 회전시킨다
        mouseY += Input.GetAxis("Mouse Y") * camaraRotation;
        X.eulerAngles = new(mouseY, X.eulerAngles.y, X.eulerAngles.z);
        transform.eulerAngles = new(0, mouseX, 0);
    }

    Vector3 Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        return new(h, 0, v);
        

    }

    public Vector3 Jump(float _jumpPower)
    {
        // 스페이스바를 누르면(또는 누르고 있으면)
        if (Input.GetKey(KeyCode.Space))
        {
            return new(0, _jumpPower, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return new(0, -_jumpPower, 0);
        }
        return Vector3.zero;
    }
}
