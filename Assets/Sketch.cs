using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using
using UnityEngine.Networking;
using System.Collections;

public class Sketch : MonoBehaviour
{
    public GameObject myPrefab;
    // Put your URL here
    public string _WebsiteURL = "http://infosys320labtest01.azurewebsites.net/tables/Birds?zumo-api-version=2.0.0";

    void Start() {
        StartCoroutine(GetText());
    }

    IEnumerator GetText() {
        UnityWebRequest www = UnityWebRequest.Get(_WebsiteURL);
        string jsonResponse;
        yield return www.Send();

        if (www.isError) {
            Debug.Log(www.error);
            yield break;
        } else {
            //jsonResponse = "[{\"id\":\"50a8887e-4a89-4992-a5bf-f38f6d62ed9c\",\"createdAt\":\"2016-10-06T00:07:35.958Z\",\"updatedAt\":\"2016-10-06T00:07:36.411Z\",\"version\":\"AAAAAAAAC9Q=\",\"Name\":\"Euryapteryx curtus\",\"Type\":\"Scientific Specimen\",\"CommonName\":\"Coastal Moa\",\"Place\":\"Aupouri Ecological Region and District\",\"CollectionID\":\"LB6693\",\"deleted\":false},{\"id\":\"4f3c7897-7b5d-4702-ba6d-e70b28ee9e23\",\"createdAt\":\"2016-10-06T00:07:35.958Z\",\"updatedAt\":\"2016-10-06T00:07:36.411Z\",\"version\":\"AAAAAAAAC9M=\",\"Name\":\"Anomalopteryx didiformis\",\"Type\":\"Scientific Specimen\",\"CommonName\":\"Little Bush Moa\",\"Place\":\"Kaipara Ecological Region and District\",\"CollectionID\":\"LB5785\",\"deleted\":false},{\"id\":\"2de31ea3-fd47-41dc-abf6-2b6ba9e20fac\",\"createdAt\":\"2016-10-06T00:07:35.958Z\",\"updatedAt\":\"2016-10-06T00:07:36.411Z\",\"version\":\"AAAAAAAAC9I=\",\"Name\":\"Gerygone igata\",\"Type\":\"Scientific Specimen\",\"CommonName\":\"Grey Warbler\",\"Place\":\"Little Barrier Ecological District\",\"CollectionID\":\"LB2022\",\"deleted\":false},{\"id\":\"27d25a11-4c51-45e6-8e9e-c433f5218ab3\",\"createdAt\":\"2016-10-06T00:07:35.958Z\",\"updatedAt\":\"2016-10-06T00:07:36.411Z\",\"version\":\"AAAAAAAAC9E=\",\"Name\":\"Pavo cristatus\",\"Type\":\"Scientific Specimen\",\"CommonName\":\"Peafowl\",\"Place\":\"world (general)\",\"CollectionID\":\"LB155\",\"deleted\":false},{\"id\":\"b2df7f14-519c-47fc-987c-4977ac78f572\",\"createdAt\":\"2016-10-06T00:07:35.958Z\",\"updatedAt\":\"2016-10-06T00:07:36.411Z\",\"version\":\"AAAAAAAAC9A=\",\"Name\":\"Philesturnus carunculatus\",\"Type\":\"Scientific Specimen\",\"CommonName\":\"South Island Saddleback\",\"Place\":\"South Island Ecological Region\",\"CollectionID\":\"LB4201\",\"deleted\":false},{\"id\":\"1eaad90d-3a45-404b-bd07-2a52fbe98b93\",\"createdAt\":\"2016-10-06T00:07:35.958Z\",\"updatedAt\":\"2016-10-06T00:07:36.411Z\",\"version\":\"AAAAAAAAC88=\",\"Name\":\"Chrysococcyx lucidus\",\"Type\":\"Scientific Specimen\",\"CommonName\":\"Shining Cuckoo\",\"Place\":\"Kaimanawa Ecological Region and District\",\"CollectionID\":\"LB8141\",\"deleted\":false},{\"id\":\"71b20151-1a73-4fac-8130-087ac843c304\",\"createdAt\":\"2016-10-06T00:07:35.958Z\",\"updatedAt\":\"2016-10-06T00:07:36.411Z\",\"version\":\"AAAAAAAAC84=\",\"Name\":\"Anthornis melanura\",\"Type\":\"Scientific Specimen\",\"CommonName\":\"Bellbird\",\"Place\":\"Inner Gulf Islands Ecological District\",\"CollectionID\":\"LB12360\",\"deleted\":false}]";
            jsonResponse = www.downloadHandler.text;
            //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
            Birds[] birds = JsonReader.Deserialize<Birds[]>(jsonResponse);

            int totalCubes = birds.Length;
            int totalDistance = 5;
            int i = 0;
            float xlocation = -40.0f;
            float zlocation = 2.0f;
            //We can now loop through the array of objects and access each object individually
            foreach (Birds bird in birds) {
                //Example of how to use the object
                Debug.Log("This object name is: " + bird.CommonName);
                float perc = i / (float) totalCubes;
                i++;

                float x = xlocation;
                xlocation += 3.0f;
                float y = 1.0f;
                float z = zlocation;

                if (i < birds.Length / 2) {
                    zlocation -= i + 1.8f;
                } else if (i == birds.Length / 2) {
                    zlocation -= i + 0.0f;
                } else { zlocation += i - 2.0f; }

                GameObject newCube = (GameObject) Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
                newCube.GetComponent<myCubeScript>().setSize((2.0f));
                newCube.GetComponentInChildren<TextMesh>().text = bird.CommonName;
            }
        }
    }
}
