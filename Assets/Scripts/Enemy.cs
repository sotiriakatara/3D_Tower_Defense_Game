using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy_Movement))]
public class Enemy : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy_Movement enemy;

    private void Start()
    {

        enemy = GetComponent<Enemy_Movement>();
        target = Waypoint.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;

    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoint.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];


    // We subtract our position from the target position to create a
    // Vector that points from our position to the target position
    // If we reverse the order, our rotation would be 180 degrees off.
    Vector3 lookVector = target.position - transform.position;
    Quaternion rotation = Quaternion.LookRotation(lookVector);
    transform.rotation = rotation;
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
