using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiverMovePlateform : MonoBehaviour
{
    PlateformMove scriptPlateform;

    bool levierActiver = false;

    private void Start()
    {
        scriptPlateform = GetComponentInChildren<PlateformMove>();
    }

    public void ActivationLevier()
    {
        if (!levierActiver)
        {
            //play anim
            scriptPlateform.activerMove = true;
        }
    }
}
