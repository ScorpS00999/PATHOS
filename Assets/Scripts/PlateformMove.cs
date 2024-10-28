using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMove : MonoBehaviour
{
    [SerializeField] float PosX;
    [SerializeField] float PosY;


    [SerializeField] float PosXRetour;
    [SerializeField] float PosYRetour;

    [SerializeField] float speed = 2f;


    //protected
    public bool activerMove = false;


    Vector2 pos1;
    Vector2 pos2;


    private bool retour;


    private void Start()
    {
        pos1 = new Vector2(PosX, PosY);
        pos2 = new Vector2(PosXRetour, PosYRetour);
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




    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(new Vector2(PosX, PosY), 0.2f);
        Gizmos.DrawSphere(new Vector2(PosXRetour, PosYRetour), 0.2f);
        Gizmos.DrawLine(new Vector2(PosXRetour, PosYRetour), new Vector2(PosX, PosY)); // Dessiner une ligne entre les deux points

        //SceneView.RepaintAll();
    }
}
