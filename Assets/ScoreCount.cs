using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    //追加する得点
    private int addscore = 0;
    //合計得点（初期値は０）
    private int totalscore = 0;
    //ターゲットのタグ
    private string targettag = "";
    //得点を表示するテキスト
    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //シーンの中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ScoreTextに合計得点を表示
        this.scoreText.GetComponent<Text>().text = totalscore.ToString();
    }

    //ターゲットにボールが衝突した時に呼ばれる関数
    private void OnCollisionEnter(Collision other)
    {
        //変数の初期化
        addscore = 0;    //追加得点
        targettag = "";  //タグ

        //取得したタグを代入
        targettag = other.gameObject.tag;

        //ターゲットの種類によって取得できる点数を変える
        if (targettag == "SmallStarTag")
        {
            addscore = 5;
        }
        else if (targettag == "LargeStarTag")
        {
            addscore = 20;
        }
        else if (targettag == "SmallCloudTag")
        {
            addscore = 1;
        }
        else if (targettag == "LargeCloudTag")
        {
            addscore = 10;
        }

        //合計得点に追加得点を加算する
        //Debug.Log("計算前：" + targettag  + "に衝突。"+ totalscore + "+" + addscore);
        totalscore += addscore;
        //Debug.Log("計算後：" + totalscore);

    }
}
