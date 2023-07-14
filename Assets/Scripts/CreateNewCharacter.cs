using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using UnityEngine.U2D.Animation;

public class CreateNewCharacter : MonoBehaviour
{
    // UI Text game objects
    public GameObject totalPointsGameObject;
    public GameObject strengthPointGameObject;

    // game variables
    public int totalPoints;

    // text components
    private TextMeshProUGUI textMeshPro_totalPoints_text;
    private TextMeshProUGUI textMeshPro_strengthPoint_text;

    public GameObject SetAppereance;
    public GameObject GiveStats;
    
    // player and player attributes
    public Player player;

    public SkinChanger skinChanger;
    public static SpriteLibraryAsset skin;

    public static int strength;

    public static double heightInCm;

    // Start is called before the first frame update
    void Start(){

        totalPoints = 5;
        strength = 1;
        heightInCm = 170;

        SetAppereance.SetActive(true);
        GiveStats.SetActive(false);


        textMeshPro_totalPoints_text = totalPointsGameObject.GetComponent<TextMeshProUGUI>();
        textMeshPro_strengthPoint_text = strengthPointGameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update(){
         // text mesh pro
         textMeshPro_totalPoints_text.text = totalPoints.ToString();
         textMeshPro_strengthPoint_text.text = strength.ToString();
    }

    public void increaseStrength(){
        totalPoints -= 1;
        strength += 1;
        heightInCm += 2;

        // adjust player size here
        // Store the original position
        Vector3 originalPosition = player.transform.position;

         // Calculate the new scale uniformly
        float newScale =  player.transform.localScale.x * 1.01f;

        // Calculate the position adjustment based on the scale change
        Vector3 positionAdjustment = (newScale -  player.transform.localScale.x) * 0.59f *  player.transform.up;

        // Apply the new scale and adjust the position
        player.transform.localScale = new Vector3(newScale, newScale,  player.transform.localScale.z);
        player.transform.position = originalPosition - positionAdjustment;
    }
    public void decreaseStrength(){
        totalPoints += 1;
        strength -= 1;
        heightInCm -= 2;

        // adjust player size here
        // Store the original position
        Vector3 originalPosition = player.transform.position;

         // Calculate the new scale uniformly
        float newScale =  player.transform.localScale.x / 1.01f;

        // Calculate the position adjustment based on the scale change
        Vector3 positionAdjustment = (newScale -  player.transform.localScale.x) * 0.59f *  player.transform.up;

        // Apply the new scale and adjust the position
        player.transform.localScale = new Vector3(newScale, newScale,  player.transform.localScale.z);
        player.transform.position = originalPosition - positionAdjustment;
    }

    public void proceedToGiveStats(){
        SetAppereance.SetActive(false);
        GiveStats.SetActive(true);
    }

    public void proceedToBattle(){
        skin = skinChanger.getCurrentSkin();

        SceneManager.LoadSceneAsync("BattleScene");
    }

    /* IEnumerator LoadYourAsyncScene()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BattleScene", LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(playerGameObject, SceneManager.GetSceneByName("BattleScene"));
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    } */
}
