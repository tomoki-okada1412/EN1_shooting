using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //����������p�[�e�B�N����ݒ�
    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�L�[�{�[�h��B�L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.B))
        {
            //�^�O�������I�u�W�F�N�g��S�Ď擾
            GameObject[] enemyBulletObject =
            GameObject.FindGameObjectsWithTag("EnemyBullet");

            //��Ŏ擾�����S�ẴI�u�W�F�N�g�����ł�����
            for(int i = 0; i < enemyBulletObject.Length; i++)
            {
                Destroy(enemyBulletObject[i].gameObject);
            }
            //�p�[�e�B�N�����������I�u�W�F�N�g�𐶐�����
            Instantiate(particle, Vector3.zero, Quaternion.identity);
        }
    }
}
