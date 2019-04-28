using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public PlayerController player;

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.collider.name);
    }


}
