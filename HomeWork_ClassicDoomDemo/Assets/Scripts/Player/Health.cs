using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private int health = 100;
    [SerializeField] private RawImage head = null;
    
    private Animator headAnimator;
    
    public Action<int> OnDamageTaken;
    
    void Start()
    {
        headAnimator = head.GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        headAnimator.SetInteger("Health", health - amount);
        headAnimator.SetTrigger("Hit");
        health -= amount;
        OnDamageTaken?.Invoke(health);

        if (health <= 20)
        {
            mainCamera.GetComponent<PostProcess>().enabled = true;
        }
    }
}
