using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSkillsDemo : MonoBehaviour
{
    
	// Use this for initialization
	void Start () {
        
        GetSkills mGetSkills = new GetSkills();
        mGetSkills.setApiKey("xtoAkWqVGp4nDtW6tZL1AaJUCl9I3tYcqjfTBhSu");
        mGetSkills.setApiPassword("PHZ7dh4vHtbJoF7kD2RtZQUxi3opTFeXvpa0Jp7R");
        mGetSkills.setUserID(737353637);
        StartCoroutine(mGetSkills.RequestCheckApi((mSkillsModelDB) => {
            print(mSkillsModelDB.skills);

        }));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
