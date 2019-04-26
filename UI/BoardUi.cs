using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class BoardUi : MonoBehaviour {
	public Image[] imageSlots;
	public Object[] imageSlotsPicture;
	public bool[] isImageVisable;

    public string ScreenCaPDir;
    public string Name;
    private int ScreenCaps;

    public Sprite[] sprites;
    // Use this for initialization
    void Start () {
		Invoke ("newStart", 0.5f);
        Name = "CrimePic";
        ScreenCaPDir = Application.dataPath + "/Resources/CustomPictures/";
       
          ConvertPNGS();
    }
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{ if (SceneManager.GetActiveScene ().name =="DetectiveOffice") {
			newStart();

		}
	}
	void newStart(){
		for(int i =0; i< GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic.Length; i++){
			imageSlots[i] = GameObject.Find ("imageSlots").transform.GetChild(i).GetComponent<Image>();
			if(GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic[i] != null){
                //	imageSlotsPicture = GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic as Sprite[];
                    imageSlotsPicture = sprites;
                    imageSlots[i].sprite = imageSlotsPicture[i] as Sprite;

				for(int p =0; p< GameObject.Find("MurderManager").GetComponent<inventory>().invo.clueNames.Count; p++){
					if( GameObject.Find("MurderManager").GetComponent<inventory>().invo.clueNames[p] == imageSlotsPicture[i].name){
						isImageVisable[i] =true;
					}
						
				}
				if(isImageVisable[i]==true){
					imageSlots[i].GetComponent<Image>().color = new Color(1f,1f,1f,1f);
					imageSlots[i].GetComponent<Button>().interactable= true;
				}else{
					imageSlots[i].GetComponent<Image>().color = new Color(1f,1f,1f,1f);
					imageSlots[i].GetComponent<Button>().interactable= true;
				//	print(imageSlotsPicture[i].name);
				}
			}
		}
	}
    void ConvertPNGS()
    {
        Texture2D texture = null;

        byte[] fileData;

        if (File.Exists(ScreenCaPDir + Name + (ScreenCaps + 1) + ".png"))
        {
            Debug.LogError(ScreenCaPDir + Name + (ScreenCaps + 1) + ".png" + " Does exsist");
            fileData = File.ReadAllBytes((ScreenCaPDir + Name + (ScreenCaps + 1) + ".png"));
            texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);

            //Texture2D myTexture = Resources.Load<Texture2D>("/CustomPictures/" + Name + (ScreenCaps + 1) + ".png");
            // Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
        }


        for (int i = 0; i < GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic.Length; i++)
        {
            Debug.LogError(ScreenCaPDir + Name + (ScreenCaps + 1) + ".png" + " Does not exsist");
            sprites[i] = Sprite.Create(GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic[i], new Rect(0, 0, GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic[i].width, GameObject.Find("MurderManager").GetComponent<SceneController>().allSceneCluePic[i].height), new Vector2(0.5f, 0.5f));
            sprites[i].name = Name + (ScreenCaps + 1);
        }
        //imageSlots[0].GetComponent<Image>().sprite = sprite;
    }
   
    // Update is called once per frame
    void Update () {


	}
}
