using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float enemyMoveSpeed = 0.05f;   //�G�������X�s�[�h
    private float enemyDeadLineZ = -11;     //�G�����ł���Z���W���C��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�G�̃��[���h���W���擾
        Vector3 pos = transform.position;
        //���Ɉړ����Ă���
        pos.z -= enemyMoveSpeed;
        //���[���h���W���X�V
        transform.position = pos;

        //�G�����ł���Z���W���C���ɗ�����
        if (transform.position.z <= enemyDeadLineZ)
        {
            //�G�����ł�����
            Destroy(this.gameObject);
        }
    }
}
