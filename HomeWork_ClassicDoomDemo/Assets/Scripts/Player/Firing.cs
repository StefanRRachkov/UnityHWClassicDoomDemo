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

    [SerializeField] private int ammo = 100;
    [SerializeField] private float range = 10f;
    [SerializeField] private Camera mainCamera = null;
    
    public Action<int> Shoot;
    // Start is called before the first frame update
    void Start()
    {
        headAnimator = head.GetComponent<Animator>();
        weaponAnimator = weapon.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            RaycastHit hit;
            
            if (Physics.Raycast(transform.position,
                mainCamera.transform.forward,
                out hit,
                range))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    hit.transform.GetComponent<Animator>().SetTrigger("Hit");
                    
                }
                Debug.Log(hit.transform.tag);
            }
            
            
            headAnimator.SetTrigger("Fire");
            weaponAnimator.SetTrigger("Fire");
            ammo--;
            Shoot?.Invoke(ammo);
        }
    }
    
    
    
}