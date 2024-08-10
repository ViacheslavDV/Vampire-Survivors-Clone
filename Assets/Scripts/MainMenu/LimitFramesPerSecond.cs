using UnityEngine;

public class LimitFramesPerSecond : MonoBehaviour
{
    public FPSLimits fpsLimit = FPSLimits.FPS60;
    public enum FPSLimits
    {
        FPS30 = 30,
        FPS60 = 60,
        FPS120 = 120,
        FPS240 = 240,
        UNLIMITED = -1
    }

    private void Awake()
    {
        Application.targetFrameRate = (int)fpsLimit;
    }

    public void SetFPS(int fpsLimit)
    {
        Application.targetFrameRate = fpsLimit;
    }
}
