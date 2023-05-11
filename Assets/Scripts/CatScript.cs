using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    private Vector3 startPosition;

    private Vector3 patrolPointToGo;

    [SerializeField]
    private List<Vector2> pointsToPatrol = new();

    [SerializeField]
    private float speedMultiply;

    private int indexPoint = 0;

    void Start()
    {
        startPosition = transform.position;
        ChangePatrolPoint();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, patrolPointToGo) < 0.1f)
            ChangePatrolPoint();
        transform.position = Vector2.MoveTowards(transform.position, patrolPointToGo, speedMultiply * Time.deltaTime);
    }

    private void ChangePatrolPoint()
    {
        if (pointsToPatrol.Count > indexPoint)
        {
            patrolPointToGo = pointsToPatrol[indexPoint];
            transform.right = patrolPointToGo - transform.position;
            indexPoint++;
        }
        else
        {
            patrolPointToGo = startPosition;
            transform.right = startPosition - transform.position;
            indexPoint = 0;
        }
    }
}
