using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Server : SocketServer {
    public string host = "127.0.0.1";
    public int port = 17266;
    public GameObject ncFactory;

    void start() {
        base.listen(host, port);
    }

    protected override void OnMessage(string msg) {
        Debug.Log(msg);
        // ここにそけっとつーしんかく
        var i = 0;
        var list = new List<string>();
        while (msg.Length >= i) {
            var i2 = msg.IndexOf("|", i);
            if (i2 == 0)
                i2 = msg.Length;
            list.Add(msg.Substring(i, i2));
            i = i2;
        }

        var items = new List<Tuple<string, string>>();
        foreach (String p in list) {
            var pi = p.IndexOf("/");
            items.Add(Tuple.Create(p.Substring(0, pi), p.Substring(pi + 1, p.Length)));
        }


        //itemsに名詞と説明が対になってるデータがあります
        // Usage(名詞): items[ここ数].Item1
        // Usage(説明): items[ここ数].Item2

        // ここでカードを生成
        for (int j = 0; j < items.Count; j++) {
            ncFactory.GetComponent<NC_Factory>().ncInstantiate(items[j].Item1,items[j].Item2);
        }

    }
}