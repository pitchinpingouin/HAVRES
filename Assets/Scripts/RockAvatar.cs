using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAvatar : MonoBehaviour
{
    private long id = -1;
    public int RockNumber;
    private float saveCooldown = 5.00f;
    private float saveTimer = 0.00f;

    private void Start()
    {
        id = FindObjectOfType<GameManager>().GiveRockId();
        
    }
    
    private void SaveOneSelf()
    {

        Vector3 pos = transform.position;
        RockData rockData = new RockData();

        rockData.id = id;
        rockData.RockNumber = RockNumber;
        rockData.X = pos.x;
        rockData.Y = pos.y;
        rockData.Z = pos.z;

        if (!SaveSystem.Data.Rocks.Exists(rock => rock.id == rockData.id))
        {
            Debug.Log("registering current rock: " + rockData.id);
            SaveSystem.Data.Rocks.Add(rockData);
        }
        else
        {
            RockData alreadySavedData = SaveSystem.Data.Rocks.Find(rock => rock.id == rockData.id);
            alreadySavedData.X = rockData.X;
            alreadySavedData.Y = rockData.Y;
            alreadySavedData.Z = rockData.Z;
        }
    }
    
    private void Update()
    {
        if (saveTimer >= saveCooldown)
        {
            SaveOneSelf();
            saveTimer = 0.00f;
        }
        else
        {
            saveTimer += Time.deltaTime;
        }
    }
}
