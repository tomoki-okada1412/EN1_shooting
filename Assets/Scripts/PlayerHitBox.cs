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
        //親のゲームオブジェクトを指す
        parent = transform.parent.gameObject;

        //当たってきたら、自分の親(Player)に処理を任せる
        parent.GetComponent<PlayerMove>().Damage();
    }
}
