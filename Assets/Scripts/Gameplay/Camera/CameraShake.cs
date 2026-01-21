
using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    [SerializeField] private CinemachineCamera virtualCamera;

    private CinemachineBasicMultiChannelPerlin noise;
    private float shakeTimer;

    void Awake()
    {
        Instance = this;
        noise = virtualCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(float intensity, float duration)
    {
        noise.AmplitudeGain = intensity;
        shakeTimer = duration;
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                noise.AmplitudeGain = 0f;
            }
        }
    }
}
