// UMD IMDM290 
// Instructor: Myungin Lee
// This tutorial introduce a way to draw spheres and align them in a circle with colors.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    GameObject[] spheres;
    static int numSphere = 100; 
    float closeness = 30;
    float distanceChange = -0.5f;
    float time = 0f;
    Vector3[] initPos;
    // Start is called before the first frame update
    void Start()
    {
        spheres = new GameObject[numSphere];
        initPos = new Vector3[numSphere];
        
        foreach (GameObject sphere in spheres){
            // sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            // This will cause an error. Why?
            // foreach is a read only iterator that iterates dynamically classes that implement IEnumerable, each cycle in foreach will call the IEnumerable to get the next item, the item you have is a read only reference,
        }

        // Let there be spheres..
        for (int i =0; i < numSphere; i++){
            float r = 5f; // radius of the circle
            // Draw primitive elements:
            // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/GameObject.CreatePrimitive.html
            spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere); 
            // Initial positions of the spheres. make it in circle with r radius.
            // https://www.cuemath.com/gemometry/unit-circle/
            initPos[i] = new Vector3(r * Mathf.Sqrt(2f) * Mathf.Pow(Mathf.Sin(i * 2f * Mathf.PI / numSphere), 3f), r * (-Mathf.Pow(Mathf.Cos(i * 2f * Mathf.PI / numSphere), 3f) - Mathf.Pow(Mathf.Cos(i * 2f * Mathf.PI / numSphere), 2f) + 2f*Mathf.Cos(i * 2f * Mathf.PI / numSphere)) + 2f, closeness);
            spheres[i].transform.position = initPos[i];

            // Get the renderer of the spheres and assign colors.
            Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
            // hsv color space: https://en.wikipedia.org/wiki/HSL_and_HSV
            float hue = (float)i / numSphere; // Hue cycles through 0 to 1
            Color color = Color.HSVToRGB(hue, 0.5f, 1f); // Full saturation and brightness
            sphereRenderer.material.color = color;
        }
    }

    void Update() 
    {
        closeness = closeness + distanceChange;
        if(closeness > 30) {
            distanceChange = -0.5f;
        }

        if(closeness < 10) {
            distanceChange = 0.5f;
        }
        foreach(GameObject sphere in spheres) {
            sphere.transform.position = new Vector3(sphere.transform.position.x, sphere.transform.position.y, closeness);
        }
    }
        
}
