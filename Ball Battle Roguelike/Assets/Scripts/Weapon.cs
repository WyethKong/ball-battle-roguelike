using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Damage;

public abstract class Weapon : MonoBehaviour
{
    protected GameObject owner;
    protected Rigidbody2D rigidbody2d;
    protected Collider2D collider2d;

    [SerializeField] protected int damage;
    [SerializeField] protected DamageType damageType;
    [SerializeField] protected double cooldown;

    protected virtual void Awake()
    {
        owner = gameObject.GetComponentInParent<GameObject>();
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        collider2d = gameObject.GetComponent<Collider2D>();
    }
}
