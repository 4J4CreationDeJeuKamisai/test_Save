using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class savePosition : MonoBehaviour
{
    public GameObject joueur;
    public Button load;

    public float positionX;
    public float positionY;
    public float positionZ;

    public float rotationX;
    public float rotationY;
    public float rotationZ;

    // Passer les valeurs de la save
    public void Start()
    {
        if (positionX != 0)
        {
            // On regarde si le personnage a bougé précédemment
            transform.position = new Vector3(positionX, positionY, positionZ);
            transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
        }
    }

    // Sauvegarder les valeurs de positions 
    public void Save()
    {
        PlayerPrefs.SetFloat("laPositionX", transform.position.x);
        PlayerPrefs.SetFloat("laPositionY", transform.position.y);
        PlayerPrefs.SetFloat("laPositionZ", transform.position.z);

        PlayerPrefs.SetFloat("laRotationX", transform.eulerAngles.x);
        PlayerPrefs.SetFloat("laRotationY", transform.eulerAngles.y);
        PlayerPrefs.SetFloat("laRotationZ", transform.eulerAngles.z);
    }

    // Avoir les valeurs pour la position de base 
    public void Load()
    {
        // Les postions
        positionX = PlayerPrefs.GetFloat("laPositionX");
        positionY = PlayerPrefs.GetFloat("laPositionY");
        positionZ = PlayerPrefs.GetFloat("laPositionZ");
        // Les rotations
        rotationX = PlayerPrefs.GetFloat("laRotationX");
        rotationY = PlayerPrefs.GetFloat("laRotationY");
        rotationZ = PlayerPrefs.GetFloat("laRotationZ");


        // On regarde si le personnage a bougé précédemment
        transform.position = new Vector3(positionX, positionY, positionZ);
        transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
    }
}
