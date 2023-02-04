using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Movement")]
    public float movementSpeed = 5f;

    [Header("Jump")]
    public float jumpForce = 10f;
    public int jumpsTotal = 1;
}
