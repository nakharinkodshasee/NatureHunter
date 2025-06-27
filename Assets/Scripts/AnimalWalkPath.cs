using System;
using UnityEngine;

public class AnimalWalkPath : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float moveSpeed;
    private int wayPointsIndex = 0;
    void Start()
    {
        transform.position = wayPoints[0].transform.position;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (wayPointsIndex < wayPoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[wayPointsIndex].transform.position, moveSpeed * Time.deltaTime);
            if (transform.position == wayPoints[wayPointsIndex].transform.position)
            {
                wayPointsIndex++;
            }
        }
        else
        {
            Array.Reverse(wayPoints);
            wayPointsIndex = 0;
        }
    }
}
