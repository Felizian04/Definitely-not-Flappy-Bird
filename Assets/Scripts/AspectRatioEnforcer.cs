using UnityEngine;

[RequireComponent(typeof(Camera))]
public class AspectRatioEnforcer : MonoBehaviour
{
    [Header("Ziel-Seitenverhältnis")]
    public float targetAspectX = 16f;
    public float targetAspectY = 9f;

    private Camera cam;

    void Start()
    {
        PlayerPrefs.DeleteKey("Screenmanager Is Fullscreen mode");
        PlayerPrefs.DeleteKey("Screenmanager Resolution Width");
        PlayerPrefs.DeleteKey("Screenmanager Resolution Height");

        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);

        cam = GetComponent<Camera>();
        AdjustCamera();
    }
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        AdjustCamera();
#endif
    }

    void AdjustCamera()
    {
        float targetAspect = targetAspectX / targetAspectY;

        float windowAspect = (float)Screen.width / (float)Screen.height;

        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            Rect rect = cam.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            cam.rect = rect;
        }

        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = cam.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            cam.rect = rect;
        }
    }
}