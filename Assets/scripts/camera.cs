using System.Collections;
using System.Collections.Generic;
using System;
using Cinemachine;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject joueur;//Pour trouver le joueur et, eventuellement, ajuster les positions de la camera
    public CinemachineVirtualCamera cam1;//Variable de la camera virtuelle
    private CinemachineComponentBase composants;//Variable pour le "Body" de la camera virtuelle
    private CinemachineTransposer transposer;

    private void Start()
    {
        // Configure camera to look at joueur
        if (joueur != null && cam1 != null)
        {
            CinemachineComposer composer = cam1.GetCinemachineComponent<CinemachineComposer>();
            if (composer != null)
            {
                composer.m_TrackedObjectOffset.y = 3f; // Adjust the height of the camera
                composer.m_TrackedObjectOffset.z = -5f; // Adjust the distance from the joueur
            }
            cam1.Follow = joueur.transform; // Unlink the camera from any target
            cam1.LookAt = joueur.transform; // Make the camera look at joueur
        }
    }

    private void Update()
    {
        //Si la variable composants est associee au "transposer" de la camera virtuelle 
        if (composants is CinemachineFramingTransposer)
        {
            //On cree une variable qui associe la variable composants au "transposer"
            var framingTransposer = composants as CinemachineFramingTransposer;
        }
    }
}
