using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        animator.SetInteger("Health", health - amount);
        animator.SetTrigger("Hit");

        health -= amount;
    }
}
