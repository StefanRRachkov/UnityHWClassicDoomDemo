using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagment : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammunition = null;
    [SerializeField] private TextMeshProUGUI health = null;
    [SerializeField] private TextMeshProUGUI frags = null;
    [SerializeField] private TextMeshProUGUI armor = null;

    [SerializeField] private GameObject player = null;

    private void OnEnable()
    {
        if (player != null)
        {
            player.GetComponent<Firing>().Shoot += UsingAmmo;
            player.GetComponent<Health>().OnDamageTaken += TakeDamage;
        }
    }

    private void OnDisable()
    {
        if (player != null)
        {
            player.GetComponent<Firing>().Shoot -= UsingAmmo;
            player.GetComponent<Health>().OnDamageTaken -= TakeDamage;
        }
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
