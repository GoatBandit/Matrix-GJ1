using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalFollow : MonoBehaviour
{
    public Transform target; // The target object to follow
    private Movement movement;

    private void Awake()
    {
        if (target.GetComponent<Movement>() != null)
        {
            movement = target.GetComponent<Movement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movement != null)
        {
            if (movement.crouching)
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z); // If the player is crouching, move the camera down.
                transform.position = pos;
            }
            else if (movement.jumping)
            {
                Vector3 pos = new Vector3(transform.position.x, target.position.y - 2.0f, transform.position.z); // If the player is jumping, move the camera up.
                transform.position = pos;
            }
            else
            {
                Vector3 pos = new Vector3(transform.position.x, target.position.y, transform.position.z); // Follow the player's yPos.
                transform.position = pos;
            }
        }
        else
        {
            Vector3 pos = new Vector3(transform.position.x, target.position.y, transform.position.z); // Follow the player's yPos.
            transform.position = pos;
        }
    }
}
