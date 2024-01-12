using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardingandPickups : MonoBehaviour
{
    public SpriteRenderer _spr;
    public GameObject _player;
    public Shoot _munizion;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _spr = gameObject.GetComponent<SpriteRenderer>();
        _munizion = _player.GetComponent<Shoot>();
        _spr.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player.transform.position, -Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && transform.tag == "ammo")
        {
            _munizion._munition += 10;
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player") && transform.tag == "medkit")
        {
            Destroy(gameObject);
        }
    }
}
