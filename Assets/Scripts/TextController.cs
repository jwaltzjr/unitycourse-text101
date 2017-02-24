using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{

    public Text text;

    enum State {Start, Prison};
    enum Choice : byte {Choice1, Choice2, Choice3, Choice4};

    State player_state;
    Choice player_choice;

	// Use this for initialization
	void Start()
    {
        player_state = State.Start;
	}

	// Update is called once per frame
	void Update()
    {
        switch (player_state)
        {
            case State.Start:
                StartScene();
                break;
            case State.Prison:
                PrisonScene();
                break;
        }
	}

    void LogPlayer()
    {
        print(player_state);
        print(player_choice);
    }

    void StartScene()
    {
        LogPlayer();
        text.text =
            "You and your wife, Catelyn, are on a trip to the city " +
            "to set up shop in the market. It's been a rough year, " +
            "and the last of your wares are with you in your cart. " +
            "As you're traveling along the path through the forest " +
            "that lies between your home and the city, you come upon " +
            "a camp that seems to be empty. It's quiet, but after you " +
            "pass men start rushing out from behind the trees.\n\n" +
            "1. Fight them\n" +
            "2. Talk to them\n" +
            "3. Ignore them";

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            player_choice = Choice.Choice1;
            player_state = State.Prison;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            player_choice = Choice.Choice2;
            player_state = State.Prison;
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            player_choice = Choice.Choice3;
            player_state = State.Prison;
        }
    }

    void PrisonScene()
    {
        LogPlayer();
        text.text =
            "Prison Scene Text\n\n" +
            "1.\n" +
            "2.\n" +
            "3.";

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            player_choice = Choice.Choice1;
            player_state = State.Start;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            player_choice = Choice.Choice2;
            player_state = State.Start;
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            player_choice = Choice.Choice3;
            player_state = State.Start;
        }
    }

}
