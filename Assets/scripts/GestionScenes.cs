using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScenes : MonoBehaviour
{
    //Variable de son une fois un bouton cliqu�
    public AudioClip sonClic;

    //Pour ins�rer la sc�ne vis�e
    public string nomScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Fonction pour changer les sc�nes au clic d'un button
    public void changerScene()
    {
        //Charger la sc�ne
        SceneManager.LoadScene(nomScene);
        //Jouer un son d�fini dans l'inspecteur
        GetComponent<AudioSource>().PlayOneShot(sonClic);
    }
}
