using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class PlayerData : Singleton<PlayerData>
{
    public bool isNewGame = false;
    public float mentalHealth;
    public float maxMentalHealth;
    public float productivity;
    public float maxProductivity;
    public float academics;
    public float maxAcademics;
    public float timeRemaining;

    public void Save()
    {
        JSONObject playerDataJson = new JSONObject();
        playerDataJson.Add("keyMentalHealth", mentalHealth);
        playerDataJson.Add("keyProductivity", productivity);
        playerDataJson.Add("keyAcademics", academics);
        playerDataJson.Add("keyTimeRemaining", timeRemaining);
        playerDataJson.Add("keyMaxMentalHealth", maxMentalHealth);
        playerDataJson.Add("keyMaxProductivity", maxProductivity);
        playerDataJson.Add("keyMaxAcademics", maxAcademics);

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
        mentalHealth = playerDataJson["keyMentalHealth"];
        productivity = playerDataJson["keyProductivity"];
        academics = playerDataJson["keyAcademics"];
        timeRemaining = playerDataJson["keyTimeRemaining"];
        maxMentalHealth = playerDataJson["keyMaxMentalHealth"];
        maxProductivity = playerDataJson["keyMaxProductivity"];
        maxAcademics = playerDataJson["keyMaxAcademics"];

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
        }
        else
        {
            Load();
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

    public void AddTimeRemaining(float z)
    {
        timeRemaining += z;
        if (timeRemaining < 0)
        {
            timeRemaining = 0;
        }
    }
}
