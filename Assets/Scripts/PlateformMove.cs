using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlateformMove : MonoBehaviour
{
    [SerializeField] float PosX;
    [SerializeField] float PosY;


    //[SerializeField] float PosXRetour;
    //[SerializeField] float PosYRetour;

    [SerializeField] float speed = 2f;


    //protected
    public bool activerMove = false;


    Vector2 pos1;
    Vector2 pos2;


    private bool retour;

    //GameObject player;


    private void Start()
    {
        pos1 = new Vector2(PosX, PosY);
        //pos2 = new Vector2(PosXRetour, PosYRetour);
        pos2 = transform.position;
    }

    private void Update()
    {
        if (activerMove)
        {
            if (!retour)
            {
                transform.position = Vector2.MoveTowards(transform.position, pos1, speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, pos1) < 0.05f)
                {
                    retour = true;
                }
            }
            if (retour)
            {
                transform.position = Vector2.MoveTowards(transform.position, pos2, speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, pos2) < 0.05f)
                {
                    retour = false;
                }
            }
        }
    }


    


    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        collision.transform.parent = transform;
    //    }
    //}
    //
    ////Si notre joueur quitte cette plateform, il arrêtera d'être son "enfant" et donc ne bougera plus avec la plateforme
    //void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        collision.transform.parent = null;
    //    }
    //}






    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(new Vector2(PosX, PosY), 0.2f);
        //Gizmos.DrawSphere(new Vector2(PosXRetour, PosYRetour), 0.2f);
        Gizmos.DrawSphere(transform.position, 0.2f);
        Gizmos.DrawLine(transform.position, new Vector2(PosX, PosY)); // Dessiner une ligne entre les deux points

        //SceneView.RepaintAll();
    }
}
