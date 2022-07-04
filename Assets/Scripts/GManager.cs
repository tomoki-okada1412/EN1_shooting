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
        //FPSとスクリーンサイズの設定
        Screen.SetResolution(1920, 1080, false);
        Application.targetFrameRate = 60;

        //開始時には隠しておく
        clearText.SetActive(false);
        retryButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Enemyタグを持った奴をenemyとして登録
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        bossEnemy = GameObject.FindGameObjectWithTag("BossEnemy");


        //enemyが全部いなくなり、bossEnemyも倒したら(=bossEnemyがnullになったら)
        /*正直なところ、「bossEnemyを倒したら変数の値って0になるの？」って思って
         DebugLogを設定して確認したら何も無かったので
        「あ、これnullになるんだ」という勉強になりました。*/
        if (enemy.Length == 0 && bossEnemy==null)
        {
            //clearTextとreryButtonを表示
            clearText.SetActive(true);
            retryButton.SetActive(true);
        }
    }

    //以下 KorokoroBall GameManager.csより流用

    //シーンリセット
    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }

    //シーン切り替え
    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    //以下はボタン押下時のSE用
    public void ChangeSceneWait(string nextScene)
    {
        StartCoroutine(changeSceneCoroutine(nextScene));
    }
    private IEnumerator changeSceneCoroutine(string nextScene)
    {
        yield return new WaitForSeconds(1);
        ChangeScene(nextScene);
    }
    //ちょっと応用 リセットで音を鳴らしてみる
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
