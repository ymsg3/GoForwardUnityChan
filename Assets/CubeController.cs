using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        // キューブを移動させる
        transform.Translate (this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy (gameObject);
        }
    }

    // 課題用：
    // このキューブが他のオブジェクトと衝突した時に呼び出される
    private void OnCollisionEnter2D (Collision2D collision)
    {

        // キューブ落下地点付近でなければ何もしない
        if (transform.position.x <= -2.9)
        {
            return;
        }

        // 衝突相手のタグの名前を取得
        string tagName = collision.gameObject.tag;

        // 衝突相手がキューブか地面なら、効果音を再生
        if (tagName =="CubeTag"|| tagName =="GroundTag")
        {
            GetComponent<AudioSource> ().Play ();
        }

    }
}
