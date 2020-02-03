using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodLogAvatar : MonoBehaviour
{
    private long id = -1;
    private float saveCooldown = 3.00f;
    private float saveTimer = 0.00f;

    void Start()
    {
        id = FindObjectOfType<GameManager>().GiveLogId();
    }

    private void SaveOneSelf()
    {
        Vector3 pos = transform.position;
        WoodLogData woodLogData = new WoodLogData();

        woodLogData.id = id;
        woodLogData.X = pos.x;
        woodLogData.Y = pos.y;
        woodLogData.Z = pos.z;

        if (!SaveSystem.Data.WoodLogs.Exists(log => log.id == woodLogData.id))
        {
            Debug.Log("registering current log: " + woodLogData.id);
            SaveSystem.Data.WoodLogs.Add(woodLogData);
        }
        else
        {
            WoodLogData alreadySavedData = SaveSystem.Data.WoodLogs.Find(log => log.id == woodLogData.id);
            alreadySavedData.X = woodLogData.X;
            alreadySavedData.Y = woodLogData.Y;
            alreadySavedData.Z = woodLogData.Z;
        }
    }

    void Update()
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

    private void OnDestroy()
    {
        WoodLogData alreadySavedData = SaveSystem.Data.WoodLogs.Find(log => log.id == id);
        SaveSystem.Data.WoodLogs.Remove(alreadySavedData);
    }
}
