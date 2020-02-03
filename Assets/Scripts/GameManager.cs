using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class GameManager : MonoBehaviour
{
    public GameObject treePrefabState1;
    public GameObject treePrefabState2;
    public GameObject treePrefabState3;

    public List<GameObject> rockPrefabs;

    public GameObject woodLogPrefab;

    public GameObject splashPrefab;

    public double saveInterval;
    private Timer saveTimer;

    private long nextRockId = 0;
    private long nextLogId = 0;

    private void Awake()
    {
        SaveData data = SaveSystem.Load(); // make the SaveSystem initialize it's data and collect it
        foreach (TreeData tree in data.Trees)
        {
            GameObject treePrefab;
            tree.State++;
            switch (tree.State)
            {
                case 1:
                    treePrefab = treePrefabState1;
                    break;
                case 2:
                    treePrefab = treePrefabState2;
                    break;
                default:
                    treePrefab = treePrefabState3;
                    break;
            }

            GameObject instance = Instantiate(treePrefab, new Vector3(tree.X, tree.Y, tree.Z), Quaternion.identity);
            instance.GetComponent<TreeAvatar>().State = tree.State;
        }

        foreach (FruitSplashData splash in data.Splashes)
        {
            splash.ttl--;
            GameObject instance = Instantiate(splashPrefab, new Vector3(splash.X, splash.Y, splash.Z), Quaternion.Euler(new Vector3(splash.RotX, splash.RotY, splash.RotZ)));
            instance.GetComponent<SplashAvatar>().ttl = splash.ttl;
        }

        foreach (RockData rock in data.Rocks)
        {
            Instantiate(rockPrefabs[rock.RockNumber - 1], new Vector3(rock.X, rock.Y, rock.Z), Quaternion.identity);
        }

        foreach (WoodLogData log in data.WoodLogs)
        {
            Instantiate(woodLogPrefab, new Vector3(log.X, log.Y, log.Z), Quaternion.identity);
        }
    }

    private void Start()
    {
        saveTimer = new Timer(saveInterval * 1000.0); // set a new timer with 30 seconds interval
        saveTimer.Elapsed += SaveProgression; // hook our SaveProgression method to the Timer.Elapsed event
        saveTimer.AutoReset = true; // let the timer trigger it's Elapsed event periodically
        saveTimer.Enabled = true; // start the timer
    }

    private static void SaveProgression(object source, ElapsedEventArgs e)
    {
        Debug.Log("Saving " + SaveSystem.Data.Trees.Count + " trees");
        Debug.Log("Saving " + SaveSystem.Data.Rocks.Count + " rocks");
        Debug.Log("Saving " + SaveSystem.Data.WoodLogs.Count + " wood logs");
        SaveSystem.Save();
    }

    private void OnApplicationQuit()
    {
        saveTimer.Dispose();
    }

    public long GiveRockId()
    {
        long returnValue = nextRockId;
        nextRockId++;
        return returnValue;
    }

    public long GiveLogId()
    {
        long returnValue = nextLogId;
        nextLogId++;
        return returnValue;
    }
}
