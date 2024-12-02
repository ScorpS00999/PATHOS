using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerSceneJour : MonoBehaviour
{
    [SerializeField] SpriteRenderer imgEmplacement;
    Sprite img;

    [SerializeField] List<Sprite> imagesSceneJ = new List<Sprite>();


    int idImagesScene = 0;

    private void Start()
    {
        img = imgEmplacement.sprite;
        //img = imagesSceneJ[idImagesScene];
        imgEmplacement.sprite = imagesSceneJ[idImagesScene];
        print(imagesSceneJ[idImagesScene].name);
    }

    private void OnMouseDown()
    {
        idImagesScene++;
        print(idImagesScene % imagesSceneJ.Count);
        imgEmplacement.sprite = imagesSceneJ[idImagesScene%imagesSceneJ.Count];
    }
}
