using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage : MonoBehaviour
{
    bool isCalledOnce = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if(isCalledOnce==true)
            {
                transform.Rotate(0, 90, 0);
                isCalledOnce = false;
            }
        }
        else
        {
            isCalledOnce = true;
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 1, 0);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -1, 0);
        }
    }
}
