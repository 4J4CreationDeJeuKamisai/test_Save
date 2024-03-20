using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScenes : MonoBehaviour
{
    //Variable de son une fois un bouton cliqué
    public AudioClip sonClic;

    //Pour insérer la scène visée
    public string nomScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Fonction pour changer les scènes au clic d'un button
    public void changerScene()
    {
        //Charger la scène
        SceneManager.LoadScene(nomScene);
        //Jouer un son défini dans l'inspecteur
        GetComponent<AudioSource>().PlayOneShot(sonClic);
    }
}
