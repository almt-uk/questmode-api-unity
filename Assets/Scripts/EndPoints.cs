using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoints
{

    //declaring the base url (is made of the domain and at the end contains /v1
    private static readonly string BASE_URL = "https://questmode.000webhostapp.com/v1";
    //since we are in unity we are going to use the unity api
    //the other api's might work too but the api for unity is working 100%
    private static readonly string UNITY_API = "/unity";

    //declaring the links based on the request
    //the final link that retrieves the skills
    public static readonly string GET_SKILLS = BASE_URL + UNITY_API + "/get/skills";

}
