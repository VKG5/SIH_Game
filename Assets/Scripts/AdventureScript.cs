using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureScript : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    int reward_point = 0;
    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        // The string inside the textComponent field
        textComponent.text = state.GetStoryState();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        
        if(Input.GetKeyDown(KeyCode.Return))
        {
            state = nextStates[0];
        }

        for(int index=0; index<nextStates.Length; index++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                rewards(index);
                
                state = nextStates[index];
            }
        }
        
        textComponent.text = state.GetStoryState();
    }

    private void rewards(int index)
    {
        if((index+1)==1)
            reward_point += 0;

        else if((index+1)==2)
            reward_point += 5;

        else
            reward_point += 10;

        Debug.Log("Reward: "+(reward_point));
    }
}
