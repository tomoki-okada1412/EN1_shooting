using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    //Enemy‚Ì‘Ì—Í—p•Ï”
    private int bossEnemyHp;
    // Start is called before the first frame update
    void Start()
    {
        //¶¬‚É‘Ì—Í‚ğw’è‚µ‚Ä‚¨‚­
        bossEnemyHp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //‚à‚µ‘Ì—Í‚ª0ˆÈ‰º‚É‚È‚Á‚½‚ç
        if (bossEnemyHp <= 0)
        {
            //©•ª‚ÅÁ‚¦‚é
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

