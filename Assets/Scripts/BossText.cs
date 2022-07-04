using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossText : MonoBehaviour
{
    public GameObject bossText;
    //カメラ範囲の上下ライン
    private float cameraLineZTop = 11.0f;
    private float cameraLineZBottom = -11.5f;
    //テキストの移動するspeed
    private float textMoveSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        //開始時には隠しておく
        bossText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //テキストのワールド座標を取得
        Vector3 pos = transform.position;
        //下に移動していく
        pos.z -= textMoveSpeed;
        //ワールド座標を更新
        transform.position = pos;

        //カメラ範囲の上端に来たら
        if(transform.position.z <= cameraLineZTop)
        {
            //アクティブにして表示させる
            bossText.SetActive(true);
        }

        //カメラ範囲の下端に来たら
        if(transform.position.z <= cameraLineZBottom)
        {
            //非表示に戻す
            bossText.SetActive(false);
        }
    }
}
