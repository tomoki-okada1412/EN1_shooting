using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBossMove : MonoBehaviour
{
    private float enemyMoveSpeed = 0.05f;   //敵が動くスピード
    private float enemyStopLineZ = 8.5f;     //敵が止まるZ座標ライン
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //敵のワールド座標を取得
        Vector3 pos = transform.position;
        //下に移動していく
        pos.z -= enemyMoveSpeed;
        //ワールド座標を更新
        transform.position = pos;

        //敵が消滅するZ座標ラインに来たら
        if (transform.position.z <= enemyStopLineZ)
        {
            enemyMoveSpeed = 0.0f;
        }
    }
}

