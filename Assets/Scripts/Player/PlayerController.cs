using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle core player logic: movement & shooting
/// </summary>
public class PlayerController : MonoBehaviour
{
    #region Movement
    [Header("Movement Values")]
    [SerializeField] private float movementForce;

    private float movementLimiter = 0.7f;
    private Vector3 movementInput = Vector3.zero;

    private Rigidbody playerRigidbody = null;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Get components
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = new Vector3(Input.GetAxisRaw("Horizontal"),0 ,Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        //Check if diagonal movement
        if (movementInput.x != 0 && movementInput.z != 0)
        {
            movementInput *= movementLimiter;
        }

        //playerRigidbody.velocity = new Vector3(movementInput.x * movementForce, 0, movementInput.z * movementForce);
        playerRigidbody.velocity = movementInput * movementForce;
    }
}
