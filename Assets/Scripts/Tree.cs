﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public int State;

    private void Start()
    {
        

        Vector3 pos = transform.position;
        TreeData treeData = new TreeData();
        treeData.State = this.State;
        
        treeData.X = pos.x;
        treeData.Y = pos.y;
        treeData.Z = pos.z;

        if (State > 3)
        {
            SaveSystem.Data.Trees.Remove(treeData);
            return;
        }
        else if (!SaveSystem.Data.Trees.Exists(tree => tree.X == treeData.X && tree.Z == treeData.Z))
        {
            SaveSystem.Data.Trees.Add(treeData);
        }
        else
        {
            TreeData alreadySavedData = SaveSystem.Data.Trees.Find(tree => (tree.X == treeData.X && tree.Z == treeData.Z));
            alreadySavedData.State = treeData.State;
            alreadySavedData.Y = treeData.Y;
        }
    }

}