[System.Serializable]

public class Item
{
    public string name;
    public int count;
    public string itemType;

    public Item(string itemName, int itemCount, string type)
    {
        name = itemName;
        count = itemCount;
        itemType = type;
    }
}