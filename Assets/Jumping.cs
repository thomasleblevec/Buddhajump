using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{

    [SerializeField]
    Transform pointJumper;

    // Start is called before the first frame update
    void Awake()
    {

        Transform point = Instantiate(pointJumper);
        point.SetParent(transform, false);

    }

    // Update is called once per frame
    void Update()
    {

    }


}
