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
    private float forceSaut = 10f;
    bool toucheSol;
    private bool peutSauter;

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
        toucheSol = Physics.SphereCast(transform.position + new Vector3(0f, -6f, 0f), 1f, -transform.up, out infoCollision, 1f);

        // Si le jouer appuie sur espace la velocitee Y augmente et le personnage saute  
        if (Input.GetKeyDown(KeyCode.Space) && toucheSol)
        {
            velociteY += forceSaut;
        }

        // Les velocitees se font passer les valeurs des variables vDeplacement et velociteY
        rb.velocity = transform.forward * vDeplacement + new Vector3(0, velociteY, 0);

        // pour voir si le joueur touche le sol
        Debug.Log(toucheSol == true);
    }

    /* Pour debugger le spherecast 
     ---------------------------------------------------------------------------*/
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0f, -6f, 0f), 3f);
    }
}