using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    //Enemy�̗̑͗p�ϐ�
    private int bossEnemyHp;
    // Start is called before the first frame update
    void Start()
    {
        //�������ɑ̗͂��w�肵�Ă���
        bossEnemyHp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //�����̗͂�0�ȉ��ɂȂ�����
        if (bossEnemyHp <= 0)
        {
            //�����ŏ�����
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

