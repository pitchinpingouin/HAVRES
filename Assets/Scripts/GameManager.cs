using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject treePrefabState1;
    public GameObject treePrefabState2;
    public GameObject treePrefabState3;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)] // makes function get called right after the scene is loaded
    void OnStartupInitializations()
    {
        SaveData data = SaveSystem.Load(); // make the SaveSystem initialize it's data and collect it
        foreach (TreeData tree in data.Trees)
        {
            GameObject treePrefab;

            switch (tree.State)
            {
                case 1:
                    treePrefab = treePrefabState1;
                    break;
                case 2:
                    treePrefab = treePrefabState2;
                    break;
                case 3:
                    treePrefab = treePrefabState3;
                    break;
                default:
                    Debug.LogError("Wrong tree state detected");
                    return;
            }

            Instantiate(treePrefab, new Vector3(tree.X, tree.Y, tree.Z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Oculus_CrossPlatform_ButtonY"))
        {
            List<TreeData> treeDatas = new List<TreeData>();
            Tree[] trees = FindObjectsOfType<Tree>();
            foreach (Tree tree in trees)
            {
                // create a treeData object
                Vector3 pos = tree.gameObject.transform.position;
                TreeData treeData = new TreeData();
                treeData.State = tree.State;
                treeData.X = pos.x;
                treeData.Y = pos.y;
                treeData.Z = pos.z;

                treeDatas.Add(treeData);
            }
            SaveSystem.Data.Trees = treeDatas;
            SaveSystem.Save();
        }
    }    
}
