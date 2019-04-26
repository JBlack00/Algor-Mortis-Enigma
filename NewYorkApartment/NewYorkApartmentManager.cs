using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewYorkApartmentManager : MonoBehaviour {
    public string[] PossibleMurders = { "SelfDefenceMurder", "MurderFramedSuicide"};
    public List<string> CluesNeeded = new List<string>();
    public string thisMurder;
    

    // Use this for initialization
    void Start()
    {
        

    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
          
            if (GetComponent<SaveToText>().ReadStringLine("GameStatus.txt", 1) == "NoClue")
            {
                GetComponent<SaveToText>().WriteStringLine("CluesActive", 1, "GameStatus.txt");
                thisMurder = PickRndMurder();
                Debug.Log("newyork murder is " + thisMurder);
                GetListOfCluesNeeded();
            }
            else
            {
                Debug.Log(GetComponent<SaveToText>().ReadStringLine("GameStatus.txt", 0));
            }
        }
        if (SceneManager.GetActiveScene().name == "DetectiveOffice")
        {
           
        }
    }
    void OnApplicationQuit()
    {
        GetComponent<SaveToText>().WriteStringLine("NoClue", 1, "GameStatus.txt");
        for (int i = 0; i < 6; i++)
        {
            GetComponent<SaveToText>().WriteStringLine("NoStatement", 1, "Statements/Statement" + (i + 1) + ".txt");
            Debug.Log("Statements/Statement" + (i + 1) + ".txt");
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
    private string PickRndMurder()
    {
        int RND = Random.Range(0,1);
        switch (RND)
        {
            case 0:
                return PossibleMurders[0];
                break;
            case 1:
                return PossibleMurders[1];
                break;
            default:
                return PossibleMurders[0];
                break;
        }

    }

    private void GetListOfCluesNeeded()
    {
        if (thisMurder == PossibleMurders[0])
        {
            CluesNeeded.Add("Blood");
            CluesNeeded.Add("Autopsy");
            CluesNeeded.Add("PhotoSmashed");
            CluesNeeded.Add("PlantedKife");
            CluesNeeded.Add("BrokenWindow");
            GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic = Resources.LoadAll<Texture2D>("RichAp/ClueImages/Scenario1");
            SetStatements(0);
        }
        else if (thisMurder == PossibleMurders[1])
        {
            CluesNeeded.Add("Autopsy");
            CluesNeeded.Add("SuicideNote");
            CluesNeeded.Add("WineGlassPoison");
            CluesNeeded.Add("Gun");
            CluesNeeded.Add("Gloves");
            GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic = Resources.LoadAll<Texture2D>("RichAp/ClueImages/Scenario2");
            SetStatements(1);
        }

       

        for (int i = 0; i < CluesNeeded.Count; i++)
        {
            Debug.Log("clues needed in this level " + CluesNeeded[i].ToString());
        }

    }

    void SetStatements(int MurderNumber)
    {
        SaveToText SaveToTextScript = GetComponent<SaveToText>();
        string MurderStatement = "";
        string WitnessStatement = "";
        switch (MurderNumber)
        {
            case 0:
                MurderStatement = "Some tall guy attacked me with a knife, then he shot my parents, he just looked back at me bleeding and left...";
                WitnessStatement = "i dont want to talk. i get want my mom and dad";
                for (int i = 1; i < 7; i++)
                {
                    SaveToTextScript.WriteStringLine(GetRandomNonHelpfulStatement(), 0, "Statements/Statement" + i + ".txt");
                    Debug.Log(GetComponent<RandomMurdererController>().RNGMurder);
                    if (i - 1 == GetComponent<RandomMurdererController>().RNGMurder)
                    {
                        SaveToTextScript.WriteStringLine(MurderStatement, 0, "Statements/Statement" + i + ".txt");
                        if (GetComponent<RandomMurdererController>().RNGMurder == 6)
                        {
                            SaveToTextScript.WriteStringLine(WitnessStatement, 0, "Statements/Statement" + (i - 1) + ".txt");
                        }
                        if (GetComponent<RandomMurdererController>().RNGMurder == 0)
                        {
                            SaveToTextScript.WriteStringLine(WitnessStatement, 0, "Statements/Statement" + (i + 1) + ".txt");
                        }
                        if (GetComponent<RandomMurdererController>().RNGMurder != 0 && GetComponent<RandomMurdererController>().RNGMurder != 6)
                        {
                            SaveToTextScript.WriteStringLine(WitnessStatement, 0, "Statements/Statement" + (i + 1) + ".txt");
                        }
                    }
                }
                break;
            case 1:
                MurderStatement = "i.. i watch him die. a man ran and went out the window, i was so scared";
                WitnessStatement = "i wish i saw something but i did not";
                for (int i = 1; i < 7; i++)
                {
                    SaveToTextScript.WriteStringLine(GetRandomNonHelpfulStatement(), 0, "Statements/Statement" + i + ".txt");
                    Debug.Log(GetComponent<RandomMurdererController>().RNGMurder);
                    if (i - 1 == GetComponent<RandomMurdererController>().RNGMurder)
                    {
                        SaveToTextScript.WriteStringLine(MurderStatement, 0, "Statements/Statement" + i + ".txt");
                        if (GetComponent<RandomMurdererController>().RNGMurder == 6)
                        {
                            SaveToTextScript.WriteStringLine(WitnessStatement, 0, "Statements/Statement" + (i - 1) + ".txt");
                        }
                        if (GetComponent<RandomMurdererController>().RNGMurder == 0)
                        {
                            SaveToTextScript.WriteStringLine(WitnessStatement, 0, "Statements/Statement" + (i + 1) + ".txt");
                        }
                        if (GetComponent<RandomMurdererController>().RNGMurder != 0 && GetComponent<RandomMurdererController>().RNGMurder != 6)
                        {
                            SaveToTextScript.WriteStringLine(WitnessStatement, 0, "Statements/Statement" + (i + 1) + ".txt");
                        }
                    }
                }
                break;

           
        }
    }

    string GetRandomNonHelpfulStatement()
    {

        switch (Random.Range(0, 11))
        {
            case 0:
                return "Am sorry but i did not even know the people you're talking about";
                break;
            case 1:
                return "I was out that night with my girl";
                break;
            case 2:
                return "I was sleeping early that night due to work";
                break;
            case 3:
                return "I heard nothing but i had my headset on cause i was gaming all night";
                break;
            case 4:
                return "AM NOT SPEAKING WITHOUT A LAWER";
                break;
            case 5:
                return "I wish i could help but i dont know what you are talking about";
                break;
            case 6:
                return "All you cops do is get me in here when i've done nothing wrong";
                break;
            case 7:
                return "I did not kill anyone and if you had the evidence you would not be talking to me, would you!";
                break;
            case 8:
                return "Oh please why would i kill them, i hardly know them";
                break;
            case 9:
                return "please am innocent, i've never hurt anyone";
                break;
            case 10:
                return "Either arrest me or let me go already";
                break;
            default:
                return "Am sorry but i did not even know the people you're talking about";
                break;
        }
    }
}
