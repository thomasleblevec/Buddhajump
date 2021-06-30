using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falseplatform : MonoBehaviour
{
    [SerializeField]
    Transform pointPlatform;

    void Awake()
    {

        //StreamReader reader = new StreamReader("Assets/negatives");

        //for (int i = -10; i < 100; i++)
        //{
        //    Transform point = Instantiate(pointPlatform);
        //    point.localPosition = Vector3.up * (i) * 3 + new Vector3(Random.Range(-3f, 3f), Random.Range(0f,3f), 0);
        //    point.SetParent(transform, false);
        //    //point.GetChild(0).gameObject.GetComponent<TextMesh>().text = reader.ReadLine();
        //}

        //reader.Close();

    }
}
