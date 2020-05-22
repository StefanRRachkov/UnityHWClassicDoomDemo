using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Firing : MonoBehaviour
{

    public RawImage head;
    public RawImage weapon;

    private Animator headAnimator;
    private Animator weaponAnimator;
    // Start is called before the first frame update
    void Start()
    {
        headAnimator = head.GetComponent<Animator>();
        weaponAnimator = weapon.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            headAnimator.SetTrigger("Fire");
            weaponAnimator.SetTrigger("Fire");
        }
    }
}