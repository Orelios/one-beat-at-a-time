using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class PlayerData : Singleton<PlayerData>
{
    public bool isNewGame = false;
    public float startMentalHealth;
    public float mentalHealth;
    public float maxMentalHealth;
    public float startProductivity;
    public float productivity;
    public float maxProductivity;
    public float startAcademics;
    public float academics;
    public float maxAcademics;
    public float timeslot;
    public int day;
    public int overworldScene;
    public int skipCount;
    public int day1Loaded = 0, day2Loaded = 0, day3Loaded = 0, day4Loaded = 0, day5Loaded = 0; //should be remade into a list of bools later
    //public List<bool> daysLoaded = new List<bool> {new bool ;
    //public float defaultNoteSpeed;
    //public float offsetPos;
    //public float offsetNoteSpeed;

    public void Save()
    {
        JSONObject playerDataJson = new JSONObject();
        playerDataJson.Add("keyStartMentalHealth", startMentalHealth);
        playerDataJson.Add("keyMentalHealth", mentalHealth);
        playerDataJson.Add("keyMaxMentalHealth", maxMentalHealth);
        playerDataJson.Add("keyStartProductivity", startProductivity);
        playerDataJson.Add("keyProductivity", productivity);
        playerDataJson.Add("keyMaxProductivity", maxProductivity);
        playerDataJson.Add("keyStartAcademics", startAcademics);
        playerDataJson.Add("keyAcademics", academics);
        playerDataJson.Add("keyMaxAcademics", maxAcademics);
        playerDataJson.Add("keyTimeslot", timeslot);
        playerDataJson.Add("keyDay", day);
        playerDataJson.Add("keyOverworldScene", overworldScene);
        playerDataJson.Add("keySkipCount", skipCount);
        playerDataJson.Add("keyDay1Loaded", day1Loaded);
        playerDataJson.Add("keyDay2Loaded", day2Loaded);
        playerDataJson.Add("keyDay3Loaded", day3Loaded);
        playerDataJson.Add("keyDay4Loaded", day4Loaded);
        playerDataJson.Add("keyDay5Loaded", day5Loaded);
        //playerDataJson.Add("keyDefaultNoteSpeed", defaultNoteSpeed);
        //playerDataJson.Add("keyOffsetPos", offsetPos);
        //playerDataJson.Add("keyOffsetNoteSpeed", offsetNoteSpeed);

        //POSITION
        JSONArray position = new JSONArray();
        position.Add(transform.position.x);
        position.Add(transform.position.y);
        position.Add(transform.position.z);
        playerDataJson.Add("Position", position);

        //SAVE JSON IN COMPUTER
        string path = Application.persistentDataPath + "/PlayerDataSave.json";
        File.WriteAllText(path, playerDataJson.ToString());
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/PlayerDataSave.json";
        string jsonString = File.ReadAllText(path);
        JSONObject playerDataJson = (JSONObject)JSON.Parse(jsonString);

        //SET VALUES
        startMentalHealth = playerDataJson["keyStartMentalHealth"];
        mentalHealth = playerDataJson["keyMentalHealth"];
        maxMentalHealth = playerDataJson["keyMaxMentalHealth"];
        startProductivity = playerDataJson["keyStartProductivity"];
        productivity = playerDataJson["keyProductivity"];
        maxProductivity = playerDataJson["keyMaxProductivity"];
        startAcademics = playerDataJson["keyStartAcademics"];
        academics = playerDataJson["keyAcademics"];
        maxAcademics = playerDataJson["keyMaxAcademics"];
        timeslot = playerDataJson["keyTimeslot"];
        day = playerDataJson["keyDay"];
        overworldScene = playerDataJson["keyOverworldScene"];
        skipCount = playerDataJson["keySkipCount"];
        day1Loaded = playerDataJson["keyDay1Loaded"];
        day2Loaded = playerDataJson["keyDay2Loaded"];
        day3Loaded = playerDataJson["keyDay3Loaded"];
        day4Loaded = playerDataJson["keyDay4Loaded"];
        day5Loaded = playerDataJson["keyDay5Loaded"];
        //defaultNoteSpeed = playerDataJson["keyDefaultNoteSpeed"];
        //offsetPos = playerDataJson["keyOffsetPos"];
        //offsetNoteSpeed = playerDataJson["keyOffsetNoteSpeed"];

        //POSITION
        transform.position = new Vector3(
            playerDataJson["Position"].AsArray[0],
            playerDataJson["Position"].AsArray[1],
            playerDataJson["Position"].AsArray[2]
        );

        //UPDATE BARS
        MentalHealthBar.Instance.UpdateBar();
        ProductivityBar.Instance.UpdateBar();
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (isNewGame == true)
        {
            //no loading
            Save();
        }
        else
        {
            Load();
            //transform.position = new Vector3(-1.44f, 1.89f, -1.17f);
            Time.timeScale = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddMentalHealth(float x)
    {
        mentalHealth += x;
        if (mentalHealth > maxMentalHealth)
        {
            mentalHealth = maxMentalHealth;
        }
        if (mentalHealth < 0)
        {
            mentalHealth = 0;
        }
    }

    public void AddProductivity(float y)
    {
        productivity += y;
        if (productivity > maxProductivity)
        {
            productivity = maxProductivity;
        }
        if (productivity < 0)
        {
            productivity = 0;
        }
    }

    public void AddTimeslot(float z)
    {
        timeslot += z;
        if (timeslot < 0)
        {
            timeslot = 0;
        }
    }

    public void ResetTimeSlot()
    {
        timeslot = 0;
    }

    public void IncrementOverworldScene()
    {
        overworldScene += 1;
    }

    public void IncrementSkipCount()
    {
        skipCount += 1;
    }
}
