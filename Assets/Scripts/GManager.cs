using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    private GameObject[] enemy;
    private GameObject bossEnemy;
    public GameObject clearText;
    public GameObject retryButton;
    // Start is called before the first frame update
    void Start()
    {
        //FPS�ƃX�N���[���T�C�Y�̐ݒ�
        Screen.SetResolution(1920, 1080, false);
        Application.targetFrameRate = 60;

        //�J�n���ɂ͉B���Ă���
        clearText.SetActive(false);
        retryButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy�^�O���������z��enemy�Ƃ��ēo�^
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        bossEnemy = GameObject.FindGameObjectWithTag("BossEnemy");


        //enemy���S�����Ȃ��Ȃ�AbossEnemy���|������(=bossEnemy��null�ɂȂ�����)
        /*�����ȂƂ���A�ubossEnemy��|������ϐ��̒l����0�ɂȂ�́H�v���Ďv����
         DebugLog��ݒ肵�Ċm�F�����牽�����������̂�
        �u���A����null�ɂȂ�񂾁v�Ƃ����׋��ɂȂ�܂����B*/
        if (enemy.Length == 0 && bossEnemy==null)
        {
            //clearText��reryButton��\��
            clearText.SetActive(true);
            retryButton.SetActive(true);
        }
    }

    //�ȉ� KorokoroBall GameManager.cs��藬�p

    //�V�[�����Z�b�g
    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }

    //�V�[���؂�ւ�
    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    //�ȉ��̓{�^����������SE�p
    public void ChangeSceneWait(string nextScene)
    {
        StartCoroutine(changeSceneCoroutine(nextScene));
    }
    private IEnumerator changeSceneCoroutine(string nextScene)
    {
        yield return new WaitForSeconds(1);
        ChangeScene(nextScene);
    }
    //������Ɖ��p ���Z�b�g�ŉ���炵�Ă݂�
    public void ResetSceneWait()
    {
        StartCoroutine(resetSceneCoroutine());
    }
    private IEnumerator resetSceneCoroutine()
    {
        yield return new WaitForSeconds(1);
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }
}
