using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Wave : MonoBehaviour
{
    [System.Serializable]
    struct ObjData
    {
        public int generateFrame;
        public GameObject waveObj;
        public Vector3 generatePlace;
    }

    [SerializeField] List<ObjData> objList;     // オブジェクトリスト
    [SerializeField] int nowObj = 0;                             // 今のオブジェクト
    public int goalCnt = 0;//目標のゴール数
    public WaveManager waveManager;
    public GameManager gameManager;

    int frame = 0;
    [SerializeField] bool waveEnd = false;

    void Update()
    {
        if (waveEnd) return;//ウェーブ終わったら終了
        if (nowObj == objList.Count)//これ以上増えたら生成するのを終了.
            return;
        if(frame >= objList[nowObj].generateFrame)
        {
            var tmp = Instantiate(objList[nowObj].waveObj, objList[nowObj].generatePlace,Quaternion.identity);
            tmp.GetComponent<CharacterManager>().waveManager = waveManager;
            tmp.GetComponent<CharacterManager>().gameManager = gameManager;
            frame = 0;
            nowObj++;
        }
        ++frame;
        waveEnd = IsEnd();
    }


    // ウェーブ終了
    public bool IsEnd()
    {
        if (waveManager.currentWaveClearCnt.Value == goalCnt)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
