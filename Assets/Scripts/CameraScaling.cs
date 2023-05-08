using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaling : MonoBehaviour
{
    [SerializeField]
    private GameObject BackGround;

    [SerializeField]
    private Vector2 colorPosition;

    private Camera mainCamera;
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        ChangeBackgroundColor();
        ScalingCamera();
    }

    private void ChangeBackgroundColor()
    {
        mainCamera.backgroundColor = BackGround.GetComponent<SpriteRenderer>().color / 2.6f;
    }

    private void ScalingCamera()
    {
        float targetAspect = 16f / 9f; // The desired aspect ratio
        float targetHeight = 5.7f; // The desired vertical size of the camera's view
        float currentAspect = Screen.width * 1.0f / Screen.height;
        float backgroundWidth = BackGround.GetComponent<Renderer>().bounds.size.x;
        float backgroundHeight = BackGround.GetComponent<Renderer>().bounds.size.y;

        float targetWidth = targetHeight * targetAspect;
        float backgroundRatio = backgroundWidth / backgroundHeight;

        if (currentAspect > targetAspect)
        {
            float viewWidth = targetHeight * currentAspect;
            float scaleFactor = backgroundWidth / viewWidth;
            mainCamera.orthographicSize = targetHeight / 2f / scaleFactor;
        }
        else
        {
            float viewHeight = targetWidth / currentAspect;
            float scaleFactor = backgroundHeight / viewHeight;
            mainCamera.orthographicSize = (targetWidth / currentAspect) / 2f / scaleFactor;
        }

    }
}



