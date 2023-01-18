using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShot : MonoBehaviour
{
    public GameObject prefab;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //プレハブ化した球をセット
        //    GameObject ball = GameObject.Instantiate(prefab) as GameObject;
        //    //マウスクリックした地点に球を飛ばす
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    Vector3 dir = ray.direction;
        //    //球に力を加える
        //    ball.GetComponent<Rigidbody>().AddForce(dir * 2000);
        //}

        count += 1;

        // ６０フレームごとに砲弾を発射する
        if (count % 420 == 0)
        {
            GameObject shell = Instantiate(prefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            // 弾速は自由に設定
            shellRb.AddForce(transform.forward * 1000);

            //// 発射音を出す
            //AudioSource.PlayClipAtPoint(sound, transform.position);

            // ５秒後に砲弾を破壊する
            Destroy(shell, 5.0f);
        }
    }
}
