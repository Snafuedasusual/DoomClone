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

        // Locks the cursor
        Cursor.lockState = CursorLockMode.Locked;
        // Confines the cursor
        Cursor.lockState = CursorLockMode.Confined;
    }

    //This function is responible for player movement.
    private void Movement()
    {
        //This detects keyboard input for player movement in Vector2D (because we are in 2D).
        moveInp = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //MoveHoriz moves left and right and is relative to the camera front view, that is the right side of the player. moveInp is in minus because default is opposite of what we want.
        Vector3 moveHoriz = transform.up * -moveInp.x;

        //MoveVert moves front and back and is relative to the camera front view, that is the right side of the player.
        Vector3 moveVert = transform.right * moveInp.y;

        //Applies velocity to rigidbody 2D so the player moves.
        _rb2.velocity = (moveHoriz + moveVert) * moveSpeed;

      
    }

    //This function is responible for player movement control because they can go much faster than the set movement speed.
    private void MovementControl()
    {
        //Detects the player movement vector. Vector 2 because we are in 2D.
        Vector2 flatVel = new Vector2 (_rb2.velocity.x,  _rb2.velocity.y);

        //This 'if' statement limits player speed.
        if (flatVel.magnitude > moveSpeed)
        {
            //A new vector2 is made that will be used as the new player speed.
            Vector2 limVel = flatVel.normalized * moveSpeed;
            _rb2.velocity = new Vector2(limVel.x, limVel.y);
        }
        //Vectors converted into magnitude will turn into floats/integers. ex: new Vector2 (#, #) turns into float/int #.###/####
    }

    //This function is responible for player camera movement that is controlled by the mouse.
    private void MouseLook()
    {
        //Defines mouse input for X (Horizontal) movement and Y (Vertical) movement and is multiplied with mouse sensitivity so they move the camera.
        float mouseX = Input.GetAxis("Mouse X") * mousSens;
        float mouseY = Input.GetAxis("Mouse Y") * mousSens;

        //This block tries to limit the Vertical camera movement so the camera doesn't go 360 degrees vertically. This code doesn't solve it but the last line of the function code will.
        //mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        //Detects mouse input in Vector2 (Z axis don't exist in FPS camera rotation.)
        //mouseInp = new Vector2 (mouseX, mouseY);

        //Rotates player when horizontal mouse movement is detected. In Z axis because in 2D, Z axis rotates the player the correct way.
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseX);

        //Rotates player when vertical mouse movement is detected AND limits the rotation angles. We use localRotation because if we use Rotation then it wont result with the movement we want.
        float angleY = Mathf.Clamp(MainCamera.transform.localEulerAngles.y + mouseY, 0f, 180f);

        MainCamera.transform.localEulerAngles = new Vector3 (MainCamera.transform.localEulerAngles.x, angleY, MainCamera.transform.localEulerAngles.z);

        //XX Rotates camera when vertical mouse movement is detected. We use localRotation because if we use Rotation then it wont result with the movement we want.
        //MainCamera.transform.localRotation = Quaternion.Euler(MainCamera.transform.localRotation.eulerAngles + new Vector3(0f, mouseY, 0f));XX

        //XX This block tries to limit the vertical camera movement and it works. Uses Mathf.Clamp to limit the movement.
        //MainCamera.transform.localRotation = Quaternion.Euler(MainCamera.transform.localRotation.eulerAngles.x, Mathf.Clamp(MainCamera.transform.localRotation.eulerAngles.y, 10f, 170f), MainCamera.transform.localRotation.eulerAngles.z); XX
        
        //Note 31/12/2023 THIS CODE ABOVE IS DOES NOT WORK AS INTENDED. It limits, sure, but eulerangles accept fixed values meanwhile this code does not (i think??). Use the code above instead it gives a fixed value to the Mathf.Clamp.
    }
}
