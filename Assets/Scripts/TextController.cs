using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{

    public Text text;

    enum State
    {
        Opening, Opening_Bandits,
        Prison, Prison_Visited, Prison_Yell, Prison_Walls, Prison_Bed,
        Prison_Door, Prison_Door_Push, Prison_Door_Squeeze, Prison_Door_Key,
    };

    State player_state;

    bool FoundKey;
    bool HayBundle;

    // Use this for initialization
    void Start()
    {
        player_state = State.Opening;

        FoundKey = false;
        HayBundle = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(player_state);
        switch (player_state)
        {
            case State.Opening:
                Opening();
                break;
            case State.Opening_Bandits:
                Opening_Bandits();
                break;

            case State.Prison:
                Prison();
                break;
            case State.Prison_Visited:
                Prison_Visited();
                break;
            case State.Prison_Yell:
                Prison_Yell();
                break;
            case State.Prison_Walls:
                Prison_Walls();
                break;
            case State.Prison_Bed:
                Prison_Bed();
                break;

            case State.Prison_Door:
                Prison_Door();
                break;
            case State.Prison_Door_Push:
                Prison_Door_Push();
                break;
            case State.Prison_Door_Squeeze:
                Prison_Door_Squeeze();
                break;
            case State.Prison_Door_Key:
                Prison_Door_Key();
                break;

        }
    }

    void Opening()
    {
        text.text =
            "You and your wife, Catelyn, are on a trip to the city " +
            "to set up shop in the market. It's been a rough year, " +
            "and the last of your wares are with you in your cart. " +
            "As you're traveling along the path through the forest " +
            "that lies between your home and the city, you come upon " +
            "a camp that seems to be empty. It's quiet, but after you " +
            "pass men start rushing out from behind the trees. You " +
            "notice the leather clothes and weapons made from steel, " +
            "and realize that the men in front of you are bandits.\n\n" +

            "Press E to try and Escape";

        if (Input.GetKeyDown(KeyCode.E))
        {
            player_state = State.Opening_Bandits;
        }
    }

    void Opening_Bandits()
    {
        text.text =
            "You try to escape but there are too many of them. They " +
            "crowd around you, holding their daggers in the air, forming " +
            "a wall that your horse refuses to go through. Catelyn is " +
            "pulled down from the cart screaming, and you feel a sharp " +
            "pain on the back of your head. Everything dims as you fall " +
            "to the ground, unconciouss.\n\n" +

            "Press Space to continue.";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_state = State.Prison;
        }
    }

    void Prison()
    {
        text.text =
            "You wake up in a cell with stone walls, an area covered in " +
            "bundles of hay that you assume is a makeshift bed, and a bucket " +
            "that's filling the area with a foul scent.\n\n" +

            "Press Y to Yell for Catelyn\n" +
            "Press W to check out the Walls\n" +
            "Press B to check out the Bed\n" +
            "Press D to check out the Door\n";

        if (Input.GetKeyDown(KeyCode.Y))
        {
            player_state = State.Prison_Yell;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            player_state = State.Prison_Walls;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            player_state = State.Prison_Bed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            player_state = State.Prison_Door;
        }
    }

    void Prison_Visited()
    {
        text.text =
            "You're in the cell that you woke up in. The longer you stay " +
            "here, the more worried you are about Catelyn. And the stench " +
            "coming from the bucket is making you nauseous...\n\n" +

            "Press Y to Yell for Catelyn\n" +
            "Press W to check out the Walls\n" +
            "Press B to check out the Bed\n" +
            "Press D to check out the Door\n";

        if (Input.GetKeyDown(KeyCode.Y))
        {
            player_state = State.Prison_Yell;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            player_state = State.Prison_Walls;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            player_state = State.Prison_Bed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            player_state = State.Prison_Door;
        }
    }

    void Prison_Yell()
    {
        text.text =
            "You yell for your wife, but no one replies. Not even any " +
            "guards...\n\n" +

            "Press Space to return.";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_state = State.Prison_Visited;
        }
    }

    void Prison_Walls()
    {
        text.text =
            "The walls are made of stone, which means you're not in the " +
            "camp you were taken from. You wonder whether or not Catelyn " +
            "is OK. Is she here?\n\n" +

            "Press Space to return";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_state = State.Prison_Visited;
        }
    }

    void Prison_Bed()
    {
        if (FoundKey && !HayBundle)
        {
            text.text =
                "You see the bundles of hay that make up the bed and wonder... " +
                "would one of these be long enough to reach?\n\n" +

                "Press H to grab a bundle of Hay\n" +
                "Press Space to return.";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player_state = State.Prison_Visited;
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                HayBundle = true;
                player_state = State.Prison_Visited;
            }
        }
        else
        {
            text.text =
                "That looks uncomfortable.\n\n" +

                "Press Space to return.";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player_state = State.Prison_Visited;
            }
        }

    }

    void Prison_Door()
    {
        if (FoundKey && HayBundle)
        {
            text.text =
                "The door is locked. Outside is a stone corridor, but you " +
                "can't see much.\n\n" +

                "Press P to Push on the door\n" +
                "Press S to Squeeze through the bars\n" +
                "Press K to reach for the Key\n" +

                "Press Space to return to the cell";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player_state = State.Prison_Visited;
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                player_state = State.Prison_Door_Push;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                player_state = State.Prison_Door_Squeeze;
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                player_state = State.Prison_Door_Key;
            }
        }
        else
        {
            text.text =
                "The bar door is locked. Outside is a stone corridor, but you " +
                "can't see much.\n\n" +

                "Press P to Push on the door\n" +
                "Press S to Squeeze through the bars\n\n" +

                "Press Space to return to the cell";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player_state = State.Prison_Visited;
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                player_state = State.Prison_Door_Push;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                player_state = State.Prison_Door_Squeeze;
            }
        }
    }

    void Prison_Door_Push()
    {
        text.text =
            "You push on the bars but they won't budge.\n\n" +

            "Press Space to return.";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_state = State.Prison_Door;
        }
    }

    void Prison_Door_Squeeze()
    {
        if (HayBundle)
        {
            text.text =
                "You try to squeeze through the bars, but you can only get your " +
                "head through. You look around and see a set of keys hanging " +
                "next to the cell! You wonder if you can reach it with the bundle " +
                "of hay...\n\n" +

                "Press K to reach for the Key\n" +
                "Press Space to return.";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    player_state = State.Prison_Door;
                }
                else if (Input.GetKeyDown(KeyCode.K))
                {
                    player_state = State.Prison_Door_Key;
                }
        }
        else
        {
            text.text =
                "You try to squeeze through the bars, but you can only get your " +
                "head through. You look around and see a set of keys hanging " +
                "next to the cell! You wish you could reach them...\n\n" +

                "Press Space to return.";

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    player_state = State.Prison_Door;
                }
        }

        FoundKey = true;

    }

    void Prison_Door_Key()
    {
        text.text =
            "\n\n" +

            "Press Space to return.";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_state = State.Prison_Door;
        }
    }

}
