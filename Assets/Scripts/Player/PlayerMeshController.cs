using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle logic for the player mesh - rotation
/// </summary>
public class PlayerMeshController : MonoBehaviour
{
    private Transform meshTransform = null;
    [SerializeField] private Camera mainCamera = null;

    // Start is called before the first frame update
    void Start()
    {
        //Get components
        meshTransform = GetComponent<Transform>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        MeshRotateToMouse();
    }

    /// <summary>
    /// Rotate the mesh so it faces the mouse cursor
    /// </summary>
    private void MeshRotateToMouse()
    {
       
    }
}
