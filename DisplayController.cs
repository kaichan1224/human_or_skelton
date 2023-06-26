using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;

public class DisplayController : MonoBehaviour
{
    [SerializeField] TMP_Text curretClearCnt;
    [SerializeField] TMP_Text curretGoalCnt;
    [SerializeField] TMP_Text wave;
    [SerializeField] private WaveManager waveManager;
    void Start()
    {
        waveManager.currentWaveClearCnt.
            Subscribe(x => curretClearCnt.text = x.ToString())
            .AddTo(this);
        waveManager.currentWaveGoalCnt.
            Subscribe(x => curretGoalCnt.text = x.ToString())
            .AddTo(this);
        waveManager.waveIndex.
            Subscribe(x =>
            {
                string tmp;
                switch (x+1)
                {
                    case 1:
                        tmp = "壱";
                        break;
                    case 2:
                        tmp = "弐";
                        break;
                    case 3:
                        tmp = "参";
                        break;
                    case 4:
                        tmp = "肆";
                        break;
                    case 5:
                        tmp = "伍";
                        break;
                    case 6:
                        tmp = "陸";
                        break;
                    case 7:
                        tmp = "柒";
                        break;
                    case 8:
                        tmp = "捌";
                        break;
                    case 9:
                        tmp = "玖";
                        break;
                    case 10:
                        tmp = "什";
                        break;
                    default:
                        tmp = "";
                        break;
                }
                wave.text = tmp;
            })
            .AddTo(this);
    }
}
