using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// �w�肵�����̃Q�[���I�u�W�F�N�g���C���X�^���X������X�N���v�g�ł��B
/// </Summary>
public class PrehabMaster : MonoBehaviour
{
    // �C���X�^���X������Prefab�I�u�W�F�N�g���A�T�C�����܂��B
    public GameObject prefab;

    // �e�I�u�W�F�N�g�̃g�����X�t�H�[�����A�T�C�����܂��B
    public Transform parentTran;

    // �Q�[���I�u�W�F�N�g�𐶐����鐔���w�肵�܂��B
    public int prefabNum;

    //[SerializeField] GameObject PrehabMaster;

    void Start()
    {
        //InstantiatePrefab();
        DontDestroyOnLoad(this.gameObject);
    }

    /// <Summary>
    /// �Q�[���I�u�W�F�N�g��Prefab����쐬���鏈���ł��B
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
