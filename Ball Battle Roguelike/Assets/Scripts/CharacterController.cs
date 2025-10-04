using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int power = 0;
    [SerializeField] int speed = 0;
    [SerializeField] int magic = 0;

    Vector2 moveDirection;
}
