using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    float mouseSensitivity = 100f;

    [SerializeField]
    Transform mainCameraTransform;
    [SerializeField]
    CharacterController controller;
    [SerializeField]
    GameObject PreviewCamera;
    [SerializeField]
    public float TransitionSpeed ;
    [SerializeField]

    Vector3 moveInput; 
    Vector2 lookInput;
    float xRotation = 0f; // Track camera's vertical rotation



    public IEnumerator TerminateToComputer()
    {
        // hima sig chi drac vor konkret jamanak heto katarvi
        // interpolation function t * (2f - t)
        var oldxRotation = xRotation;
        Quaternion oldRotation = transform.rotation;
        Vector3 oldPosition = transform.position;
        for (float t = 0; t <1; t+=TransitionSpeed * Time.deltaTime) {
            xRotation = Mathf.Lerp(oldxRotation, 0, t * (2f - t));
            transform.position = Vector3.Lerp(oldPosition, PreviewCamera.transform.position, t * (2f - t));
            transform.rotation = Quaternion.Lerp(oldRotation,Quaternion.identity, t * (2f - t));
            yield return null;
        }


    }
    void Update()
    {
        HandleLook();
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Transform movement direction relative to player's facing direction
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.z;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    private void HandleLook()
    {
        // Horizontal rotation (Y-axis) - rotate the player body
        transform.Rotate(Vector3.up * lookInput.x * mouseSensitivity * Time.deltaTime);

        // Vertical rotation (X-axis) - rotate the camera with clamping
        xRotation -= lookInput.y * mouseSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        mainCameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    public void OnMove(InputValue moveInput)
    {
        Vector2 input = moveInput.Get<Vector2>();
        this.moveInput = new Vector3(input.x, 0f, input.y);
    }

    public void OnLook(InputValue lookInput)
    {
        this.lookInput = lookInput.Get<Vector2>();
    }

}