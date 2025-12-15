using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float interactionDistance = 100f;

    private CharacterController controller;
    private Camera playerCamera;
    private float verticalRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();

        Debug.Log("Camera found: " + (playerCamera != null));

        // Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movement
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down arrows

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Apply gravity
        controller.Move(Vector3.down * 9.81f * Time.deltaTime);

        // Mouse look - horizontal (rotate player body)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);

        // Mouse look - vertical (rotate camera up/down)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Limit looking up/down
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Interaction with objects
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }

        // Unlock cursor with Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void TryInteract()
    {
        Debug.Log("=== INTERACTION ATTEMPT ===");
        Debug.Log("Camera: " + playerCamera.name);
        Debug.Log("Camera position: " + playerCamera.transform.position);
        Debug.Log("Camera forward: " + playerCamera.transform.forward);

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Debug.Log("Ray origin: " + ray.origin);
        Debug.Log("Ray direction: " + ray.direction);

        RaycastHit hit;

        bool didHit = Physics.Raycast(ray, out hit, interactionDistance);
        Debug.Log("Raycast hit anything: " + didHit);
        Debug.Log("Interaction distance: " + interactionDistance);

        if (didHit)
        {
            Debug.Log("Hit something: " + hit.collider.gameObject.name);
            Debug.Log("Hit distance: " + hit.distance);

            LightSwitch lightSwitch = hit.collider.GetComponent<LightSwitch>();
            if (lightSwitch != null)
            {
                Debug.Log("Found LightSwitch component!");
                lightSwitch.Toggle();
            }
            else
            {
                Debug.Log("No LightSwitch component on " + hit.collider.gameObject.name);
            }
        }
        else
        {
            Debug.Log("Raycast hit nothing within distance: " + interactionDistance);
        }
    }
}