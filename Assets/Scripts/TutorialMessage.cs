using UnityEngine;

public class TutorialMessage : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) gameObject.SetActive(false);
    }
}
