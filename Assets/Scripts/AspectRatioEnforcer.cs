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
    }
    }