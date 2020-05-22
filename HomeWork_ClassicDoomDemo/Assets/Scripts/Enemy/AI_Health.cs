using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private Animator animator;

    //public Action<int> OnDamageTaken;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        animator.SetInteger("Health", health - amount);

        //OnDamageTaken?.Invoke(health - amount);
        
        health -= amount;
        
        Debug.Log(health);
    }
}
