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
        //�e�̃��[���h���W���擾
        Vector3 pos = transform.position;

        //��ɂ܂��������
        pos.z += 0.1f;

        //�e�̈ړ�
        transform.position = new Vector3(pos.x, pos.y, pos.z);

        //��苗���i�񂾂����
        if (pos.z >= 10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //�Ԃ����Ă�������̏��̒�����Enemy���擾���ADamage���Ăяo��
            other.gameObject.GetComponent<Enemy>().Damage();
            //�ꉞ�ђʂ��Ă����Ȃ��悤�ɁA����������Destroy���鏈�������܂��Ă�
            Destroy(this.gameObject);
        }

        if(other.tag == "BossEnemy")
        {
            //�Ԃ����Ă�������̏��̒�����BossEnemy���擾���ADamage���Ăяo��
            other.gameObject.GetComponent<BossEnemy>().Damage();
            //�ꉞ�ђʂ��Ă����Ȃ��悤�ɁA����������Destroy���鏈�������܂��Ă�
            Destroy(this.gameObject);
        }
    }
}
