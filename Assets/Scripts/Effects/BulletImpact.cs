using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Impact : MonoBehaviour
{
    public float time;
    public SpriteRenderer _spr;
    public GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _spr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player.transform.position, -Vector3.forward);
        Destroy(gameObject, time);
    }
}
