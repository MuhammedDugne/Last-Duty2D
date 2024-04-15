using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeCamera : MonoBehaviour
{
    private CinemachineVirtualCamera cam;
    private CinemachineBasicMultiChannelPerlin noise;
    private bool isShaking = false;
    // Start is called before the first frame update
    void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void StartShakeCoroutine(float duration, float amplitude)
    {
        StartCoroutine(ShakeCoroutine(duration, amplitude));
    }

    private IEnumerator ShakeCoroutine(float duration, float amplitude)
    {
        isShaking = true;
        float elapsed = 0f; // Başlangıçta geçen süre sıfır
        while (elapsed < duration)
        {
            float shakeAmplitude = Mathf.Lerp(amplitude, 0f, elapsed / duration);
            noise.m_AmplitudeGain = shakeAmplitude;
            elapsed += Time.deltaTime; // Geçen süreyi güncelle
            yield return null;
        }
        noise.m_AmplitudeGain = 0f;
        isShaking = false;
    }

    public bool getisShaking()
    {
        return isShaking;
    }
}
