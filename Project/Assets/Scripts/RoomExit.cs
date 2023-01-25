using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomExit : MonoBehaviour
{
    [SerializeField] private UnityEvent onRoomExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onRoomExit.Invoke();
        }
    }
}
