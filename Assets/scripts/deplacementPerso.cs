using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacementPerso : MonoBehaviour
{
    /*----------------
     *** VARIABLES ***
     -----------------*/
    private float vitesseDeplacement = 15f; // Vitesse de déplacement du personnage
    private float forceSaut = 15f; // Force du saut
    bool toucheSol; // Booleen pour detecter si le perso touche le sol

    // Raccourcis GetComponent
    Rigidbody rb;
    Animator animateur;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Rigidbody
        animateur = GetComponent<Animator>(); // Animator
    }

    void Update()
    {
        /*--------------
         ** MOUVEMENT **
         ---------------*/
        // Deplacement horizontal perso
        var vDeplacement = Input.GetAxis("Horizontal") * vitesseDeplacement;
        // Deplacement vertical perso
        var vMonte = Input.GetAxis("Vertical") * -vitesseDeplacement;
        // Raccourci pour la velocite du saut
        float velociteY = rb.velocity.y;

        // Controles pour faire avancer le perso sur l'axe des X avec les touches Horizontales (W et S)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position += new Vector3(vMonte * Time.deltaTime, 0, 0);
        }

        /*---------------
         ** Animations **
        ----------------*/
        // mouvement horizontal
        switch (vDeplacement)
        {
            case > 0:
                animateur.SetBool("course", true);
                animateur.SetBool("course2", false);
                break;
            case < 0:
                animateur.SetBool("course2", true);
                animateur.SetBool("course", false);
                break;
            case 0:
                animateur.SetBool("course", false);
                animateur.SetBool("course2", false);
                break;
        }

        // Mouvement vertical
        switch (vMonte)
        {
            case > 0:
                animateur.SetBool("monte", true);
                animateur.SetBool("descend", false);
                break;
            case < 0:
                animateur.SetBool("descend", true);
                animateur.SetBool("monte", false);
                break;
            case 0:
                animateur.SetBool("descend", false);
                animateur.SetBool("monte", false);
                break;
        }

        // Appel de la fonction pour le déplacement diagonal du joueur
        ControlesDiagonaux();

        // Saut
        switch (toucheSol)
        {
            case false:
                animateur.SetBool("saute", true);
                break;
            case true:
                animateur.SetBool("saute", false);
                break;
        }


        /*---------
         ** SAUT **
         ----------*/
        RaycastHit infoCollision;
        // Cast des spheres vers bas perso + variable infoCollision prends valeurs
        toucheSol = Physics.SphereCast(transform.position + new Vector3(0f, 1f, 0f), 1f, -transform.up, out infoCollision, 1f);

        // Si le jouer appuie sur espace la velocitee Y augmente et le personnage saute  
        if (Input.GetKeyDown(KeyCode.Space) && toucheSol)
        {
            velociteY += forceSaut;
        }

        // Les velocitees se font passer les valeurs des variables vDeplacement et velociteY
        rb.velocity = transform.forward * vDeplacement + new Vector3(0, velociteY, 0);

        // pour voir si le joueur touche le sol
       // Debug.Log(toucheSol == true);
    }

    /* Pour voir le spherecast 
     ---------------------------------------------------------------------------*/
    private void OnDrawGizmos()
    {
        // On dessine la sphère sous la capsule (perso), là où le sphereCast se fait
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0f, 1f, 0f), 1f);
    }

    /*------------------------------
     ** FONCTIONS SUPPLÉMENTAIRES **
     ------------------------------*/
    // Gestion du déplacement en diagonal du personnage
    private void ControlesDiagonaux()
    {
        if (toucheSol)
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                animateur.SetBool("diagonaleHD", true);
                animateur.SetBool("descend", false);
                animateur.SetBool("course", false);
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                animateur.SetBool("diagonaleBD", true);
                animateur.SetBool("monte", false);
                animateur.SetBool("course", false);
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                animateur.SetBool("diagonaleBG", true);
                animateur.SetBool("monte", false);
                animateur.SetBool("course2", false);
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                animateur.SetBool("diagonaleHG", true);
                animateur.SetBool("descend", false);
                animateur.SetBool("course2", false);
            }
            else
            {
                animateur.SetBool("diagonaleHD", false);
                animateur.SetBool("diagonaleBD", false);
                animateur.SetBool("diagonaleBG", false);
                animateur.SetBool("diagonaleHG", false);
            }
        }
    }
}