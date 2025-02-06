using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jetpack : MonoBehaviour
{

    public enum Direction
    {
        Left, Right
    }


    public float Energy { get; set; }
    
    private Rigidbody2D rb;
    [SerializeField] private float _maxEnergy;
    [SerializeField] private float _energyFlyingRatio;
    [SerializeField] private float _energyRegenerationRation;
    [SerializeField] private float _horizontalForce;
    [SerializeField] private float _flyForce;
    [SerializeField] private GameObject jetpacked;
    [SerializeField] private Slider energyShowCase;
    
    public bool _flying = false;
    


    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
        Energy = _maxEnergy;
    }

    void FixedUpdate()
    {
        energyShowCase.value = Energy;
        if (_flying)
        {
            doFly();
        }
        
    }



    void Update()
    {
        if (_flying == true)
        {
            jetpacked.SetActive(true);
        }
        else
        {
            jetpacked.SetActive(false);
        }

    }

    public void flyUp()
    {
        if (Energy >0)
        _flying = true;
    }

    public void stopFlying()
    {
        _flying = false;
    }

    public void regenerate()
    {
        if (Energy < _maxEnergy)
        {
            Energy += _energyRegenerationRation;
        }

    }

    public void flyHorizontal(Direction flyDirection)
    {

        if (!_flying) 
            return;
        if (flyDirection == Direction.Left)
        {
            rb.AddForce(Vector2.left * _horizontalForce);
        }
        else
        {
            rb.AddForce(Vector2.right * _horizontalForce);
        }
    }

    private void doFly()
    {
        if (Energy > 0)
        {
            rb.AddForce(Vector2.up * _flyForce);
            Energy -= _energyFlyingRatio;
        }
        else
        {
            _flying = false;
        }
            
     
    }

    
}
