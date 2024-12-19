using UnityEngine;
using System.IO;
using System;



public class DataLogger : MonoBehaviour
{
    private bool isDataLogged = false;
    public char separator;
    private string finalName;
    public string header;
    private float timeInterval = 1.0f;
    private float timer = 0.0f;
    

    
    void Start()
    {
        InitiateLogFile();
    }

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

        finalName = Path.Combine(directoryPath, $"log{name}-{time}.csv");
        logString(header);

        Debug.Log($"Log file successfully created: {finalName}");
        
    }

    public void LogData(){
        string lineToWrite = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ") 
                             + separator + transform.position.x.ToString()
                             + separator + transform.position.y.ToString()
                             + separator + transform.position.z.ToString();
        logString(lineToWrite);
    }

    public void StartLogging(){
        isDataLogged = !isDataLogged;

        if(isDataLogged == false){
            Debug.Log("I guess I will stop logging for now :(");
        }
        else{
            Debug.Log("I am logging again :)");

        }
    }

}
