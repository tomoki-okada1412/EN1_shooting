using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//拡散弾
public class EnemyWayShot : MonoBehaviour
{
    //プレイヤー
    private GameObject player;

    //弾のゲームオブジェクト
    public GameObject bullet;

    //1回で打ち出す弾の数を決める
    public int bulletWayNum = 3;

    //打ち出す弾の間隔を調整する
    public int bulletWaySpace = 30;

    //打ち出す間隔を決める
    public float time = 1;

    //最初に打ち出すまでの時間を決める
    public float delayTime = 1;

    //現在のタイマー時間
    float nowtime = 0;
    // Start is called before the first frame update
    void Start()
    {
        //タイマーを初期化
        nowtime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        //もしプレイヤーの情報が入っていなかったら
        if (player == null)
        {
            //プロジェクトのPlayerを探して情報を取得
            player = GameObject.FindGameObjectWithTag("Player");
        }
        float enemyBeginShotLineZ = 10.4f;

        //画面内に入ってきたら弾を打つようにする
        if (transform.position.z <= enemyBeginShotLineZ)
        {
            //タイマーで減らす
            nowtime -= Time.deltaTime;

            //もしタイマーが0以下になったら
            if (nowtime <= 0)
            {
                //角度調節用の変数
                float bulletWaySpaceSplit = 0;

                //一回で発射する弾数分だけループする
                for (int i = 0; i < bulletWayNum; i++)
                {
                    //弾を生成
                    CreateShotObject(bulletWaySpace - bulletWaySpaceSplit + transform.localEulerAngles.y);
                    //発射音を再生
                    GetComponent<AudioSource>().Play();

                    //角度を調整する
                    bulletWaySpaceSplit += (bulletWaySpace / (bulletWayNum - 1) * 2);
                }
                //タイマーを初期化
                nowtime = time;
            }
        }
    }

    private void CreateShotObject(float axis)
    {
        //ベクトルを取得
        var direction = player.transform.position - transform.position;

        //ベクトルのyを初期化
        direction.y = 0;

        //向きを取得
        var lookRotation=Quaternion.LookRotation(direction,Vector3.up);

        //弾を生成する
        GameObject bulletClone =
        Instantiate(bullet, transform.position, Quaternion.identity);

        //EnemyBulletのゲットコンポーネントを変数として保存
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        //弾を打ち出したオブジェクトの情報を渡す
        bulletObject.SetCharacterObject(gameObject);

        //弾を打ち出す角度を変更する
        bulletObject.SetForwardAsix(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));
    }
}
