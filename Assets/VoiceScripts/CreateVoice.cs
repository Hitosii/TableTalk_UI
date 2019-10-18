using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class CreateVoice : MonoBehaviour
{
    private void Awake() {
        //外部プロセスの設定
        ProcessStartInfo processStartInfo = new ProcessStartInfo() {
            FileName = @"C:\Program Files (x86)\Microsoft Visual Studio\Shared\Python37_64\python.py", //実行するファイル(python)
            UseShellExecute = false,//シェルを使うかどうか
            CreateNoWindow = true, //ウィンドウを開くかどうか
            RedirectStandardOutput = true, //テキスト出力をStandardOutputストリームに書き込むかどうか
            Arguments = @"C:\Users\kotoro\Desktop\tabletalk-sanuki-python-master\webapi.py"
        };

        //外部プロセスの開始
        Process process = Process.Start(processStartInfo);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
