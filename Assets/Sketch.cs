using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour
{
    public GameObject myPrefab;
    // Put your URL here
    public string _WebsiteURL = "http://infosys320labtest01.azurewebsites.net/tables/Birds?zumo-api-version=2.0.0";

    void Start()
    {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        Birds[] birds = JsonReader.Deserialize<Birds[]>(jsonResponse);

        int totalCubes = birds.Length;
        int totalDistance = 5;
        int i = 0;
        float xlocation = -40.0f;
        float zlocation = 2.0f;
        //We can now loop through the array of objects and access each object individually
        foreach (Birds bird in birds)
        {
            //Example of how to use the object
            Debug.Log("This object name is: " + bird.CommonName);
            float perc = i / (float)totalCubes;
            i++;

            

            float x = xlocation;
            xlocation += 3.0f;
            float y = 1.0f;
            float z = zlocation;
            
            if (i < birds.Length / 2)
            {
                zlocation -= i + 1.8f;
            }

            else if (i == birds.Length / 2)
            {
                zlocation -= i + 0.0f;
            }

                else
            { zlocation += i - 2.0f; }

            GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            newCube.GetComponent<myCubeScript>().setSize((2.0f));
            newCube.GetComponentInChildren<TextMesh>().text = bird.CommonName;
            

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
