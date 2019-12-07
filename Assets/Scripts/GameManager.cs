using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class GameManager : MonoBehaviour
{
    public GameObject treePrefabState1;
    public GameObject treePrefabState2;
    public GameObject treePrefabState3;

    public double saveInterval;
    private Timer saveTimer;

    private void Awake()
    {
        SaveData data = SaveSystem.Load(); // make the SaveSystem initialize it's data and collect it
        foreach (TreeData tree in data.Trees)
        {
            GameObject treePrefab;
            float yOffset;
            tree.State++;
            switch (tree.State)
            {
                case 1:
                    treePrefab = treePrefabState1;
                    yOffset = 0.0f;
                    break;
                case 2:
                    treePrefab = treePrefabState2;
                    yOffset = 0.5f;
                    break;
                case 3:
                    treePrefab = treePrefabState3;
                    yOffset = 1.5f;
                    break;
                default:
                    treePrefab = treePrefabState3;
                    yOffset = 0.0f;
                    break;
            }

            Instantiate(treePrefab, new Vector3(tree.X, tree.Y + yOffset, tree.Z), Quaternion.identity);
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
        SaveSystem.Save();

    }    
}
