using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveLoop : MonoBehaviour
{
    public GameObject[] waypoints;

    //private bool isIncrementing = true;
    private int waypointIndex;

    private void OnEnable()
    {
        PlayerMove.PlayerMoved += MoveEnemy;
    }

    private void OnDisable()
    {
        PlayerMove.PlayerMoved -= MoveEnemy;
    }

    private void Start()
    {
        waypointIndex = 0;
    }

    void MoveEnemy()
    {
        float distanceX = transform.position.x - waypoints[waypointIndex].transform.position.x;
        float distanceY = transform.position.y - waypoints[waypointIndex].transform.position.y;

        if (Mathf.Abs(distanceX) >= 0.05f || Mathf.Abs(distanceY) >= 0.05f)
        {
            MoveToWaypoint();
        }
        else
        {
            waypointIndex++;
            MoveToWaypoint();

            if (waypointIndex >= waypoints.Length - 1)
                waypointIndex = 0;
        }
    }

    void MoveToWaypoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, 1);
    }
}
