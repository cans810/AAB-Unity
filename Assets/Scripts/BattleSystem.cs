using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        


        SetupBattle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetupBattle(){

    }
}

public enum BattleState{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}
