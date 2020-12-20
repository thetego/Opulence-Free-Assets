//////////////////////////////////////////////
//                                          //
//  Written by thetego (@muratcan.thetego)  //
//                                          //
//////////////////////////////////////////////
using UnityEngine;
using System.Collections.Generic;
using System.IO;


[System.Serializable]
public class Colour
{
    #region Variables
        public string name; //name for a new name to save
        public byte r,g,b,a; //r,g,b,a values for a new colour to save (0-255)
        public static List<Colour> Colours {get;} = new List<Colour>(); //list of saved colours
        static int Length; //length of saved colours list
    #endregion
    #region CustomColors
        public static Color32 Red {get;} = new Color32(255,0,0,255);
        public static Color32 Blue {get;} = new Color32(0,0,255,255);
        public static Color32 Green {get;} = new Color32(0,255,0,255);
        public static Color32 BlueCrayola {get;} = new Color32(33,118,255,255);
        public static Color32 Sunglow {get;} = new Color32(253,202,64,255);
        public static Color32 Orange {get;} = new Color32(247,125,36,255);
        public static Color32 SpaceBlack {get;} = new Color32(49,57,60,255);
        public static Color32 DarkPurple {get;} = new Color32(39,16,51,255);
        public static Color32 PastelCyan {get;} = new Color32(56,134,151,255);
        public static Color32 ShockingPink {get;} = new Color32(242,109,249,255);
        public static Color32 RoseBonBon {get;} = new Color32(235,75,152,255);
        public static Color32 LibertyPurple {get;} = new Color32(81,88,187,255);
        public static Color32 PrussianBlue {get;} = new Color32(4,53,101,255);
        public static Color32 MaximumGreen {get;} = new Color32(105,143,63,255);
        public static Color32 OxfordBlue {get;} = new Color32(10,18,42,255);
        public static Color32 ArmyGreen {get;} = new Color32(39,59,9,255);
        public static Color32 CuteOrange {get;} = new Color32(199,62,29,255);
        public static Color32 AmaranthRed {get;} = new Color32(218,62,82,255);
        public static Color32 ElectricBlue {get;} = new Color32(142,249,243,255);
        public static Color32 Turquoise {get;} = new Color32(41,231,205,255);
        public static Color32 PinkDick {get;} = new Color32(224,172,213,255);
    #endregion
    public static Color32 NewColour (byte r, byte g, byte b, byte a) //creates disposable colour
    {
        Color32 clr = new Color32 (r,g,b,a);
        return clr;
    }
    public static void LoadColours() //Loads all saved colours
    {
        //File.Decrypt(Application.dataPath+"/ColourClass"+"/CustomColours.txt");
        string[] lines = File.ReadAllLines(@"Assets/ColourClass/CustomColours.txt");
        int lineCount = File.ReadAllLines(@"Assets/ColourClass/CustomColours.txt").Length;
        string[] words;
        foreach (string item in lines)
        {
            words = item.Split(' ');
            string name = words[0];
            byte r = byte.Parse(words[1]);
            byte g = byte.Parse(words[2]);
            byte b = byte.Parse(words[3]);
            byte a = byte.Parse(words[4]);
            Colours.Add(new Colour(name,r,g,b,a));
        }
    }
    public static Color32 GetColour(string ColourName) //calls a saved colour
    {
       // File.Decrypt(Application.dataPath+"/ColourClass"+"/CustomColours.txt");
        Color32 tempColor = new Color32();
        bool found=false;
        foreach (Colour item in Colours)
        {
            if (item.name == ColourName)
            {
                tempColor.r = item.r;
                tempColor.g = item.g;
                tempColor.b = item.b;
                tempColor.a = item.a;
                found=true;
                Length=0;
                break;
            }
            else 
            {
                Length++;
            }
            if (Length>Colours.Count&&!found)
            {
                Debug.LogError("There is no declared colour called "+"'"+ColourName+"'"+" in colour list.");
                Length=0;
            }
        }
        return tempColor;
    }
    public static void RemoveColour(string ColourName) //removes a saved colour
	{
       
        foreach (Colour item in Colours)
        {
            if (item.name == ColourName)
            {
                //File.Decrypt(Application.dataPath+"/ColourClass"+"/CustomColours.txt");
                Colours.Remove(item);
                ReListColours();
                break;
            }
            else 
            {
                Length++;
            }
            if (Length>Colours.Count)
            {
                Debug.LogError("There is no declared colour called "+"'"+ColourName+"'"+" in colour list.");
                Length=0;
            }
        }
        
	}
    static void ReListColours () //Refreshes saved colour list
    {
        for(int i = 0; i < Colours.Count; i++)
        {
            if (i == 0)
                File.WriteAllText(Application.dataPath+"/ColourClass"+"/CustomColours.txt",Colours[i].name+" "+Colours[i].r.ToString()+" "+Colours[i].g.ToString()+" "+Colours[i].b.ToString()+" "+Colours[i].a.ToString()+"\n");
            else 
            {
                File.AppendAllText(Application.dataPath+"/ColourClass"+"/CustomColours.txt",Colours[i].name+" "+Colours[i].r.ToString()+" "+Colours[i].g.ToString()+" "+Colours[i].b.ToString()+" "+Colours[i].a.ToString()+"\n");
            }
        }
        
    }
    public static void CreateColour (string name,byte r, byte g, byte b, byte a) //Creates and saves a colour
    {
        if(Directory.Exists(Application.dataPath+"/ColourClass"))
        {
            
            if (File.Exists(Application.dataPath+"/ColourClass"+"/CustomColours.txt"))
            {
                Length=0;
                if (Colours.Count == 0)
                {
                    File.AppendAllText(Application.dataPath+"/ColourClass"+"/CustomColours.txt",name+" "+r.ToString()+" "+g.ToString()+" "+b.ToString()+" "+a.ToString()+"\n");
                    LoadColours();
                }
                else 
                {
                    foreach (Colour item in Colours)
                    {
                        if (name == item.name)
                        {
                            Debug.LogError("There is a color called "+"'"+name+"'"+" already.");
                        }
                        else 
                        {
                            Length++;
                        }
                        if (Length>=Colours.Count)
                        {
                            Debug.Log("added");
                            File.AppendAllText(Application.dataPath+"/ColourClass"+"/CustomColours.txt",name+" "+r.ToString()+" "+g.ToString()+" "+b.ToString()+" "+a.ToString()+"\n");
                            Length=0;
                        }
                }
                }

            }
            else 
            {
                File.Create(Application.dataPath+"/ColourClass"+"/CustomColours.txt");
                File.AppendAllText(Application.dataPath+"/ColourClass"+"/CustomColours.txt",name+" "+r.ToString()+" "+g.ToString()+" "+b.ToString()+" "+a.ToString());;
            }
        }
        else 
        {
            Directory.CreateDirectory(Application.dataPath+"/ColourClass");
            File.Create(Application.dataPath+"/ColourClass"+"/CustomColours.txt");
            File.AppendAllText(Application.dataPath+"/ColourClass"+"/CustomColours.txt",name+" "+r.ToString()+" "+g.ToString()+" "+b.ToString()+" "+a.ToString());
        }
    }
    public static Color32 ConvertToColour32 (Color color) //Converts the Color(0-1.0) to Color32(0-255)
    {
        
        int r = Mathf.RoundToInt(color.r*255);
        int g = Mathf.RoundToInt(color.g*255);
        int b = Mathf.RoundToInt(color.b*255);
        int a = Mathf.RoundToInt(color.a*255);
        Color32 clr = new Color32((byte)r,(byte)g,(byte)b,(byte)a);
        return clr;
    }
    public static Color ConvertToColour (Color32 color) //Converts the Color32(0-255) to Color(0-1.0)
    {
        
        float r = (float)color.r/255;
        float g = (float)color.g/255;
        float b = (float)color.b/255;
        float a = (float)color.a/255;
        Color clr = new Color(r,g,b,a);
        return clr;
    }
    public static void Reset () //Resets all saved colours;
    {
        File.Delete(Application.dataPath+"/ColourClass"+"/CustomColours.txt");
        Colours.Clear();
    }
    public Colour (string _name, byte _r,byte _g, byte _b, byte _a) //Custom colour structure
    {
        name = _name;
        r=_r;
        g=_g;
        b=_b;
        a=_a;
    }
}
