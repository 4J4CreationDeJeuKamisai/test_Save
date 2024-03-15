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

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Rigidbody
    }

    void Update()
    {
        /*--------------
         ** MOUVEMENT **
         ---------------*/
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

        /*--------------
          ** ROTATION **
         ---------------*/
        // Rotation du personnage
        if (Input.GetKey(KeyCode.A)) // Moving left
        {
            transform.rotation = Quaternion.Euler(180, 0, 0); // Face left
            vDeplacement = Input.GetAxis("Horizontal") * -vitesseDeplacement;
        }
        else if (Input.GetKey(KeyCode.D)) // Moving right
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Face right
            vDeplacement = Input.GetAxis("Horizontal") * vitesseDeplacement;
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
        // On dessine la sphère sous la capsule (perso), là où le sphereCast se fait
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0f, -6f, 0f), 3f);
    }
}