using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    bool RotateFlag_Right = false;
    bool RotateFlag_Left = false;

    int RotateNumber = 0;

    //外部参照可能なpublic
    public void Rotate_Right()
    {
        //右回転
        if (RotateFlag_Right == false && RotateFlag_Left == false) 
        {
            RotateFlag_Right = true;
        }
    }
    public void Rotate_Left()
    {
        if (RotateFlag_Right == false && RotateFlag_Left == false)
        {
            RotateFlag_Left = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateFlag_Right == true) 
        {
            if (RotateNumber < 90) 
            {
                transform.Rotate(new Vector3(0, 1, 0));

                RotateNumber++;
            }
            if (RotateNumber == 90)
            {
                RotateNumber = 0;

                RotateFlag_Right = false;
            }
        }

        if (RotateFlag_Left == true)
        {
            if (RotateNumber > -90)
            {
                transform.Rotate(new Vector3(0, -1, 0));

                RotateNumber--;
            }
            if (RotateNumber == -90)
            {
                RotateNumber = 0;

                RotateFlag_Left = false;
            }
        }
    }
}
