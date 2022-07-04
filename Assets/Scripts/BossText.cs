using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossText : MonoBehaviour
{
    public GameObject bossText;
    //�J�����͈͂̏㉺���C��
    private float cameraLineZTop = 11.0f;
    private float cameraLineZBottom = -11.5f;
    //�e�L�X�g�̈ړ�����speed
    private float textMoveSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        //�J�n���ɂ͉B���Ă���
        bossText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //�e�L�X�g�̃��[���h���W���擾
        Vector3 pos = transform.position;
        //���Ɉړ����Ă���
        pos.z -= textMoveSpeed;
        //���[���h���W���X�V
        transform.position = pos;

        //�J�����͈͂̏�[�ɗ�����
        if(transform.position.z <= cameraLineZTop)
        {
            //�A�N�e�B�u�ɂ��ĕ\��������
            bossText.SetActive(true);
        }

        //�J�����͈͂̉��[�ɗ�����
        if(transform.position.z <= cameraLineZBottom)
        {
            //��\���ɖ߂�
            bossText.SetActive(false);
        }
    }
}
