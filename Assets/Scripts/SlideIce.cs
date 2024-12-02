using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideIce : MonoBehaviour
{
    GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            player.GetComponent<PlayerController>().enabled = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        player.GetComponent<PlayerController>().enabled = true;
    }
}
