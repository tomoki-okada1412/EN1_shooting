using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //弾のワールド座標を取得
        Vector3 pos = transform.position;

        //上にまっすぐ飛ぶ
        pos.z += 0.1f;

        //弾の移動
        transform.position = new Vector3(pos.x, pos.y, pos.z);

        //一定距離進んだら消滅
        if (pos.z >= 10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //ぶつかってきた相手の情報の中からEnemyを取得し、Damageを呼び出す
            other.gameObject.GetComponent<Enemy>().Damage();
            //一応貫通していかないように、当たったらDestroyする処理を噛ませてる
            Destroy(this.gameObject);
        }

        if(other.tag == "BossEnemy")
        {
            //ぶつかってきた相手の情報の中からBossEnemyを取得し、Damageを呼び出す
            other.gameObject.GetComponent<BossEnemy>().Damage();
            //一応貫通していかないように、当たったらDestroyする処理を噛ませてる
            Destroy(this.gameObject);
        }
    }
}
