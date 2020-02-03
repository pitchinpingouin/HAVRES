using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashAvatar : MonoBehaviour
{
    public int ttl; // time to live

    private void Start()
    {
        Vector3 pos = transform.position;
        Vector3 rot = transform.rotation.eulerAngles;
        FruitSplashData splashData = new FruitSplashData();

        splashData.ttl = ttl;
        splashData.X = pos.x;
        splashData.Y = pos.y;
        splashData.Z = pos.z;
        splashData.RotX = rot.x;
        splashData.RotY = rot.y;
        splashData.RotZ = rot.z;

        if (ttl <= 0)
        {
            if (!SaveSystem.Data.Splashes.Exists(splash => splash.X == splashData.X && splash.Z == splashData.Z))
                Debug.LogError("Cannot remove splash! Splash doesn't exist in the saveData");

            FruitSplashData alreadySavedData = SaveSystem.Data.Splashes.Find(splash => splash.X == splashData.X && splash.Z == splashData.Z);

            SaveSystem.Data.Splashes.Remove(alreadySavedData);
        }
        else if (!SaveSystem.Data.Splashes.Exists(splash => splash.X == splashData.X && splash.Z == splashData.Z))
        {
            SaveSystem.Data.Splashes.Add(splashData);
        }
        else
        {
            FruitSplashData alreadySavedData = SaveSystem.Data.Splashes.Find(splash => splash.X == splashData.X && splash.Z == splashData.Z);
            alreadySavedData.ttl = splashData.ttl;
        }
    }

}
