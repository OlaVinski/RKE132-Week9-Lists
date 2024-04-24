string folderPath = @"C:\Users\raigl\source\data";
string fileName = "shoppingList.txt";
string filePath = Path.Combine(folderPath, fileName);

List<string> myShoppingList = new List<string>();

if (File.Exists(filePath))
{
   myShoppingList = GetItemsFromUser();
   File.WriteAllLines(filePath, myShoppingList);
}
else
{
   File.Create(filePath).Close();
   Console.WriteLine($"File {fileName} has been created.");
   myShoppingList = GetItemsFromUser();
   File.WriteAllLines(filePath, myShoppingList);
}
// peale faili loomist tuleb fail kinni panna
// kui fail jääb lahti, siis ei saa teine käsk seda faili kasutada
// ShowItemsFromList(myShoppingList);

static List<string> GetItemsFromUser()
{
    List<string> userList = new List<string>();

    while (true)
    {
        Console.WriteLine("Add an item (add)/ Exit (exit):");
        string userChoice = Console.ReadLine();

        if (userChoice == "add")
        {
            Console.WriteLine("Enter an item:");
            string userItem = Console.ReadLine();
            userList.Add(userItem);
        }
        else
        {
            Console.WriteLine("Bye!");
            break;
        }
    }
    return userList;
}



//ühes listis võib olla ainult ühte tüüpi andmed: kui string tüüpi, siis ainult string tüüpi

static void ShowItemsFromList(List<string> someList)
{
    Console.Clear();

    int listLength = someList.Count;
    Console.WriteLine($"You have added {listLength} items to your shopping list.");

    int i = 1; //sellepärast foreach plokist väljas, sest ploki sees elab väärtus ainult nii kaua kui ploki sees programm töötab
    foreach (string item in someList)
    {
        Console.WriteLine($"{i}. {item}");
        i++;
    }
}

//massiivi pikkus on fikseeritud
//listid on paindlikumad 