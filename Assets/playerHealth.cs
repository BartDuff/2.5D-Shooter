using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float fullHealth;
    private float _currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = fullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
