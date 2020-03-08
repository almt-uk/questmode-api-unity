using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SkillModel
{
    public int skill_id;
    public string name;
    int class_type;
    public int row;

    public string getClass()
    {
        switch (class_type)
        {
            case 0:
                // code block
                return "wizzard";
            case 1:
                // code block
                return "knight";
            default:
                return "unknown";
        }
    }

    public void setClassType(int class_type)
    {
        this.class_type = class_type;
    }
}

public class SkillsModel
{

    public bool error;
    private List<SkillModel> skills = new List<SkillModel> { };

    public List<SkillModel> getSkills()
    {
        return skills;
    }

    public void addSkill(SkillModel skill)
    {
        this.skills.Add(skill);
    }


}

public class GetSkills
{

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

        //making the post request
        using (UnityWebRequest www = UnityWebRequest.Post(EndPoints.GET_SKILLS, form))
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
                    mSkillModel.setClassType(skill["class_type"]);
                    mSkillModel.row = skill["row"];
                    mSkillsModel.addSkill(mSkillModel);
                }
                callback(mSkillsModel);
            }
        }

    }

}
