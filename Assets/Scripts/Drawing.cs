using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    [SerializeField]
    private GameObject linePrefab;

    [SerializeField]
    private Transform Player_1;

    [SerializeField]
    private Transform Player_2;

    [SerializeField]
    private Transform Goal_1;

    [SerializeField]
    private Transform Goal_2;

    [SerializeField]
    [Header("Distance from Cursor to Player")]
    private float minDistanceToObject = 0.2f;

    [SerializeField]
    [Header("Smoothness of Line")]
    private float minDistance = 0.1f;

    [SerializeField]
    private Color Player1Color;

    [SerializeField]
    private Color Player2Color;

    private Vector2 previousPoint;
    private GameObject currentInstance;
    private LineRenderer currentLine;

    private bool isDrawing = false;
    private bool Missed;
    private bool playersMoving = false;
    private List<Vector2> RouteToGoal = new();

    private GameObject PaintedLine_1;
    private GameObject PaintedLine_2;

    private List<Vector2> route_1 = new();
    private List<Vector2> route_2 = new();

    void Update()
    {
        if (!playersMoving)
        {
            if (Input.GetMouseButtonDown(0))
            {

                StartDrawing();
                Missed = !HitPlayer();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (!Missed && HitGoal())
                {
                    TryInitializePlayerMoving();
                    EndDrawing();
                }
                else
                    MissedPlayerOrGoal();
            }
            else if (isDrawing!)
            {
                ContinueDrawing();
            }
        }
        
    }
    private void StartDrawing()
    {
        isDrawing = true;
        previousPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentInstance = Instantiate(linePrefab, transform);
        currentLine = currentInstance.GetComponent<LineRenderer>();
        currentLine.positionCount = 1;
        currentLine.SetPosition(0, previousPoint);
        RouteToGoal.Add(previousPoint);
    }

    private void ContinueDrawing()
    {
        Vector2 currentPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(currentPoint, previousPoint);

        if (distance > minDistance)
        {
            currentLine.positionCount++;
            currentLine.SetPosition(currentLine.positionCount - 1, currentPoint);
            previousPoint = currentPoint;
            RouteToGoal.Add(previousPoint);
        }
    }

    private void EndDrawing()
    {
        isDrawing = false;
        currentLine = null;
        RouteToGoal.Clear();
    }

    private bool HitPlayer()
    {
        if(Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), Player_1.position) < minDistanceToObject)
        {
            route_1.Clear();
            return ConfirmLine(PaintedLine_1, Player1Color);
        }
        else if (Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), Player_2.position) < minDistanceToObject)
        {
            route_2.Clear();
            return ConfirmLine(PaintedLine_2, Player2Color);
        }
        else
        {
            return false;
        }
    }

    private bool HitGoal()
    {
        if (PlayerMatchesGoal(Goal_1, Player1Color))
        {
            route_1.AddRange(RouteToGoal);
            PaintedLine_1 = currentInstance;
            return true;
        }
        else if (PlayerMatchesGoal(Goal_2, Player2Color))
        {
            route_2.AddRange(RouteToGoal);
            PaintedLine_2 = currentInstance;
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool ConfirmLine(GameObject lineToSave, Color color)
    {
        Destroy(lineToSave);
        currentInstance.GetComponent<Renderer>().material.color = color;
        return true;
    }

    private bool PlayerMatchesGoal(Transform lineToMatch, Color color)
    {
        return Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), lineToMatch.position) < minDistanceToObject && currentInstance.GetComponent<Renderer>().material.color == color;
    }

    private void MissedPlayerOrGoal()
    {
        Destroy(currentInstance, 0.1f);
        isDrawing = false;
        currentLine = null;
        RouteToGoal.Clear();
        Missed = false;
    }
    private void TryInitializePlayerMoving()
    {
        if(route_1.Count>0 && route_2.Count > 0)
        {
            playersMoving = true;
            Player_1.GetComponent<PlayerMoving>().StartMoving(route_1);
            Player_2.GetComponent<PlayerMoving>().StartMoving(route_2);
        }
    }
}
