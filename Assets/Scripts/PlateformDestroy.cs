using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformDestroy : MonoBehaviour
{
    [SerializeField] float attentePlateform = 2f;
    [SerializeField] float attenteRespawn = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(attenteDestroyPlateforme());
        }
    }

    IEnumerator attenteDestroyPlateforme()
    {
        yield return new WaitForSeconds(attentePlateform);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //gameObject.SetActive(false);
        print("ok2");
        yield return new WaitForSeconds(attenteRespawn);
        print("ok");
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        //gameObject.SetActive(true);
    }
}
