using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// 指定した数のゲームオブジェクトをインスタンス化するスクリプトです。
/// </Summary>
public class PrehabMaster : MonoBehaviour
{
    // インスタンス化するPrefabオブジェクトをアサインします。
    public GameObject prefab;

    // 親オブジェクトのトランスフォームをアサインします。
    public Transform parentTran;

    // ゲームオブジェクトを生成する数を指定します。
    public int prefabNum;

    //[SerializeField] GameObject PrehabMaster;

    void Start()
    {
        //InstantiatePrefab();
        DontDestroyOnLoad(this.gameObject);
    }

    /// <Summary>
    /// ゲームオブジェクトをPrefabから作成する処理です。
    /// </Summary>
    void InstantiatePrefab()
    {
        //for (int i = 0; i < prefabNum; i++)
        //{
            //GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            //obj.transform.SetParent(parentTran);
            //obj.transform.position = new Vector3(i, 0f, 0f);
        //}
    }
}
