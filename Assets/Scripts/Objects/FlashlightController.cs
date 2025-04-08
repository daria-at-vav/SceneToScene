using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] Light2D playerLight;
    [SerializeField] Image flashlightLit;
    [SerializeField] float offLightIntensity;
    [SerializeField] float onlightIntensity;
    [SerializeField] int offLightRadius;
    [SerializeField] int onlightRadius;

    bool flashlightOn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flashlightLit.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            ToggleFlashlight();
        }
    }

    private void ToggleFlashlight()
    {
        flashlightOn = !flashlightOn;
        flashlightLit.enabled = flashlightOn;
        if (flashlightOn)
        {
            playerLight.intensity = onlightIntensity;
            playerLight.pointLightOuterRadius = onlightRadius;
        }
        else
        {
            playerLight.intensity = offLightIntensity;
            playerLight.pointLightOuterRadius = offLightRadius;
        }
    }
}
