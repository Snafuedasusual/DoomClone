using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Camera plrCam;
    public GameObject _impact;
    public int _munition = 20;
    public bool _w8 = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Shoot();
    }

    //This function is responsible for the player shooting.
    private void _Shoot()
    {
        //Checks if the player presses the designated key.
        if (Input.GetKeyDown(KeyCode.Space) && _munition > 0 && _w8 == true)
        {
            _w8 = false;
            //The weapon is a double barrel shotgun firing both barrels. It means that it shoots 16 pellets at the same time. Thus we use 'for loop' to simulate a shotgun firing 16 projectiles at the same time.
            for (int _sht = 0; _sht < 16; _sht++)
            {
                //This is responsible for firing a ray from the camera. It uses Vector3 (XYZ). The X parameters picks a random number (if the Value is 0 it points to left side of the screen, if its 1 then it points the right side) for the horizontal position.
                //The Y parameters picks a random number (if the Value is 0 it points to bottom side of the screen, if its 1 then it points the top side) for the vertical position.
                //0.5f is the middle of the screen.
                Ray _shotFired = plrCam.ViewportPointToRay(new Vector3(Random.Range(0.4f, 0.6f), Random.Range(0.4f, 0.6f), 0f));

                //RaycastHit does what it is named for with a variable name to store the value.
                RaycastHit _shotHit;

                //If it hits then play this part.
                if (Physics.Raycast(_shotFired, out _shotHit))
                {
                    Debug.Log("I hit " + _shotHit.transform.name);
                    Instantiate(_impact, _shotHit.point, transform.rotation);
                    
                }
                
                //If miss then play this one.
                else
                {
                    Debug.Log("Miss!");
                }
            }
            _munition -= 2;
            StartCoroutine(_Wait());
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _munition == 0 && _w8 == true)
        {
            Debug.Log("You're out!");
        }
    }

   private IEnumerator _Wait()
    {
        yield return new WaitForSecondsRealtime(0.75f);
        _w8 = true;
    }
}
