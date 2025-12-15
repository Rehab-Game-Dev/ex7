using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light lightToControl; // Drag your light here in Inspector
    public Material onMaterial;  // Optional: material when light is ON
    public Material offMaterial; // Optional: material when light is OFF

    private bool isLightOn = true;
    private Renderer switchRenderer;

    void Start()
    {
        switchRenderer = GetComponent<Renderer>();

        // Start with light on
        if (lightToControl != null)
        {
            lightToControl.enabled = true;
        }
    }

    public void Toggle()
    {
        isLightOn = !isLightOn;

        if (lightToControl != null)
        {
            lightToControl.enabled = isLightOn;
        }

        // Optional: Change switch color
        if (onMaterial != null && offMaterial != null && switchRenderer != null)
        {
            switchRenderer.material = isLightOn ? onMaterial : offMaterial;
        }

        Debug.Log("Light is now: " + (isLightOn ? "ON" : "OFF"));
    }
}