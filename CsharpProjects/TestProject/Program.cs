using System;

class Program {
    static void Main() {
        int maxPets = 8;
        string[,] ourAnimals = new string[maxPets, 6];
        
        for (int i = 0; i < maxPets; i++) {
            for (int j = 0; j < 6; j++) {
                ourAnimals[i, j] = "Unknown";
            }
        }

        bool exit = false;

        Console.WriteLine(@"Welcome to the Contoso PetFriends app. Your main menu options are:
1. List all of our current pet information
2. Add a new animal friend to the ourAnimals array
3. Ensure animal ages and physical descriptions are complete
4. Ensure animal nicknames and personality descriptions are complete
5. Edit an animal's age
6. Edit an animal's personality description
7. Display all cats with a specified characteristic
8. Display all dogs with a specified characteristic

Enter your selection number (or type Exit to exit the program):");

        do {
            string option = Console.ReadLine();

            switch(option.Trim().ToLower()) {
                case "1":
                    ListAllAnimals(ourAnimals);
                    break;
                case "2":
                    AddNewAnimal(ourAnimals);
                    break;
                case "3":
                    EnsureCompleteAgesAndDescriptions(ourAnimals);
                    break;
                case "4":
                    EnsureCompleteNicknamesAndPersonalities(ourAnimals);
                    break;
                case "5":
                    EditAnimalAge(ourAnimals);
                    break;
                case "6":
                    EditAnimalPersonality(ourAnimals);
                    break;
                case "7":
                    DisplayCatsWithCharacteristic(ourAnimals);
                    break;
                case "8":
                    DisplayDogsWithCharacteristic(ourAnimals);
                    break;
                case "exit":
                    Console.WriteLine("You have exited the program. Thanks for choosing us!");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please use numbers from 1 to 8.");
                    break;
            }
        } while(!exit);
    }

    static void ListAllAnimals(string[,] ourAnimals) {
        Console.WriteLine("Listing all current pet information:");
        for (int i = 0; i < ourAnimals.GetLength(0); i++) {
            if (ourAnimals[i, 0] != "Unknown") {
                Console.WriteLine($"Animal ID: {ourAnimals[i, 0]}, Species: {ourAnimals[i, 1]}, Age: {ourAnimals[i, 2]}, Physical Description: {ourAnimals[i, 3]}, Personality: {ourAnimals[i, 4]}, Nickname: {ourAnimals[i, 5]}");
            }
        }
    }

    static void AddNewAnimal(string[,] ourAnimals) {
        Console.WriteLine("Add a new animal friend to the ourAnimals array:");
        for (int i = 0; i < ourAnimals.GetLength(0); i++) {
            if (ourAnimals[i, 0] == "Unknown") {
                Console.Write("Enter Animal ID: ");
                ourAnimals[i, 0] = Console.ReadLine();

                Console.Write("Enter Species: ");
                ourAnimals[i, 1] = Console.ReadLine();

                Console.Write("Enter Age: ");
                ourAnimals[i, 2] = Console.ReadLine();

                Console.Write("Enter Physical Description: ");
                ourAnimals[i, 3] = Console.ReadLine();

                Console.Write("Enter Personality Description: ");
                ourAnimals[i, 4] = Console.ReadLine();

                Console.Write("Enter Nickname: ");
                ourAnimals[i, 5] = Console.ReadLine();

                Console.WriteLine("Animal added successfully!");
                break;
            }
        }
    }

    static void EnsureCompleteAgesAndDescriptions(string[,] ourAnimals) {
        Console.WriteLine("Ensuring animal ages and physical descriptions are complete:");
        for (int i = 0; i < ourAnimals.GetLength(0); i++) {
            if (ourAnimals[i, 0] != "Unknown") {
                if (ourAnimals[i, 2] == "Unknown" || ourAnimals[i, 3] == "Unknown") {
                    Console.WriteLine($"Animal ID: {ourAnimals[i, 0]} is missing age or physical description.");
                    Console.Write("Enter Age: ");
                    ourAnimals[i, 2] = Console.ReadLine();

                    Console.Write("Enter Physical Description: ");
                    ourAnimals[i, 3] = Console.ReadLine();
                }
            }
        }
    }

    static void EnsureCompleteNicknamesAndPersonalities(string[,] ourAnimals) {
        Console.WriteLine("Ensuring animal nicknames and personality descriptions are complete:");
        for (int i = 0; i < ourAnimals.GetLength(0); i++) {
            if (ourAnimals[i, 0] != "Unknown") {
                if (ourAnimals[i, 4] == "Unknown" || ourAnimals[i, 5] == "Unknown") {
                    Console.WriteLine($"Animal ID: {ourAnimals[i, 0]} is missing nickname or personality description.");
                    Console.Write("Enter Personality Description: ");
                    ourAnimals[i, 4] = Console.ReadLine();

                    Console.Write("Enter Nickname: ");
                    ourAnimals[i, 5] = Console.ReadLine();
                }
            }
        }
    }

    static void EditAnimalAge(string[,] ourAnimals) {
        Console.WriteLine("Edit an animal's age:");
        Console.Write("Enter Animal ID: ");
        string animalID = Console.ReadLine();
        for (int i = 0; i < ourAnimals.GetLength(0); i++) {
            if (ourAnimals[i, 0] == animalID) {
                Console.Write("Enter new Age: ");
                ourAnimals[i, 2] = Console.ReadLine();
                Console.WriteLine("Age updated successfully!");
                break;
            }
        }
    }

    static void EditAnimalPersonality(string[,] ourAnimals) {
        Console.WriteLine("Edit an animal's personality description:");
        Console.Write("Enter Animal ID: ");
        string animalID = Console.ReadLine();
        for (int i = 0; i < ourAnimals.GetLength(0); i++) {
            if (ourAnimals[i, 0] == animalID) {
                Console.Write("Enter new Personality Description: ");
                ourAnimals[i, 4] = Console.ReadLine();
                Console.WriteLine("Personality description updated successfully!");
                break;
            }
        }
    }

    static void DisplayCatsWithCharacteristic(string[,] ourAnimals) {
        Console.WriteLine("Display all cats with a specified characteristic:");
        Console.Write("Enter the characteristic to search for: ");
        string characteristic = Console.ReadLine().ToLower();
        for (int i = 0; i < ourAnimals.GetLength(0); i++) {
            if (ourAnimals[i, 1].ToLower() == "cat" && (ourAnimals[i, 3].ToLower().Contains(characteristic) || ourAnimals[i, 4].ToLower().Contains(characteristic))) {
                Console.WriteLine($"Animal ID: {ourAnimals[i, 0]}, Species: {ourAnimals[i, 1]}, Age: {ourAnimals[i, 2]}, Physical Description: {ourAnimals[i, 3]}, Personality: {ourAnimals[i, 4]}, Nickname: {ourAnimals[i, 5]}");
            }
        }
    }

    static void DisplayDogsWithCharacteristic(string[,] ourAnimals) {
        Console.WriteLine("Display all dogs with a specified characteristic:");
        Console.Write("Enter the characteristic to search for: ");
        string characteristic = Console.ReadLine().ToLower();
        for (int i = 0; i < ourAnimals.GetLength(0); i++) {
            if (ourAnimals[i, 1].ToLower() == "dog" && (ourAnimals[i, 3].ToLower().Contains(characteristic) || ourAnimals[i, 4].ToLower().Contains(characteristic))) {
                Console.WriteLine($"Animal ID: {ourAnimals[i, 0]}, Species: {ourAnimals[i, 1]}, Age: {ourAnimals[i, 2]}, Physical Description: {ourAnimals[i, 3]}, Personality: {ourAnimals[i, 4]}, Nickname: {ourAnimals[i, 5]}");
            }
        }
    }
}
