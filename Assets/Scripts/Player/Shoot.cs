using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Camera plrCam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Shoot();
    }

    private void _Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int _sht = 0; _sht < 16; _sht++)
            {
                Ray _shotFired = plrCam.ViewportPointToRay(new Vector3(Random.Range(0.2f, 0.8f), Random.Range(0.2f, 0.8f), 0f));
                RaycastHit _shotHit;
                if (Physics.Raycast(_shotFired, out _shotHit))
                {
                    Debug.Log("I hit " + _shotHit.transform.name);
                }
                else
                {
                    Debug.Log("Miss!");
                }
            }
        }
    }
}
