using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class FileManager : MonoBehaviour
{
    public static FileManager Instance;
    public static Action<LevelData> OnLevelLoadComplete;

    [SerializeField] private LevelData levelData;

    [SerializeField] private string _fileName = "level_4x4_0_3ACD03A8.txt";
    [SerializeField] private string _filePath = "Assets\\Levels\\";

    [SerializeField] private int[] _level;
    [SerializeField] private int[] _visible;
    [SerializeField] private List<string> _hints = new List<string>();


    private bool levelHasLoaded, visibleHasLoaded, hintsHasLoaded;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Initialise();
        ReadFromFile();   
    }

    private void Initialise()
    {
        levelHasLoaded = false;
        visibleHasLoaded = false;
        hintsHasLoaded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadFromFile()
    {
        levelData = new LevelData();
        using (StreamReader sr = new StreamReader(_filePath + _fileName))
        {
            string line;
            // Read and display lines from the file until the end of
            // the file is reached.
            while ((line = sr.ReadLine()) != null)
            {
                //Debug.Log(line);
                if(line.Contains("Level"))
                {
                    string numbers = line.Substring(6, line.Length - 7);
                    string[] numbersAsStrings = numbers.Split(", ");
                    _level = new int[numbersAsStrings.Length];

                    for(int i = 0; i < numbersAsStrings.Length; i++)
                    {
                        _level[i] = Int32.Parse(numbersAsStrings[i]);
                    }

                    Debug.Log("Level loaded...");
                    levelData.SetLevel(_level);
                    levelHasLoaded = true;
                }

                if(line.Contains("Visible"))
                {
                    string numbers = line.Substring(8, line.Length - 9);
                    string[] numbersAsStrings = numbers.Split(", ");
                    _visible = new int[numbersAsStrings.Length];

                    for (int i = 0; i < numbersAsStrings.Length; i++)
                    {
                        _visible[i] = Int32.Parse(numbersAsStrings[i]);
                    }

                    Debug.Log("Visible loaded...");
                    levelData.SetVisible(_visible);
                    visibleHasLoaded = true;
                }

                if(line.Contains("Hint"))
                {
                    string hint = line.Substring(5, line.Length - 6);
                    _hints.Add(hint);
                }
            }
            Debug.Log("Hints loaded...");
            levelData.SetHints(_hints);
            hintsHasLoaded = true;
        }

        StartGame();
    }

    private void StartGame()
    {
        if (levelHasLoaded && visibleHasLoaded && hintsHasLoaded)
        {
            OnLevelLoadComplete?.Invoke(levelData);
        }
    }
}
