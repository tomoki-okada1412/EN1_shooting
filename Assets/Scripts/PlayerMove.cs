using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private int playerHp;
    // Start is called before the first frame update
    void Start()
    {
        //生成時に体力を指定しておく
        playerHp = 20;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのワールド座標を取得
        Vector3 pos = transform.position;

        //移動スピード変更用変数
        float playerSpeed = 0.05f;

        //左右どちらかのshiftキーが入力されている時
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            //playerSpeedを0.25に設定
            playerSpeed = 0.025f;
        }

        //右矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //右方向に0.05動く
            pos.x += playerSpeed;
        }
        //左矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //左方向に0.05動く
            pos.x -= playerSpeed;
        }
        //上矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //上方向に0.05動く
            pos.z += playerSpeed;
        }
        //下矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //下方向に0.05動く
            pos.z -= playerSpeed;
        }

        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    public void Damage()
    {
        //当たった場合HPを1引く
        playerHp--;
        //enemyHp = enemyHp - 1;

        //確認用DebugLog
        Debug.Log("playerHp:" + playerHp);

        if(playerHp <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
