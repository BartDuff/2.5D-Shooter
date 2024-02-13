using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour
{
    public float timeBetweenBullets = 0.15f;

    public GameObject projectile;

    private float _nextBullet;
    // Start is called before the first frame update
    void Awake()
    {
        _nextBullet = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        playerController myplayer = transform.root.GetComponent<playerController>();
        if (Input.GetAxisRaw("Fire1") > 0 && _nextBullet < Time.time)
        {
            _nextBullet = Time.time + timeBetweenBullets;
            Vector3 rot = myplayer.GetFacing() == -1f ? new Vector3(0, -90, 0) : new Vector3(0, 90, 0);
            Instantiate(projectile, transform.position, Quaternion.Euler(rot));
        }
    }
}
