using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle logic for the player mesh - rotation
/// </summary>
public class PlayerMeshController : MonoBehaviour
{
    private Transform meshTransform = null;
    private Camera mainCamera = null;
    [SerializeField] private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //Get components
        meshTransform = GetComponent<Transform>();
        mainCamera = Camera.main;
    }

    /// <summary>
    /// Rotate the mesh so it faces the mouse cursor
    /// </summary>
    private void MeshRotateToMouse()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        MeshRotateToMouse();
    }
}
