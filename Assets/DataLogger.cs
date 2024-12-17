using UnityEngine;
using System.IO;
using System;



public class DataLogger : MonoBehaviour
{
    private bool isDataLogged = false;
    public char separator;
    public string fileName;
    private string finalName;
    public string header;
    public Transform objectToTrack; 
    private float timeInterval = 1.0f;
    private float timer = 0.0f;
    

    
    void Start()
    {
        InitiateLogFile();
    }

    // Update is called once per frame
    void Update()
    {   

        if (isDataLogged) 
        {
            timer += Time.deltaTime;
            if (timer >= timeInterval)
            {
                LogData();
                timer = 0f; 
            }
        }
       
    }

    public void logString(string newline)
    {
        using (StreamWriter writer = new StreamWriter(finalName, append: true))
        {
            writer.WriteLine(newline);
        }
    }

    public void InitiateLogFile() { 
        string time = DateTime.UtcNow.ToString("yyyy-MM-ddTHH-mm-ssZ"); 
        string directoryPath = Path.Combine(Application.persistentDataPath, "Data");

        Directory.CreateDirectory(directoryPath);

        if (!Directory.Exists(directoryPath))
        {
            Debug.LogError("Directory creation failed");
            return;
        }

        finalName = Path.Combine(directoryPath, $"{fileName}-{time}.csv");
        if (!File.Exists(finalName))
        {
            File.WriteAllText(finalName, header + Environment.NewLine);
        }

        isDataLogged = true;
        Debug.Log($"Log file successfully created: {finalName}");
        
    }

    public void LogData(){
        string lineToWrite = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ") + separator + objectToTrack.position.x + separator + objectToTrack.position.y + separator + objectToTrack.position.z;
        logString(lineToWrite);
    }

    public void StartLogging(){
        isDataLogged = true;
    }

    public void StopLogging(){
        isDataLogged = false;
    }
}
