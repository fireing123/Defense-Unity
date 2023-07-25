using EnemyEntity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventsManger : MonoBehaviour
{
    public static UnityEvent<int> GoldEvent = new();
    public static UnityEvent<string> SelectEvent = new();
    public static UnityEvent<int> WaveEndEvent = new();
    public static UnityEvent<LivingEnemy> EnemyDeathEvent = new();
    public static UnityEvent FailEvent = new();
    public static UnityEvent SuccessEvent = new();
}
