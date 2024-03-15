using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PokemonData : MonoBehaviour{
    
    //Initialisation des variables qui seront visible dans l'inspecteur
    [SerializeField] private string pokemonName = "Charizard";
    [SerializeField] private int pokemonBaseLife = 100;
    [SerializeField] private int pokemonAttack = 10;
    [SerializeField] private int pokemonDefense = 10;
    [SerializeField] private float pokemonWeight = 90.5f;

    //Initialisation de variables qui seront pas visible dans l'inspecteur
    private int pokemonStatisticalPoint = 200;
    private int pokemonCurrentLife = 100;

    //Initialisation du enum
    private enum allPokemonTypes{Normal,Fire,Water,Plant,Electric,Ice,Fight,Poison,Ground,Flight,Psy,Insect,Rock,Spectrum,Dragon,Darkness,Steel};
    [SerializeField] private allPokemonTypes myPokemonType = allPokemonTypes.Fire;
    

    //Initialisation des variables pour récupérer la faiblesse et résistance du pokemon
    private static allPokemonTypes pokemonWeak1 = allPokemonTypes.Water;
    private static allPokemonTypes pokemonWeak2 = allPokemonTypes.Rock;

    private static allPokemonTypes pokemonResi1 = allPokemonTypes.Fire;
    private static allPokemonTypes pokemonResi2 = allPokemonTypes.Ground;

    //Initialisation du tableau avec le type du enum pour apparaitre dans l'inspecteur'
    [SerializeField] private allPokemonTypes[] pokemonWeaknessesTypes = {pokemonWeak1,pokemonWeak2}; 
    [SerializeField] private allPokemonTypes[] pokemonResistancesTypes = {pokemonResi1,pokemonResi2};


    //Methode start qui appel 4 fonctions au démarage du programme
    void Start(){
        DisplayPokemon();
        InitCurrentLife();
        InitStatsPoints();
        TakeDamage(pokemonAttack,allPokemonTypes.Dragon);  
    }

   //Méthode update qui appel 1 fonctions toutes les frames
    void Update(){
        CheckifPokemonAlive();
    }

    //fonctions qui affiche toutes les variables avec du texte dans la console
    void DisplayPokemon(){
        Debug.Log("Pokemon name is " + pokemonName);
        Debug.Log("Pokemon base life is " + pokemonBaseLife);
        Debug.Log("Pokemon attack is "+ pokemonAttack);
        Debug.Log("Pokemon defense is "+ pokemonDefense);
        Debug.Log("Pokemon weight is " + pokemonWeight);
        Debug.Log("Pokemon statistical point is " + pokemonStatisticalPoint);
        Debug.Log("Pokemon current life is " + pokemonCurrentLife);
        Debug.Log("Pokemon type is " + myPokemonType);
        Debug.Log("Pokemon is weak against type : " + pokemonWeak1);
        Debug.Log("Pokemon is weak against type : " + pokemonWeak2);
        Debug.Log("Pokemon is durable against type : " + pokemonResi1);
        Debug.Log("Pokemon is durable against type : " + pokemonResi2);
    }

    //Variables qui donne la valeur de base de la vie à la vie courrante du pokemon
    void InitCurrentLife(){
        pokemonCurrentLife = pokemonBaseLife;
    }

    //Fonctions qui additionne les variables de  la vie de base + attaque et la défense du pokemon dans les statistiques  / base life = current life donc la même chose j'ai mis base life
    void InitStatsPoints(){
        pokemonStatisticalPoint = pokemonBaseLife + pokemonAttack + pokemonDefense; 
    }

    //Fonctions qui retourne seulement damage mais elle est jamais appelé
    public int GetAttackDamage(int damage){
         return damage;
    }
    
    //Fonction avec plusieurs conditions
   void TakeDamage(int damage,allPokemonTypes pokemonTypesEnemy){

        if(pokemonTypesEnemy == pokemonWeak1 || pokemonTypesEnemy == pokemonWeak2){    //vérifie le pokemonTypes de l'Ennemie et si il correspond à l'un des deux alors on continue
            damage = damage * 2;  //si condition du dessu vraie alors on multiplie par deux les dégats
            pokemonCurrentLife = pokemonCurrentLife - damage; //on affecte les dégats
            Debug.Log(pokemonCurrentLife); //on affiche dans la console
        }else if (pokemonTypesEnemy == pokemonResi1 || pokemonTypesEnemy == pokemonResi2){ //si la condition du dessu est fausse alors on vérifie cette là
            damage = damage / 2; //si condition du dessu vraie alors on divise par deux les dégats
            pokemonCurrentLife = pokemonCurrentLife - damage;  //on affecte les dégats
            Debug.Log(pokemonCurrentLife); //on affiche dans la console
        }else if (damage == 0){ //si les deux conditions du dessus son fausse alors on vérifie cette ci
            Debug.Log("no damage"); //si la condition du dessu est vraie on affiche le message dans la console
        }else{ // si toutes les conditions sont fausse on effectue cette ci
            pokemonCurrentLife = pokemonCurrentLife - damage; //on affecte les dégats
            Debug.Log(pokemonCurrentLife); //si la condition du dessu est vraie on affiche le message dans la console
        }
    }

    //fonctions qui affiche la vie du joueur actuel dans la console
    void CheckifPokemonAlive(){
        Debug.Log(pokemonCurrentLife);
     }

}
