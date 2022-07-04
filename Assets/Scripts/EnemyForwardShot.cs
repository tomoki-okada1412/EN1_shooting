using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForwardShot : MonoBehaviour
{
    //プレイヤー
    private GameObject player;

    //弾のゲームオブジェクトを入れる
    public GameObject bullet;

    //打ち出す間隔を決める
    public float time = 1;

    //最初に打ち出すまでの時間を決める
    public float delayTime = 1;

    //現在のタイマー時間
    float nowtime = 0;
    
    
    // Start is called before the first frame update
    //スタート関数
    void Start()
    {
        nowtime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        //もしプレイヤーの情報が入ってなかったら
        if (player == null)
        {
            //プロジェクトのPlayerを探して情報を取得 プレイヤーは1つしかないので単数形の方を使用
            player = GameObject.FindGameObjectWithTag("Player");
        }

        //画面内(上の端)
        float enemyBeginShotLineZ = 10.4f;

        //画面内に入ってきたら弾を打つようにする
        if (transform.position.z <= enemyBeginShotLineZ)
        {

            //タイマーを減らす
            nowtime -= Time.deltaTime;

            //もしタイマーが0以下になったら
            if (nowtime <= 0)
            {
                
                //弾を生成する
                CreateShotObject(-transform.localEulerAngles.y);
                //発射音を再生
                GetComponent<AudioSource>().Play();

                //タイマーを初期化
                nowtime = time;
            }
        }
    }

    private void CreateShotObject(float axis)
    {
        //ベクトルを取得
        var direction=player.transform.position-transform.position;

        //ベクトルのyを初期化
        direction.y = 0;

        //向きを取得する
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        //弾を生成する
        GameObject bulletClone =
            Instantiate(bullet, transform.position, Quaternion.identity);

        //EnemyBulletのゲットコンポーネントを変数として保存 varは型推論らしい。
        var bulletObject=bulletClone.GetComponent<EnemyBullet>();

        //弾を打ち出したオブジェクトの情報を渡す
        bulletObject.SetCharacterObject(gameObject);

        //弾を打ち出す角度を変更する
        bulletObject.SetForwardAsix(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));
    }
}
