using System;
using UnityEngine;

public class WeaponBenchInteract : MonoBehaviour
{
    [SerializeField] private GameObject weaponUpgradeMenuCanvas;

    private void Start()
    {
        weaponUpgradeMenuCanvas.SetActive(false);
    }
}
