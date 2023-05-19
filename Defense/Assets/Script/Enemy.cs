using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int speed = 366;
    public Transform[] load;
    public int next = 2;
    private Vector3 Move;
    private List<Vector3> positionList = new List<Vector3>();
    // Start is called before the first frame update
    void Awake()
    {
        var Lo = GameObject.Find("load");
        load = Lo.GetComponentsInChildren<Transform>();
        foreach (Transform t in load)
        {

            positionList.Add(t.position);
        }
        var Direction = GetDirection(positionList[next -1], positionList[next]);
        var MoveSpeed = GetMoveSpeed(Direction, speed);
        Move = MoveSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (load.Length == next) { Debug.Log("hello"); return; }
        Moving();
    }
    
    private void Moving()
    {
        transform.Translate(Move);
        var myposition = GetPosition(gameObject.transform);
        var myendposition = positionList[next];
        if (isArrived(GetIntVector(myposition), GetIntVector(myendposition)))
        {
            if (next == load.Length) return;
            gameObject.transform.position = positionList[next];
            next += 1;
            var Direction = GetDirection(positionList[next - 1], positionList[next]);
            var MoveSpeed = GetMoveSpeed(Direction, speed);
            Move = MoveSpeed;
        }
    }

    private Vector3 GetPosition(Transform gameObject) => gameObject.position;

    private Vector3 GetDirection(Vector3 a, Vector3 b) => b - a;

    private Vector3 GetMoveSpeed(Vector3 v, int s) => new Vector3(v.x/s, v.y/s, v.z/s);

    private Vector3 GetTimeMulty(Vector3 v) => v * Time.deltaTime;

    private Vector3Int GetIntVector(Vector3 v) => new Vector3Int((int)v.x, (int)v.y, (int)v.z);

    private bool isArrived(Vector3Int a, Vector3Int b) => a == b;
}

