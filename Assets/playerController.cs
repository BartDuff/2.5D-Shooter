using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //Movement variables
    public float runSpeed;
    public float walkSpeed;
    private Rigidbody _myRb;
    private Animator _myAnimator;
    private bool _facingRight;
    
    //For jumping
    private bool _grounded = false;
    private Collider[] _groundCollisions;
    private float _groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    private static readonly int Speed = Animator.StringToHash("speed");
    private static readonly int Sneaking = Animator.StringToHash("sneaking");
    private static readonly int Grounded = Animator.StringToHash("grounded");
    private static readonly int Shooting = Animator.StringToHash("shooting");

    // Start is called before the first frame update
    void Start()
    {
        _myRb = GetComponent<Rigidbody>();
        _myAnimator = GetComponent<Animator>();
        _facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (_grounded && Input.GetAxis("Jump") > 0)
        {
            _grounded = false;
            _myAnimator.SetBool(Grounded, _grounded);
            _myRb.AddForce(new Vector3(0, jumpHeight, 0));
        }
        _groundCollisions = Physics.OverlapSphere(groundCheck.position, _groundCheckRadius, groundLayer);
        _grounded = _groundCollisions.Length > 0;    
        _myAnimator.SetBool(Grounded, _grounded);
        float move = Input.GetAxis("Horizontal");
        _myAnimator.SetFloat(Speed, Mathf.Abs(move));
        float sneaking = Input.GetAxisRaw("Fire3");
        _myAnimator.SetFloat(Sneaking, sneaking);
        float firing = Input.GetAxisRaw("Fire1");
        _myAnimator.SetFloat(Shooting, firing);
        if ((sneaking > 0 || firing > 0) && _grounded)
        {
            _myRb.velocity = new Vector3(move * walkSpeed, _myRb.velocity.y, 0);
        } else {
            _myRb.velocity = new Vector3(move * runSpeed, _myRb.velocity.y, 0);
        }
        if (move > 0 && !_facingRight) Flip();
        else if (move < 0 && _facingRight) Flip();
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 scale = transform.localScale;
        scale.z *= -1;
        transform.localScale = scale;
    }

    public float GetFacing()
    {
        return _facingRight ? 1 : -1;
    }
}
