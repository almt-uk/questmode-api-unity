using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSkillsDemo : MonoBehaviour
{

    //declaring the skills list
    //we must initialize it to make sure that is not null
    public List<SkillModel> skills = new List<SkillModel> { };
    // Use this for initialization
    void Start () {
        
        //initialize the class
        GetSkills mGetSkills = new GetSkills();
        //setting the api key
        mGetSkills.setApiKey("");
        //setting the api password
        mGetSkills.setApiPassword("");
        //setting the user id
        mGetSkills.setUserID(737353637);
        //calling the classing and waiting for the response
        //must use coroutine because we don't know exactly when the data will be retrieved
        StartCoroutine(mGetSkills.RequestCheckApi((mSkillsModelDB) => {
            //the data is retrieved using the SkillsModel Object - class model
            //assuring that we retrieved succesfully we must check for errors first
            if(mSkillsModelDB.error)
            {
                //error
                Debug.Log("error on retrieving data");
                return;
            }
            else
            {
                //getting the data from the model and storing it into the class
                skills = mSkillsModelDB.getSkills();
                //simple method to show how to get the skills from array
                gettingSkills();
            }

        }));
    }

    //methid that is printing the skill name and class
    void gettingSkills()
    {
        foreach (SkillModel skill in skills)
        {
            Debug.Log("Skill Name: " + skill.name);
            Debug.Log("Skill Class: " + skill.class_type);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
