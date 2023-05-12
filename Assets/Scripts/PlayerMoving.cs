using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private Transform miniBrush;

    private List<Vector2> routePoints = new();

    private bool Crash = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Crash && (other.CompareTag("Smash") || other.GetComponent<PlayerMoving>() != null))
        {
            Crash = true;
            Destroy(Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation),1f);
            gameController.Crashed();
        }
    }

    public void StartMoving(List<Vector2> points)
    {
        routePoints = points;
        StartCoroutine(MoveToGoal());
        gameController.StartCleanerSound();
    }

    private IEnumerator MoveToGoal()
    {
        var SpeedMultiply = speed * CalculateLineDistance();

        while (routePoints.Count > 0)
        {
            transform.right = new Vector3(routePoints[0].x, routePoints[0].y, 0) - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, routePoints[0], SpeedMultiply * Time.deltaTime);

            miniBrush.Rotate(new Vector3(0, 0, 15) * Time.timeScale);

            if (Vector3.Distance(transform.position, routePoints[0]) < 0.1f)
            {
                routePoints[0] = transform.position;
                routePoints.RemoveAt(0);
            }
            if (Crash)
                break;
            yield return new WaitForFixedUpdate();
        }
        gameController.GoalReached();
    }

    private float CalculateLineDistance()
    {
        float Distance = 0;
        for (int i = 1; i < routePoints.Count; i++)
        {
            Distance += (routePoints[i - 1] - routePoints[i]).magnitude;
        }
        return Distance;
    }


}
