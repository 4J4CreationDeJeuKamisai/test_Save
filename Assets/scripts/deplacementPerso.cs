using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacementPerso : MonoBehaviour
{
    /*----------------
     *** VARIABLES ***
     -----------------*/
    private float vitesseDeplacement = 10f;
    private float vitesseRotation = 5f;
    private float forceSaut = 5f;
    bool toucheSol;
    bool peutSauter = true;

    // Raccourcis GetComponent
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Rigidbody
    }

    void Update()
    {
        /*--------------
         ** MOUVEMENT **
         ---------------*/
        // Deplacement vertical perso
        var vDeplacement = Input.GetAxis("Vertical") * vitesseDeplacement;
        // Deplacement horizontal perso
        var vTourne = Input.GetAxis("Horizontal") * vitesseRotation;
        float velociteY = rb.velocity.y;

        // Rotation perso
        var tourne = Input.GetAxis("Mouse X") * vitesseRotation;
        transform.Rotate(0, tourne, 0);

        // Controles pour faire tourner le perso avec les touches Horizontales (A et D)
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, vTourne, 0);
        }

        /*---------
         ** SAUT **
         ----------*/
        RaycastHit infoCollision;
        // Cast des spheres vers bas perso + variable infoCollision prends valeurs
        toucheSol = Physics.SphereCast(transform.position + new Vector3(0f, 0.5f, 0f), 0.2f, -Vector3.up, out infoCollision, 0.8f);

        // Si le jouer appuie sur espace la velocitee Y augmente et le personnage saute  
        if (Input.GetKeyDown(KeyCode.Space) && toucheSol && peutSauter)
        {
            velociteY += forceSaut;
            peutSauter = false;
            // Demarrer la coroutine pour le delai entre les sauts
            StartCoroutine(ActiveSaut());
        }

        // Les velocitees se font passer les valeurs des variables vDeplacement et velociteY
        rb.velocity = transform.forward * vDeplacement + new Vector3(0, velociteY, 0);
    }
    /*-------------------
     *** IENUMERATORS ***
     --------------------*/
    // Coroutine pour delai entre les sauts
    IEnumerator ActiveSaut()
    {
        yield return new WaitForSeconds(0.5f);
        peutSauter = true;
    }
}