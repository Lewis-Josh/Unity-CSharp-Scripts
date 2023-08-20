using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFOV : MonoBehaviour
{

    /*
     * Author: Joshua Lewis.
     * Date: 8/19/2023
     * 
     * This Script is for testing and designing Random Raycasts within defined ranges.
     * It is intended for creating a field of view for artificial intelligence but has other uses and implications.
     * It creates 3000 random vectors with each X,Y,Z randomized between a range.
     * It then assigns the vectors into 3 seperate lists.
     * For Loops itterate through each list and assign a Gizmo.DrawLine for testing/viewing in editor.
     * The Lists auto-populate and auto-clear in editor with no effort from the developer for continuous testing.
     * Each Vector follows the position and rotation of a defined camera object which can be set in the inspector.
     * 
     * The result is a realistic field of view which lengthens and shortens vectors based on physical movement.
     * When used on a moving/rotating object in play mode (as raycasts) one can see the vectors changing magnitude.
     * This is to simulate the effect that humans turn their head towards the direction of movement.
     * 
     * The Lists are for visual testing/debugging, when used in a Raycast there is no need to store the random vectors.
     * 
     */

    // Create Camera object.
    public Camera Cam;

    // Create Empty Vectors.
    private Vector3 randomRay = Vector3.zero;
    private Vector3 randomRay1 = Vector3.zero;
    private Vector3 randomRay2 = Vector3.zero;

    // Create Test Lists of vectors.
    public List<Vector3> testList = new List<Vector3>();
    public List<Vector3> testList1 = new List<Vector3>();
    public List<Vector3> testList2 = new List<Vector3>();

    //Debug Gizmos raycasts
    void OnDrawGizmosSelected()
    {
        // Get Rigidbody Component.
        rb = GetComponent<Rigidbody>();

        // Set Gizmos Color.
        Gizmos.color = Color.red;

        //Create Vector3 with Random X,Y,Z FLoats within Range.
        Vector3 randomRay = new Vector3(Random.Range(-180f, 180f), Random.Range(-10f, 30f), Random.Range(10, 180)).normalized;
        Vector3 randomRay1 = new Vector3(Random.Range(-180f, 180f), Random.Range(-10f, 30f), Random.Range(10, 180)).normalized;
        Vector3 randomRay2 = new Vector3(Random.Range(-180f, 180f), Random.Range(-10f, 30f), Random.Range(10, 180)).normalized;

        // Add 1000 Vectors to Each List.
        if (testList.Count <= 999)
        {
            testList.Add(randomRay);
            testList1.Add(randomRay1);
            testList2.Add(randomRay2);
        }
        else //Once List Self Populates to 1000, Reset List Value. (This makes for easy testing as the list auto clears in editor.)
        {
            testList.Clear();
            testList1.Clear();
            testList2.Clear();
        }

        //For Loops to Itterate through Each List and Assign a Line to Each Vector within the list.
        for (int i = 0; i < testList.Count; i++)
        {
            Gizmos.DrawLine(Cam.transform.position, Cam.transform.TransformDirection(testList[i]) * 100f);
        }
        for (int i = 0; i < testList1.Count; i++)
        {
            Gizmos.DrawLine(Cam.transform.position, Cam.transform.TransformDirection(testList1[i]) * 100f);
        }
        for (int i = 0; i < testList2.Count; i++)
        {
            Gizmos.DrawLine(Cam.transform.position, Cam.transform.TransformDirection(testList2[i]) * 100f);
        }
    }
}
