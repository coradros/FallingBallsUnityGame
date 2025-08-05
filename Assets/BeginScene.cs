using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BeginScene : MonoBehaviour
{
    // Start is called before the first frame update
    public static void NextLevel()
    {
        int GlobalLevel = Basic.ReadLevel();

        if (File.Exists(Application.persistentDataPath + "DeletedLevels"))
        {
            string[] deletedLevels = File.ReadAllLines(Application.persistentDataPath + "DeletedLevels");
            if (deletedLevels.Length == 50)
            {
                Basic.WriteLevel(GlobalLevel + 1);
                File.Delete(Application.persistentDataPath + "DeletedLevels");


                File.Delete(Application.persistentDataPath + "DeletedLevels");

                File.Delete(Application.persistentDataPath + "Labirinth");
                File.Delete(Application.persistentDataPath + "Labirinth" + "_key");
                CleareLevel();
            }
        }
    }

    // Update is called once per frame
    public static void CleareLevel()
    {
        int GlobalLevel = Basic.ReadLevel();

        for (int i = 0; i < 100; i++)
        {
            string fn = Application.persistentDataPath+ GlobalLevel.ToString() + "__" + i.ToString();
            if (File.Exists(fn))
            {
                File.Delete(fn);
            }
        }
    }
}
