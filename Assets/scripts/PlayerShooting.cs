using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float shootRange = 200f;
    public float shotDisplayTime = 0.5f;
    public Transform muzzlePoint;

    private Camera playerCamera;
    private LineRenderer lineRenderer;

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();

        if (muzzlePoint == null)
        {
            muzzlePoint = playerCamera.transform;
        }

        lineRenderer = gameObject.AddComponent<LineRenderer>();

        // MUCH THINNER LINE
        lineRenderer.startWidth = 0.05f;  // Changed from 0.3 to 0.05
        lineRenderer.endWidth = 0.05f;    // Changed from 0.3 to 0.05
        lineRenderer.positionCount = 2;

        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = new Color(0, 1, 1, 1); // Bright cyan
        lineRenderer.endColor = new Color(0, 1, 1, 1);

        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;

        lineRenderer.sortingOrder = 100;
        lineRenderer.numCornerVertices = 2;
        lineRenderer.numCapVertices = 2;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("BANG! Shooting...");

        // Ray from center of screen (where crosshair is)
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        // Start point slightly in front of camera (visible)
        Vector3 shootOrigin = ray.origin + ray.direction * 0.5f;  // 0.5 units in front
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit, shootRange))
        {
            Debug.Log("Hit: " + hit.collider.gameObject.name);
            targetPoint = hit.point;

            NPCHealth npcHealth = hit.collider.GetComponent<NPCHealth>();
            if (npcHealth != null)
            {
                npcHealth.TakeDamage();
            }
        }
        else
        {
            targetPoint = ray.origin + ray.direction * shootRange;
        }

        // Draw line from the visible start point to target
        StartCoroutine(ShowShot(shootOrigin, targetPoint));
    }

    System.Collections.IEnumerator ShowShot(Vector3 start, Vector3 end)
    {
        lineRenderer.enabled = true;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);

        // Force update
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(shotDisplayTime);

        lineRenderer.enabled = false;
    }
}