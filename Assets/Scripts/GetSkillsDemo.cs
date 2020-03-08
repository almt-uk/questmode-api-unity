using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSkillsDemo : MonoBehaviour
{
    
	// Use this for initialization
	void Start () {
        
        GetSkills mGetSkills = new GetSkills();
        mGetSkills.setApiKey("");
        mGetSkills.setApiPassword("");
        mGetSkills.setUserID(737353637);
        StartCoroutine(mGetSkills.RequestCheckApi((mSkillsModelDB) => {
            print(mSkillsModelDB.skills);

        }));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
