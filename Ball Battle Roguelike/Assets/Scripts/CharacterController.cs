using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Damage;

public class CharacterController : MonoBehaviour, IDamageable
{
    //Rigidbody2D rigidbody2d;
    //CircleCollider2D collider2d;
    LayerMask collisionMask;

    [SerializeField] double health = 10;   // The amount of damage the character can take before dying
    [SerializeField] double speed = 0;     // The speed the character moves at

    Vector2 moveDirection;

    private void Awake()
    {
        //rigidbody2d = GetComponent<Rigidbody2D>();
        //collider2d = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        moveDirection = Vector2.left;
    }

    private void FixedUpdate()
    {
        float distance = (float)speed * Time.fixedDeltaTime;
        while (distance > 0)
        {
            RaycastHit2D hit = Physics2D.CircleCast(
                transform.position,
                transform.localScale.x / 2,
                moveDirection,
                distance
                //collisionMask
            );

            if (hit)
            {
                transform.Translate(moveDirection * hit.distance);
                distance -= hit.distance;

                moveDirection = Vector2.Reflect(moveDirection, hit.normal);
            }
            else
            {
                transform.Translate(moveDirection * distance);
                distance = 0;
            }
        }
    }

    public void TakeDamage(double damage, DamageType damageType)
    {
        health -= Mathf.Max(0, (float)damage);
    }
}
