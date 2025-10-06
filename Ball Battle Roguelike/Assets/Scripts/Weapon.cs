using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Damage;

public abstract class Weapon : MonoBehaviour
{
    protected GameObject owner;
    protected Rigidbody2D rigidbody2d;
    protected Collider2D collider2d;

    [SerializeField] protected LayerMask weaponMask = 1 << 6;

    [Space]

    [SerializeField] protected double damage;
    [SerializeField] protected DamageType damageType;
    [SerializeField] protected double speed;
    [SerializeField] protected double cooldown;

    protected bool reverseRotation;

    protected virtual void Awake()
    {
        owner = transform.parent.gameObject;
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        collider2d = gameObject.GetComponent<Collider2D>();
    }

    protected virtual void FixedUpdate()
    {
        int rotationDirection = reverseRotation ? -1 : 1;
        transform.Rotate(Vector3.forward, 10 * Time.fixedDeltaTime * rotationDirection);
        transform.position = owner.transform.position + (transform.up * transform.localScale.y / 2);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == owner) return;

        IDamageable[] damageables = collision.gameObject.GetComponents<IDamageable>();
        foreach (IDamageable damageable in damageables)
            damageable.TakeDamage(damage, damageType);

        if (collision.gameObject.layer == weaponMask)
            reverseRotation = !reverseRotation;
    }
}
