using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class platform : MonoBehaviour
{


    [SerializeField]
    Transform pointPlatform;

    [SerializeField]
    Transform pointFalsePlatform;

    int resolution = 100;
    Transform[] points;
    float[] speed;

    void Awake()
    {
        points = new Transform[resolution];
        speed = new float[resolution];

        TextAsset positiveFile = (TextAsset)Resources.Load<TextAsset>("positives");
        StringReader reader = new StringReader(positiveFile.text);

        TextAsset negativeFile = (TextAsset)Resources.Load<TextAsset>("negatives");
        StringReader readerFalse = new StringReader(negativeFile.text);

        Vector3 previousPoint = new Vector3(0,0,0);
        Transform first = Instantiate(pointPlatform);
        first.localPosition = previousPoint;
        first.SetParent(transform, false);
        float previous = 0;
        float offset = 0;
        float rand = 0;
        float sizeplat = first.GetComponent<Renderer>().bounds.size.x;
        Debug.Log(sizeplat);

        for (int i=1;i < resolution;i++)
        {

            Transform point = points[i] = Instantiate(pointPlatform);
            Transform pointFalse = Instantiate(pointFalsePlatform);
            rand = Random.Range(-1f, 1f);
            if (rand > 0)
            {
                offset = 1;
            }
            else { offset = -1; }
            previous += rand+offset*sizeplat/2;
            point.localPosition = Vector3.up *i*3 + new Vector3(previous,0,0);
            pointFalse.localPosition = Vector3.up * i * 3 + new Vector3(previous-2*(rand+offset*sizeplat/2), 0, 0);
            point.SetParent(transform,false);
            pointFalse.SetParent(transform, false);
            point.GetChild(0).gameObject.GetComponent<TextMesh>().text = reader.ReadLine();
            pointFalse.GetChild(0).gameObject.GetComponent<TextMesh>().text = readerFalse.ReadLine();
            System.Random rnd = new System.Random();
            speed[i]= (rnd.Next(0, 2) * 2 - 1)*0.5f*Time.deltaTime; //speed negative or positive
        }

        reader.Close();
        readerFalse.Close();

    }

    void Update()
    {

        // move the platforms
        // for now not moving them 
        //for (int i = 0; i < points.Length; i++)
        //{
        //    Transform point = points[i];
        //    Vector3 position = point.localPosition;
        //    if (position.x > 2f | position.x < -2f)
        //    {
        //        speed[i] = -speed[i];
        //    }

        //    position.x += speed[i] ;
        //    point.localPosition = position;
        //}
    }
}
