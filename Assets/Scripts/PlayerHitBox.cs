using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        GameObject parent;
        //�e�̃Q�[���I�u�W�F�N�g���w��
        parent = transform.parent.gameObject;

        //�������Ă�����A�����̐e(Player)�ɏ�����C����
        parent.GetComponent<PlayerMove>().Damage();
    }
}
