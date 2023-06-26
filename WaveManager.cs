using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class WaveManager : MonoBehaviour
{
    [SerializeField] List<Wave> waveList;       // ウェーブリスト
    [SerializeField] List<Wave> cloneList = new List<Wave>();    // クローンリスト
    int cloneIndex = 0;                         // クローン番号
    bool listEnd = false;                       // 終了フラグ

    //現在のリスト
    public ReactiveProperty<int> currentWaveClearCnt = new();//指定Waveにおける現時点でのクリア数
    public ReactiveProperty<int> currentWaveGoalCnt = new();//指定Waveにおけるゴール数
    public ReactiveProperty<int> waveIndex = new(0);

    //TODO
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        StartWave(waveIndex.Value);
    }

    void Update()
    {
        if (waveList.Count <= 0 || IsEnd()) return;
        // ウェーブが終わった
        if (cloneList[cloneIndex].IsEnd())
        {
            // 次のウェーブへ
            NextWave();
        }
    }

    // ウェーブ開始
    void StartWave(int _index)
    {
        var tmp = (Wave)Instantiate(waveList[_index]);
        tmp.waveManager = this;
        tmp.gameManager = gameManager;//TODO
        currentWaveGoalCnt.Value = tmp.goalCnt;
        cloneList.Add(tmp);
    }

    // 次のウェーブへ
    void NextWave()
    {
        currentWaveClearCnt.Value = 0;
        if (waveIndex.Value < (waveList.Count - 1))
        {
            ++waveIndex.Value;
            ++cloneIndex;
            StartWave(waveIndex.Value);
        }
        else
        {
            listEnd = true;
        }
    }

    // 全てのウェーブが終了したか
    public bool IsEnd()
    {
        return listEnd;
    }
}
