using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagment : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammunition;
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI frags;
    [SerializeField] private TextMeshProUGUI armor;

    [SerializeField] private Firing playerFireManager;
    [SerializeField] private Health playerHealth;

    private void OnEnable()
    {
        playerFireManager.Shoot += UsingAmmo;
        playerHealth.OnDamageTaken += TakeDamage;
    }

    private void OnDisable()
    {
        playerFireManager.Shoot -= UsingAmmo;
        playerHealth.OnDamageTaken -= TakeDamage;
    }

    private void UsingAmmo(int ammunitionCount)
    {
        ammunition.text = (ammunitionCount.ToString());
    }
    
    private void TakeDamage(int healthPoints)
    {
        health.text = (healthPoints.ToString());
    }
}
