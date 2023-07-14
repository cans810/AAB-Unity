using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionsHUDManager : MonoBehaviour
{

    public GameObject playerActionsHUD;

    public GameObject playerObject;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.movingRight || player.movingLeft){
            playerActionsHUD.SetActive(false);
        }
        else{
            playerActionsHUD.SetActive(true);
        }
    }
}
