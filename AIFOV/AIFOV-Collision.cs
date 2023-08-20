using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Joshua Lewis
*  Date: 8/20/2023
*
*  This Script takes the AIFOV-Concept and applies it to Raycasts.
*  Using Random Vectors within a range it generates Raycasts originating from a Camera Object.
*  It stores each Raycast in a list depending on if the Raycast detected collision.
*  For Loops itterate through both lists and assign a Gizmo.DrawLine based on each vector in each list.
*  Green Vectors are Raycasts that did not collide before reaching maximum magnitude.
*  Red Vectors are Raycasts that detected Collision before reaching maximum magnitude.
*
*/
public class AIFOV : MonoBehaviour
{
    // Create Camera object.
    public Camera Cam;

    // Target Sighted Bool
    public bool targetSighted = false;

    // Create empty Vector3 Objects
    private Vector3 randomRay = Vector3.zero;
    private Vector3 hitPoint = Vector3.zero;

    // Create empty lists, one for rays that do not collide and one for collisions.
    public List<Vector3> missList = new List<Vector3>();
    public List<Vector3> hitList = new List<Vector3>();

    // Raycast Method
    void targetAcquisition()
    {
        // Check if target has been sighted, if !targetSighted, Raycast.
        if (!targetSighted)
        {
            // Create Random Vector within bounds.
            Vector3 randomRay = new Vector3(Random.Range(-180f, 180f), Random.Range(-10f, 30f), Random.Range(10, 180)).normalized;

            // Create local Raycast Hit variable.
            RaycastHit hit;

            //If over 2000 vectors, clear lists for performance.
            if (missList.Count + hitList.Count > 1999)
            {
                missList.Clear();
                hitList.Clear();
            }

            // Create Raycast based on Camera's position and rotation.
            // Raycast direction is the random Vector3 within bounds.
            if (Physics.Raycast(Cam.transform.position, Cam.transform.TransformDirection(randomRay), out hit, 100f))
            {
                // If there is a collision and it is not the player.
                // Add raycast hit.point to List.
                if (!hit.collider.CompareTag("Player"))
                {
                    hitList.Add(hit.point);
                }
                // If Collision with player, Pause Game, Target is sighted.
                else if (hit.collider.CompareTag("Player"))
                {
                    //Collor Raycast that collided with player Blue.
                    Debug.DrawRay(Cam.transform.position, hit.point, Color.blue, 60);
                    Time.timeScale = 0f;
                    targetSighted = true;
                }
            }
            else // If there is no collision at all, add the raycast to Miss List.
            {
                missList.Add(randomRay);
            }
        }
    }

    //Gizmos to draw raycasts.
    void OnDrawGizmos()
    {
        // Itterate through the Hit List and color the Raycast Red to indicate a Hit.
        for (int i = 0; i < hitList.Count; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Cam.transform.position, Cam.transform.TransformDirection(hitList[i]));
        }

        // Itterate through the Miss List and color the Raycast Green to indicate a Miss.
        for (int i = 0; i < missList.Count; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(Cam.transform.position, Cam.transform.TransformDirection(missList[i]) * 100f);
        }
    }
}
