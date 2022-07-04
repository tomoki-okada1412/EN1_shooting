using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedShot : MonoBehaviour
{
    //�v���C���[
    private GameObject player;

    //�e�̃Q�[���I�u�W�F�N�g������
    public GameObject bullet;

    //1��őł��o���e�̐������߂�
    public int bulletWayNum = 3;

    //�ł��o���Ԋu�𒲐�����
    public float bulletWaySpace = 30;

    //�ł��o���p�x�𒲐߂���
    public float bulletWayAxis = 0;

    //�ł��o���Ԋu�����߂�
    public float time = 1;

    //�ŏ��ɑł��o���܂ł̎��Ԃ����߂�
    public float delayTime = 1;

    //���݂̃^�C�}�[����
    float nowtime = 0;
    // Start is called before the first frame update
    void Start()
    {
        //�^�C�}�[��������
        nowtime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        //�����v���C���[�̏�񂪓����ĂȂ�������
        if(player == null)
        {
            //�v���W�F�N�g��Plyaer��T���ď����擾����
            player = GameObject.FindGameObjectWithTag("Player");
        }

        float enemyBeginShotLineZ = 10.4f;

        //��ʓ��ɓ����Ă�����e��ł悤�ɂ���
        if (transform.position.z <= enemyBeginShotLineZ)
        {
            //�^�C�}�[�����炷
            nowtime -= Time.deltaTime;

            //�����^�C�}�[��0�ȉ��ɂȂ�����
            if (nowtime <= 0)
            {
                //�p�x�����p�̕ϐ�
                float bulletWaySpaceSplit = 0;

                //���Ŕ��˂���e�̐��������[�v����
                for (int i = 0; i < bulletWayNum; i++)
                {
                    //�e�𐶐�
                    CreateShotObject(
                    bulletWaySpace - bulletWaySpaceSplit + bulletWayAxis - transform.localEulerAngles.y);
                    //���ˉ����Đ�
                    GetComponent<AudioSource>().Play();

                    //�p�x�𒲐�����
                    bulletWaySpaceSplit += (bulletWaySpace / (bulletWayNum - 1)) * 2;
                }
                //�^�C�}�[��������
                nowtime = time;
            }
        }
    }

    private void CreateShotObject(float axis)
    {
        //�e�𐶐�����
        GameObject bulletClone =
        Instantiate(bullet, transform.position, Quaternion.identity);

        //EnemyBullet�̃Q�b�g�R���|�[�l���g��ϐ��Ƃ��ĕۑ�
        var bulletObject=bulletClone.GetComponent<EnemyBullet>();

        //�e��ł��o�����I�u�W�F�N�g�̏���n��
        bulletObject.SetCharacterObject(gameObject);

        //�e��ł��o���p�x��ύX����
        bulletObject.SetForwardAsix(Quaternion.AngleAxis(axis, Vector3.up));
    }
}
