using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class shootBullet : MonoBehaviour
{
    public float range = 10f;
    public float damage = 5f;

    private Ray _shootRay;
    private RaycastHit _shootHit;
    private int _shootableMask;
    private LineRenderer _gunLine;
    
    // Start is called before the first frame update
    void Awake()
    {
        _shootableMask = LayerMask.GetMask("Shootable");
        _gunLine = GetComponent<LineRenderer>();
        _shootRay.origin = transform.position;
        _shootRay.direction = transform.forward;
        _gunLine.SetPosition(0, transform.position);
        if (Physics.Raycast(_shootRay, out _shootHit, range, _shootableMask))
        {
            //Hit an enemy goes here
            _gunLine.SetPosition(1, _shootHit.point);
        }
        else
        {
            _gunLine.SetPosition(1, _shootRay.origin + _shootRay.direction * range);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
