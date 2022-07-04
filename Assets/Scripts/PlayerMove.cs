using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private int playerHp;
    // Start is called before the first frame update
    void Start()
    {
        //�������ɑ̗͂��w�肵�Ă���
        playerHp = 20;
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̃��[���h���W���擾
        Vector3 pos = transform.position;

        //�ړ��X�s�[�h�ύX�p�ϐ�
        float playerSpeed = 0.05f;

        //���E�ǂ��炩��shift�L�[�����͂���Ă��鎞
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            //playerSpeed��0.25�ɐݒ�
            playerSpeed = 0.025f;
        }

        //�E���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //�E������0.05����
            pos.x += playerSpeed;
        }
        //�����L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //��������0.05����
            pos.x -= playerSpeed;
        }
        //����L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //�������0.05����
            pos.z += playerSpeed;
        }
        //�����L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //��������0.05����
            pos.z -= playerSpeed;
        }

        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    public void Damage()
    {
        //���������ꍇHP��1����
        playerHp--;
        //enemyHp = enemyHp - 1;

        //�m�F�pDebugLog
        Debug.Log("playerHp:" + playerHp);

        if(playerHp <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
