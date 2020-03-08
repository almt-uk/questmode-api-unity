﻿using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SkillModel
{
    public int skill_id;
    public string name;
    public int class_type;
    public int row;
}

public class SkillsModel
{

    public bool error;
    public List<SkillModel> skills = new List<SkillModel> { };

}

public class GetSkills
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    string api_key = "null";
    string api_password = "null";
    string user_id = "null";

    internal void setApiKey(string apiKey)
    {
        this.api_key = apiKey;
    }

    internal void setApiPassword(string apiPassword)
    {
        this.api_password = apiPassword;
    }

    internal void setUserID(int userId)
    {
        this.user_id = userId.ToString();
    }

    public IEnumerator RequestCheckApi(System.Action<SkillsModel> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("api_key", api_key);
        form.AddField("api_password", api_password);
        form.AddField("user_id", user_id);
        string domainApiPrefix = "https://questmode.000webhostapp.com/v1";

        using (UnityWebRequest www = UnityWebRequest.Post(domainApiPrefix + "/unity/get/skills", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                SkillsModel mSkillsModel = new SkillsModel();
                mSkillsModel.error = true;
                callback(mSkillsModel);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log(responseText);
                SkillsModel mSkillsModel = JsonUtility.FromJson<SkillsModel>(responseText);
                JSONNode data = JSON.Parse(responseText);
                foreach (JSONNode skill in data["skills"])
                {
                    SkillModel mSkillModel = new SkillModel();
                    mSkillModel.skill_id = skill["skill_id"];
                    mSkillModel.name = skill["name"];
                    mSkillModel.class_type = skill["class_type"];
                    mSkillModel.row = skill["row"];
                    mSkillsModel.skills.Add(mSkillModel);
                }
                callback(mSkillsModel);
            }
        }

    }

}
