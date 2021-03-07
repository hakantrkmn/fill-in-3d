using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCreator : MonoBehaviour
{
    [Space]
    [SerializeField]
    private Sprite image;

    public Transform alphaCubeParent;
    public Transform ImageCubeParent;
    public Transform CarryCubeParent;

    [Space]
    [SerializeField]
    private GameObject cube;


    [Space]
    [SerializeField]
    private GameObject CarryCube;

    [Space]
    [SerializeField]
    private GameObject alphaCubes;



    float size = .3f;

    Texture2D texture2D;
    public int cubeCount = 0;

    Vector3 cubePos = Vector3.zero;

    private void Awake()
    {

        getImage();
        getCarryCubes();

    }

    void getImage()
    {
        texture2D = image.texture;


        for (int x = 0; x < texture2D.width; x++)
        {
            for (int y = 0; y < texture2D.height; y++)
            {

                Color color = texture2D.GetPixel(x, y);

                if (color.a == 0)
                {
                    cubePos = new Vector3(size * (x - (texture2D.width * .5f)), 0.2f, size * (y - (texture2D.height) * .5f));
                    GameObject beyazkup = Instantiate(alphaCubes, alphaCubeParent);
                    beyazkup.transform.localPosition = cubePos;
                    beyazkup.transform.localScale = Vector3.one * size;
                    continue;
                }

                cubePos = new Vector3(size * (x - (texture2D.width * .5f)), 0.2f, size * (y - (texture2D.height) * .5f));
                GameObject cubeobj = Instantiate(cube, ImageCubeParent);
                cubeobj.transform.localPosition = cubePos;
                cubeobj.GetComponent<Renderer>().material.color = color;
                cubeobj.transform.localScale = Vector3.one * size;
                cubeCount++;

            }
        }
    }

    void getCarryCubes()
    {
        int test = 0;
        for (int i = 0; i < cubeCount; i++)
        {
            Instantiate(CarryCube, new Vector3(0, i+1, Random.Range(-7, -5)), transform.rotation, CarryCubeParent);
            test++;

        }
        Debug.Log(test);
    }

}
