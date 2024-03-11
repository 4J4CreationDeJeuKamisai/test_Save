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

    // Start is called before the first frame update
    void Start()
    {
         /*
            Utilisation d'une camera de type cinemachine pour gerer les deplacements de la camera en parallele avec ceux du personnage et pour emp�cher 
            la camera de descendre trop bas lorsque le personnage tombe. Egalement, j'ai ajoute un leger decallage avec le mouvement de la camera pour donner 
            une impression plus fluide. Source du tutoriel pour l'utilisation de la camera de type cinemachine: https://www.youtube.com/watch?v=2jTY11Am0Ig. 
         */
        //Recuperer le body de la camera virtuelle
        composants = cam1.GetCinemachineComponent(CinemachineCore.Stage.Body);

        //On cree une variable qui associe la variable composants au "transposer"
        var framingTransposer = composants as CinemachineFramingTransposer;
        //On etablit la position de base de la dead zone
       // framingTransposer.m_DeadZoneHeight = 0.22f;
    }

    // Update is called once per frame
    void Update()
    {
        //Si la variable composants est associee au "transposer" de la camera virtuelle 
        if (composants is CinemachineFramingTransposer) {
            //On cree une variable qui associe la variable composants au "transposer"
            var framingTransposer = composants as CinemachineFramingTransposer;

           //Si la position du joueur depasse -12 sur l'axe des Y
           if(joueur.transform.position.y <= -11f){
            //On cree la variable "composer" qui va etre associee aux composants de la camera virtuelle
            var composer = cam1.GetCinemachineComponent<CinemachineComposer>();
            //On change la "DeadZone" pour que la camera arrete de suivre le personnage passe une certaine distance sur l'axe des Y
         //   framingTransposer.m_DeadZoneHeight = 2f;
           }
        }
    }

}
