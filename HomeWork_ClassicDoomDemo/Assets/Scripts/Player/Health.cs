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
        if (health > 0)
        {
            headAnimator.SetInteger("Health", health - amount);
            headAnimator.SetTrigger("Hit");
            health = Mathf.Max(health - amount, 0);
            
            OnDamageTaken?.Invoke(health);

            if (health <= 20)
            {
                mainCamera.GetComponent<PostProcess>().enabled = true;
            }
        }

        if (health <= 0)
        {
            // When you are dead you can't move or shoot
            
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<Firing>().enabled = false;
        }
    }
}
