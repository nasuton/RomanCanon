using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using MiniJSON;

class TestJsonReader : MonoBehaviour
{
    void Start()
    {
        var textAsset = Resources.Load("JsonFile/Test") as TextAsset;
        var jsonText = textAsset.text;
        Dictionary<string, object> json = Json.Deserialize(jsonText) as Dictionary<string, object>;

        for (int customNum = 0; customNum < 5; ++customNum)
        {
            Dictionary<string, object> json2 = json["Custom" + customNum.ToString()] as Dictionary<string, object>;
            for (int partsNum = 0; partsNum < 4;++partsNum)
            {
                Dictionary<string, object> json3 = json2["Parts" + partsNum.ToString()] as Dictionary<string, object>;
                IList temp = (IList)json3["status"];

                var obj = Resources.Load("GunPartsStatus/Weapon0" + "/Custom" + customNum.ToString()
                                         + "/Parts" + partsNum.ToString()) as GameObject;

                var status = obj.GetComponent<NormalPartsStatus>();

                for (int i = 0; i < 5; ++i)
                {
                    status.Status[i] = (float)((double)temp[i]);
                }
            }
        }
    }

}

