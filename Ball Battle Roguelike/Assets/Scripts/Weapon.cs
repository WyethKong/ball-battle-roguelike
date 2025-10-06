using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Damage;

public abstract class Weapon : MonoBehaviour
{
    protected GameObject owner;
    protected Rigidbody2D rigidbody2d;
    protected Collider2D collider2d;

    [SerializeField] protected double damage;
    [SerializeField] protected DamageType damageType;
    [SerializeField] protected double speed;
    [SerializeField] protected double cooldown;

    protected virtual void Awake()
    {
        owner = transform.parent.gameObject;
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        collider2d = gameObject.GetComponent<Collider2D>();
    }

    protected virtual void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, 10 * Time.fixedDeltaTime);
        transform.position = owner.transform.position + (transform.up * transform.localScale.y / 2);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
