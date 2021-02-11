using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

// ReadFile.cs
// Manuel Varela

public class ReadFile : MonoBehaviour
{
    [Serializable]
    public class Table
    {
        public string Title;
        public string[] ColumnHeaders;
        public Dictionary<string, string>[] Data;
    }

    public Table table;

    public GameObject columnPrefab;
    public GameObject columnGroup;

    public TextAsset textAsset;
    public string jason;

    public Text title;
    public Text[] columns;

    public Text column0;
    public Text column1;
    public Text column2;
    public Text column3;

    private string path;
    
    void Start()
    {
        path = Application.streamingAssetsPath + "/JsonChallenge.json";
        jason = File.ReadAllText(path);

        title.text = path;
        
        Table newTable = JsonConvert.DeserializeObject<Table>(jason);
        table = newTable;

        title.text = table.Title;

        for (int i = 0; i < table.ColumnHeaders.Length; i++)
        {
            GameObject newColumn = Instantiate(columnPrefab);
            newColumn.transform.SetParent(columnGroup.transform);
            
            string columnTitle = table.ColumnHeaders[i];

            Text text = newColumn.GetComponent<Text>();
            text.text = "<b>" + columnTitle + "</b>\n";
            
            for (int j = 0; j < table.Data.Length; j++)
            {
                text.text += "\n" + table.Data[j][columnTitle];
            }
        }
    }
}
