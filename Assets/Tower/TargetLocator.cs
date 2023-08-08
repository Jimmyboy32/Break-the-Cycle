using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    // Variables to set weapon and target
    [SerializeField] Transform weapon;
    Transform target;

    void Start()
    {
        // Find enemies with script EnemyMover attached
        target = FindObjectOfType<EnemyMover>().transform;
    }

    void Update()
    {
        AimWeapon();
    }

    // weapons follows the target
    void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
