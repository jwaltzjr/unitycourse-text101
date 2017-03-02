using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{

    public Text text;

    enum State
    {
        Opening, Opening_Bandits,
        Cell, Cell_Visited, Cell_Yell, Cell_Walls, Cell_Bed,
        Cell_Door, Cell_Door_Push, Cell_Door_Squeeze, Cell_Door_Key,
        Corridor, Corridor_Visited, Corridor_Door,
        Cell2,
        WestPath
    };

    State player_state;

    bool FoundKey;
    bool AquiredKey;
    bool HayBundle;
    bool EscapedPrison;

    // Use this for initialization
    void Start()
    {
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {
        print(player_state);

        switch (player_state)
        {
            case State.Restart:
                BeginGame();
                break;

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
            case State.Corridor_Visited:
                Corridor_Visited();
                break;
            case State.Corridor_Door:
                Corridor_Door();
                break;

            case State.Cell2:
                Cell2();
                break;

            case State.WestPath:
                WestPath();
                break;
        }
    }

    void BeginGame()
    {
        print("Game started.");
        player_state = State.Opening;

        FoundKey = false;
        AquiredKey = false;
        HayBundle = false;
        EscapedPrison = false;
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
                "The door is locked, but you have the key!. Outside is a stone" +
                "corridor, but you can't see much.\n\n" +

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
            "You reach out for the keys, but it's difficult to get the hay into the " +
            "key ring. After a few tries, you finally get it!\n\n" +

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
            "You take a step forward, keeping an eye out for anyone, but it's hard to " +
            "see in the dark. You notice a staircase on one end of the hallway that " +
            "leads to a door with a window. Through it, you can see the flickering " +
            "light of a fire. There is another door on the other side of the hall, but " +
            "there's no window on this one.\n\n" +

            "Press S to take the Stairs to the door with a window.\n" +
            "Press D to take the opposite Door, into the unknown.";

        if (Input.GetKeyDown(KeyCode.S))
        {
            player_state = State.WestPath;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            player_state = State.Corridor_Door;
        }
    }

    void Corridor_Visited()
    {
        text.text =
            "You're back in the corridor outside of your cell. It's very dark.\n\n" +

            "Press S to take the Stairs to the door with a window.\n" +
            "Press D to take the opposite Door, into the unknown.";

        if (Input.GetKeyDown(KeyCode.S))
        {
            player_state = State.WestPath;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            player_state = State.Corridor_Door;
        }
    }

    void Corridor_Door()
    {
        text.text =
            "You crack the door and peer through. You notice a man sitting at the table, " +
            "but he doesn't notice you.\n\n" +

            "Press C to continue.\n" +
            "Press Space to return.";

        if (Input.GetKeyDown(KeyCode.C))
        {
            player_state = State.Cell2;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            player_state = State.Corridor_Visited;
        }
    }

    void Cell2()
    {
        text.text =
            "You walk in, trying to be as quiet as possible, but the man hears the door " +
            "creak. He immediately jumps to his feet and draws a sword, ready for a " +
            "fight. You attempt to grab him but he plunges the sword into your chest. " +
            "Amidst the pain, you hear your wife crying. Was she here? Or is your mind " +
            "playing tricks on you? You ponder this, but there's too much blood in your " +
            "mouth to call for her. The world fades to black...\n\n" +

            "GAME OVER\n\n" +
            "Press Space to try again.";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_state = State.Restart;
        }
    }

    void WestPath()
    {
        if (EscapedPrison)
        {
            text.text =
            "WestPath text.\n\n" +

            "Press Space to return.";
        }
        else
        {
            text.text =
            "You take the stairs and peek through the window. You don't see anyone, so " +
            "you open the door. To your left you see the source of the flickering light: " +
            "a group of bandits are lounging around a fire, talking and laughing too loud " +
            "to notice you. Across from you is another building, and there's a path headed " +
            "off to your right.\n\n" +

            "Press F to head towards the Fire.\n" +
            "Press B to go into the Building.\n" +
            "Press P to follow the Path." + 
            "Press C to go back to the prison Cells.\n"; 
        }

        EscapedPrison = true;

        // INPUT CONTROLS
    }

}
