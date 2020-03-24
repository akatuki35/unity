using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    GameObject RotateObject;

    RotateCube CubeScript;

    Rigidbody rigid;

    float walkForce = 60.0f;
    float maxWalkSpeed = 1.0f;

    bool RotateFlag_Right = false;
    bool RotateFlag_Left = false;

    int RotateNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody>();

        RotateObject = GameObject.Find("Cube");

        CubeScript=RotateObject.GetComponent<RotateCube>();
    }

    // Update is called once per frame
    void Update()
    {
        //1なら左移動、-1なら右移動
        int key = 0;

        //回転中なら移動しない
        if (RotateFlag_Right == false && RotateFlag_Left == false)
        {
            //左移動
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                key = -1;
            }
            //右移動
            if (Input.GetKey(KeyCode.RightArrow))
            {
                key = 1;
            }
        }

        float speedx = Mathf.Abs(this.rigid.velocity.x);

        //スピード調整
        if(speedx<this.maxWalkSpeed)
        {
            this.rigid.AddForce(transform.right * key * this.walkForce);
        }

        //keyの値によりキャラを反転
        if (key != 0) 
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //プレイヤーの速度でアニメーション速度変更

        if (RotateFlag_Right == true)
        {
            if (RotateNumber < 90) 
            {
                Transform PlayerTrans = this.gameObject.GetComponent<Transform>();
                Vector3 localPos = PlayerTrans.localPosition;
                localPos.x += -0.12f;
                PlayerTrans.localPosition = localPos;
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
                Transform PlayerTrans = this.gameObject.GetComponent<Transform>();
                Vector3 localPos = PlayerTrans.localPosition;
                localPos.x += 0.12f;
                PlayerTrans.localPosition = localPos;
                RotateNumber--;
            }
            if (RotateNumber == -90)
            {
                RotateNumber = 0;
                RotateFlag_Left = false;
            }
        }
    }

    //3d判定
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightTag" && RotateFlag_Right == false && RotateFlag_Left == false) 
        {
            CubeScript.Rotate_Right();
            RotateFlag_Right = true;
        }
        if (other.gameObject.tag == "LeftTag" && RotateFlag_Right == false && RotateFlag_Left == false)
        {
            CubeScript.Rotate_Left();
            RotateFlag_Left = true;
        }
    }
}
