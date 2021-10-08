using UnityEngine;

public class UISafeArea : MonoBehaviour
{

    private ScreenOrientation currentDeviceOrientation;

    private void Awake() 
    {
        UpdateSafeArea();
        currentDeviceOrientation = Screen.orientation;
    }

    private void Update() 
    {
        if(Screen.orientation != currentDeviceOrientation)
        {
            currentDeviceOrientation = Screen.orientation;
        }
            UpdateSafeArea();
    }

    private void UpdateSafeArea()
    {
        var thisRecTransform = GetComponent<RectTransform>();

        var anchorMin = Screen.safeArea.position;
        var anchorMax = Screen.safeArea.position + Screen.safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;

        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        thisRecTransform.anchorMax = anchorMax;
        thisRecTransform.anchorMin = anchorMin;
    }

}
