using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    private GameData gameData;
    public static DataPersistanceManager instance { get; private set; }
    private List<IDataPersistance> dataPersistanceObjects;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistance Manager in this scene.");
        }
        instance = this;
    }
    private void Start()
    {
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }
    public GameData GetGameData()
    {
        return gameData;
    }


    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {


        if(this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }

        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }

        Debug.Log("Loaded Game.");
    }
    public void SaveGame()
    {
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }
        Debug.Log("Saved Game");
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
