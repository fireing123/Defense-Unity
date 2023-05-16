using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int speed = 366;
    public GameObject start;
    public GameObject end;

    private Vector3 Move;

    // Start is called before the first frame update
    void Start()
    {
        var stratposition = GetPosition(start);
        var endposition = GetPosition(end);
        var Direction = GetDirection(stratposition, endposition);
        var MoveSpeed = GetMoveSpeed(Direction, speed);
        Move = MoveSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Move);
        var myposition = GetPosition(gameObject);
        var myendposition = GetPosition(end);
        if (isArrived(GetIntVector(myposition), GetIntVector(myendposition))) Debug.Log("End!");
    }
    

    private Vector3 GetPosition(GameObject gameObject) => gameObject.transform.position;

    private Vector3 GetDirection(Vector3 a, Vector3 b) => b - a;

    private Vector3 GetMoveSpeed(Vector3 v, int s) => new Vector3(v.x/s, v.y/s, v.z/s);

    private Vector3 GetTimeMulty(Vector3 v) => v * Time.deltaTime;

    private Vector3Int GetIntVector(Vector3 v) => new Vector3Int((int)v.x, (int)v.y, (int)v.z);

    private bool isArrived(Vector3Int a, Vector3Int b) => a == b;
}
