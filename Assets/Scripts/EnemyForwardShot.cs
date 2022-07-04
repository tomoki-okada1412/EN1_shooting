using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForwardShot : MonoBehaviour
{
    //�v���C���[
    private GameObject player;

    //�e�̃Q�[���I�u�W�F�N�g������
    public GameObject bullet;

    //�ł��o���Ԋu�����߂�
    public float time = 1;

    //�ŏ��ɑł��o���܂ł̎��Ԃ����߂�
    public float delayTime = 1;

    //���݂̃^�C�}�[����
    float nowtime = 0;
    
    
    // Start is called before the first frame update
    //�X�^�[�g�֐�
    void Start()
    {
        nowtime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        //�����v���C���[�̏�񂪓����ĂȂ�������
        if (player == null)
        {
            //�v���W�F�N�g��Player��T���ď����擾 �v���C���[��1�����Ȃ��̂ŒP���`�̕����g�p
            player = GameObject.FindGameObjectWithTag("Player");
        }

        //��ʓ�(��̒[)
        float enemyBeginShotLineZ = 10.4f;

        //��ʓ��ɓ����Ă�����e��ł悤�ɂ���
        if (transform.position.z <= enemyBeginShotLineZ)
        {

            //�^�C�}�[�����炷
            nowtime -= Time.deltaTime;

            //�����^�C�}�[��0�ȉ��ɂȂ�����
            if (nowtime <= 0)
            {
                
                //�e�𐶐�����
                CreateShotObject(-transform.localEulerAngles.y);
                //���ˉ����Đ�
                GetComponent<AudioSource>().Play();

                //�^�C�}�[��������
                nowtime = time;
            }
        }
    }

    private void CreateShotObject(float axis)
    {
        //�x�N�g�����擾
        var direction=player.transform.position-transform.position;

        //�x�N�g����y��������
        direction.y = 0;

        //�������擾����
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        //�e�𐶐�����
        GameObject bulletClone =
            Instantiate(bullet, transform.position, Quaternion.identity);

        //EnemyBullet�̃Q�b�g�R���|�[�l���g��ϐ��Ƃ��ĕۑ� var�͌^���_�炵���B
        var bulletObject=bulletClone.GetComponent<EnemyBullet>();

        //�e��ł��o�����I�u�W�F�N�g�̏���n��
        bulletObject.SetCharacterObject(gameObject);

        //�e��ł��o���p�x��ύX����
        bulletObject.SetForwardAsix(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));
    }
}
