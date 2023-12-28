using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera MainCamera;

    public float mousSens;

    private

    float RotationY;
    float RotationZ;

    public Rigidbody2D _rb2;

    public float moveSpeed = 5f;
    private Vector2 moveInp;
    private Vector2 mouseInp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        MouseLook();
        MovementControl();
    }

    private void Movement()
    {
        moveInp = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHoriz = transform.up * -moveInp.x;
        Vector3 moveVert = transform.right * moveInp.y;


        _rb2.velocity = (moveHoriz + moveVert) * moveSpeed;

      
    }

    private void MovementControl()
    {
        Vector2 flatVel = new Vector2 (_rb2.velocity.x,  _rb2.velocity.y);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector2 limVel = flatVel.normalized * moveSpeed;
            _rb2.velocity = new Vector2(limVel.x, limVel.y);
        }
    }

    private void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousSens;
        float mouseY = Input.GetAxis("Mouse Y") * mousSens;

        mouseY = Mathf.Clamp(mouseY, -90f, 90f);
        mouseInp = new Vector2 (mouseX, mouseY);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInp.x);

        MainCamera.transform.localRotation = Quaternion.Euler(MainCamera.transform.localRotation.eulerAngles + new Vector3(0f, mouseInp.y, 0f));

        MainCamera.transform.localRotation = Quaternion.Euler(MainCamera.transform.localRotation.eulerAngles.x, Mathf.Clamp(MainCamera.transform.localRotation.eulerAngles.y, 5f, 175f), MainCamera.transform.localRotation.eulerAngles.z);
    }
}
