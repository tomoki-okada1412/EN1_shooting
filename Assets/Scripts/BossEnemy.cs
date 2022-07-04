using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    //Enemyの体力用変数
    private int bossEnemyHp;
    // Start is called before the first frame update
    void Start()
    {
        //生成時に体力を指定しておく
        bossEnemyHp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //もし体力が0以下になったら
        if (bossEnemyHp <= 0)
        {
            //自分で消える
            Destroy(this.gameObject);
        }
    }
    public void Damage()
    {
        bossEnemyHp--;
        //enemyHp = enemyHp - 1;
        Debug.Log("bossEnemyHp:" + bossEnemyHp);
    }
}

