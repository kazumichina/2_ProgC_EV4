using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.interiorlighting.interactable;

namespace com
{
    namespace interiorlighting
    {
        namespace interactor
        {
            public class SceneInteractor : MonoBehaviour
            {
                GameObject[] pointLights;

                //play click when collied
                AudioSource audioPlayer;
                public GameObject seSource;

                // Start is called before the first frame update
                void Start()
                {
                    //play click when collied
                    audioPlayer = seSource.GetComponent<AudioSource>();

                }

                // Update is called once per frame
                void Update()
                {

                }

                void SetDoorOpen(GameObject door)
                {   
                    /**
                        The argument "door" which is a GameObject datatype should contain the reference to "DoorRotationAxis" in the scene.
                        You then need to access the component "DoorInteraction" that is attached to this GameObject, which actually is a C# script
                        This script contains a function called "OpenDoor" that needs to be called for the door to open and you can go outside
                    **/

                    // I want OpenDoor() in DoorInteraction in door
                    door.GetComponent<DoorInteraction>().OpenDoor();
                }

                void SetLightingIntensity(GameObject go)
                {
                    /**
                        The argument "go" is a GameObject datatype that will contain a reference to either of the intensity cubes on the floor 
                        (the ones from white to black).
                        These GameObject cubes have a script attached to them called as "LightingIntensityValue". 
                        You need to access this script as a component and read the public float variable "intensity".
                        The value in the intensity will be set as the intensity to all the lights in the scene marked with the tag "DynamicLights".
                        To access all GameObjects in the scene with a tag you need to use GameObject.FindGameObjectsWithTag("DynamicLights")
                        Once you have all the GameObjects then you need to access their component "<Light>" to which you will set the intensity value.
                        To know how to set the value of intensity visit: https://docs.unity3d.com/ScriptReference/Light-intensity.html
                    **/
                    pointLights = GameObject.FindGameObjectsWithTag("DynamicLights");
                    
                    // I am telling Unity that I want each light inside my array pointLights.
                    foreach (GameObject light in pointLights){
                        light.GetComponent<Light>().intensity = go.GetComponent<LightingIntensityValue>().intensity;
                    }
                }

                void SetLightingColor(Color aNewColor)
                {
                    /**
                        The argument "c" is a Color datatype that will contain either of the values as Color.red, Color.green, or Color.blue.
                        To access all GameObjects in the scene with a tag you need to use GameObject.FindGameObjectsWithTag("DynamicLights")
                        Once you have all the GameObjects then you need to access their component "<Light>" to which you will set the color value.
                        To know how to set the value of intensity visit: https://docs.unity3d.com/ScriptReference/Light-color.html
                    **/
                    pointLights = GameObject.FindGameObjectsWithTag("DynamicLights");
                    
                    foreach (GameObject light in pointLights){
                        light.GetComponent<Light>().color = aNewColor;
                    }
                }

                void OnTriggerEnter(Collider collider)
                {
                    Debug.Log("HIT A COLLIDER " + collider.gameObject.name);
                    string gameObjectThatWasHit = collider.gameObject.name;

                    /**
                        This function is triggerred whenever your character collides with any of the colored cubes, intensity cubes, or the door, or the RugCarpet
                        You need to call the appropriate function when any of these collisions occur between your character and the interactables in the scene
                        The variable "gameObjectThatWasHit" contains the name of the GameObject your character collided with. 
                        You can use either if/else-if/else conditionals or switch/case conditional statements to handle what happens after a collisiin is detected
                            - When you hit any of the colored cubes or the RugCarpet
                                - Call the function "SetLightingColor" and pass 
                                    - Color.red if the collision is with RedCube
                                    - Color.green if the collision is with GreenCube
                                    - Color.blue if the collision is with BlueCube
                                    - Color.white if the collision is with the RugCarpet
                            - When you collide with any of the intensity cubes call the function "SetLightingIntensity" and  pass the argument c.gameObject 
                            - when you collide with the "DoorRotationAxis" call the function "SetDoorOpen" and pass the argument c.gameObject
                        
                    **/
                    
                    if(collider.gameObject.CompareTag("CollisionTag")){
                        audioPlayer.Play();
                    }

                    //open door
                    if (gameObjectThatWasHit == "DoorRotationAxis")
                    {
                        SetDoorOpen(collider.gameObject);
                    }
                    
                    //change light color
                    if (gameObjectThatWasHit == "BlueCube")
                    {
                        SetLightingColor(Color.blue);
                    }
                    if (gameObjectThatWasHit == "RedCube")
                    {
                        SetLightingColor(Color.red);
                    }
                    if (gameObjectThatWasHit == "GreenCube")
                    {
                        SetLightingColor(Color.green);
                    }
                    if (gameObjectThatWasHit == "RugCarpet")
                    {
                        SetLightingColor(Color.white);
                    }

                    //light intensity
                    if (gameObjectThatWasHit == "IntensityCube0.0"){
                        SetLightingIntensity(collider.gameObject);
                    }
                    if (gameObjectThatWasHit == "IntensityCube0.25"){
                        SetLightingIntensity(collider.gameObject);
                    }
                    if (gameObjectThatWasHit == "IntensityCube0.5"){
                        SetLightingIntensity(collider.gameObject);
                    }
                    if (gameObjectThatWasHit == "IntensityCube0.75"){
                        SetLightingIntensity(collider.gameObject);
                    }
                    if (gameObjectThatWasHit == "IntensityCube1.0"){
                        SetLightingIntensity(collider.gameObject);
                    }


                }
            }
        }
    }
}

