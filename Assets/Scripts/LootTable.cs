using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public List<Loot> lootList = new List<Loot>();

    //public int total;

    // Start is called before the first frame update
    void Start()
    {
        //we can use this to sort our list according to the drop chance of each
        //item in the list in decending order. x first and then y for ascending
        //order
        lootList.Sort((x, y) => y.dropChance.CompareTo(x.dropChance));

        //loop through the loot in the list and add all drop chances together
        //to get the total.
        /*foreach (Loot loot in lootList)
        {
            total += loot.dropChance;
        }*/
    }

    Loot SelectLoot()
    {
        int randomNumber = Random.Range(0, 100);

        print("Initial random number: " + randomNumber);

        List<Loot> possibleItems = new List<Loot>();

        foreach (Loot item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
            else
            {
                randomNumber -= item.dropChance;
                print("After checking loot: " + randomNumber);
            }
            
        }
        if (possibleItems.Count > 0)
        {
            int index = Random.Range(0, possibleItems.Count);
            Loot droppedItem = possibleItems[index];
            return droppedItem;
        }

        Debug.Log("No loot dropped");
        return null;
    }
    public void InstantiateLoot(Vector2 position)
    {
        Loot droppedItem = SelectLoot();
        if (droppedItem != null)
        {
            Instantiate(droppedItem, position, Quaternion.identity);
        }
    }

    //banana = 50%
    //strawberry = 30%
    //coconut = 20%
    //randomNumber = 60
    //is 60 < 50
    //no, 60 - 50 = 10 (banana doesn't spawn)
    //is 10< 30?
    //yes, add strawberry to list
    //is 10 < 20?
    //yes, add coconut to list
    //randomise between the two
}
