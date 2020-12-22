using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem {

    public static void SavePlayer(SimpleSampleCharacterControl player) {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SaveGameData.hehe";
        FileStream stream = new FileStream(path, FileMode.Create);

        playerdata data = new playerdata(player);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static playerdata Loadplayer()
    {
        string path = Application.persistentDataPath + "/SaveGameData.hehe";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            playerdata data = formatter.Deserialize(stream) as playerdata;
            stream.Close();
            return data;
        }
        else {
            Debug.LogError("file not found " + path);
            return null;
        }

    }


}
