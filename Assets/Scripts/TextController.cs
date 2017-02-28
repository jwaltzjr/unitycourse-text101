using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// TEST GIT BRANCHING

public class TextController : MonoBehaviour
{

    public Text text;

    enum State
    {
        Opening, Opening_Bandits,
        Cell, Cell_Visited, Cell_Yell, Cell_Walls, Cell_Bed,
        Cell_Door, Cell_Door_Push, Cell_Door_Squeeze, Cell_Door_Key,
        Corridor,
    };

    State player_state;

    bool FoundKey;
    bool AquiredKey;
    bool HayBundle;

    // Use this for initialization
    void Start()
    {
        player_state = State.Opening;

        FoundKey = false;
        AquiredKey = false;
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

            case State.Cell:
                Cell();
                break;
            case State.Cell_Visited:
                Cell_Visited();
                break;
            case State.Cell_Yell:
                Cell_Yell();
                break;
            case State.Cell_Walls:
                Cell_Walls();
                break;
            case State.Cell_Bed:
                Cell_Bed();
                break;

            case State.Cell_Door:
                Cell_Door();
                break;
            case State.Cell_Door_Push:
                Cell_Door_Push();
                break;
            case State.Cell_Door_Squeeze:
                Cell_Door_Squeeze();
                break;
            case State.Cell_Door_Key:
                Cell_Door_Key();
                break;

            case State.Corridor:
                Corridor();
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
            player_state = State.Cell;
        }
    }

    void Cell()
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
            player_state = State.Cell_Yell;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            player_state = State.Cell_Walls;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            player_state = State.Cell_Bed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            player_state = State.Cell_Door;
        }
    }

    void Cell_Visited()
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
            player_state = State.Cell_Yell;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            player_state = State.Cell_Walls;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            player_state = State.Cell_Bed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            player_state = State.Cell_Door;
        }
    }

    void Cell_Yell()
    {
        text.text =
            "You yell for your wife, but no one replies. Not even any " +
            "guards...\n\n" +

            "Press Space to return.";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_state = State.Cell_Visited;
        }
    }

    void Cell_Walls()
    {
        text.text =
            "The walls are made of stone, which means you're not in the " +
            "camp you were taken from. You wonder whether or not Catelyn " +
            "is OK. Is she here?\n\n" +

            "Press Space to return";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_state = State.Cell_Visited;
        }
    }

    void Cell_Bed()
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
                player_state = State.Cell_Visited;
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                HayBundle = true;
                player_state = State.Cell_Visited;
            }
        }
        else
        {
            text.text =
                "That looks uncomfortable.\n\n" +

                "Press Space to return.";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player_state = State.Cell_Visited;
            }
        }

    }

    void Cell_Door()
    {
        if (AquiredKey)
        {
            text.text =
                "The door is locked, but you have the key!. Outside is a stone corridor, but you " +
                "can't see much.\n\n" +

                "Press U to unlock the cell door\n" +
                "Press Space to return to the cell";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player_state = State.Cell_Visited;
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                player_state = State.Corridor;
            }
        }
        else if (FoundKey && HayBundle)
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
                player_state = State.Cell_Visited;
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                player_state = State.Cell_Door_Push;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                player_state = State.Cell_Door_Squeeze;
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                player_state = State.Cell_Door_Key;
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
                player_state = State.Cell_Visited;
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                player_state = State.Cell_Door_Push;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                player_state = State.Cell_Door_Squeeze;
            }
        }
    }

    void Cell_Door_Push()
    {
        text.text =
            "You push on the bars but they won't budge.\n\n" +

            "Press Space to return.";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_state = State.Cell_Door;
        }
    }

    void Cell_Door_Squeeze()
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
                    player_state = State.Cell_Door;
                }
                else if (Input.GetKeyDown(KeyCode.K))
                {
                    player_state = State.Cell_Door_Key;
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
                    player_state = State.Cell_Door;
                }
        }

        FoundKey = true;

    }

    void Cell_Door_Key()
    {
        text.text =
            "You reach out for the keys, but it's difficult to get the hay into the key ring. " +
            "After a few tries, you finally get it!\n\n" +

            "Press Space to return.";

        AquiredKey = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_state = State.Cell_Door;
        }
    }

    void Corridor()
    {
        text.text =
            "Corridor Text\n\n" +

            "Press buttons to do stuff.";

        AquiredKey = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_state = State.Corridor;
        }
    }

}
