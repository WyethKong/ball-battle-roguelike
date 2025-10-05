using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour, IDamageable
{
    [SerializeField] int health = 10;   // The amount of damage the character can take before dying
    [SerializeField] int power = 0;     // The amount of damage added to physical attacks 
    [SerializeField] int magic = 0;     // The amount of damage added to magic attacks
    [SerializeField] int speed = 0;     // The speed the character moves at

    Vector2 moveDirection;

    public void TakeDamage(int damage)
    {
        health -= Mathf.Max(0, damage);
    }
}
