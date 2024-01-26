using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MemoryManager : MonoBehaviour
{
    private bool enableTelescopeControlsOnMemoryEnd = false;
    [SerializeField] private GameObject telescopeView;
    [SerializeField] private GameObject[] memories;
    private GameObject memoryToClose;
    private List<Cutscene> cutscenes = new List<Cutscene>(new Cutscene[7]);

    void Awake()
    {
        //Globals.Instance.Cat.Input.memory.CloseWindow.performed += CloseMemory;
        Globals.Instance.MemoryManager = this;
    }

    private void Start()
    {
        cutscenes[0] = new Cutscene(new List<string>(){            
            "Oh hoho\n I remember this",
            "You always used to\n love hiding",
            "In this when you\n were younger!",
            "Thank you,\n Sabor"
        }, Cutscenes.Box, this);
        cutscenes[1] = new Cutscene(new List<string>(){            
            "Oh hoho\n I remember this",
            "You chased this\n for hours",
            "You had so\n much energy!",
            "Thank you,\n Sabor"
        }, Cutscenes.Fish, this);
        cutscenes[2] = new Cutscene(new List<string>(){            
            "Oh hahaha\n This is your favourite",
            "The Christmas tree\n always surprised you",
            "You'd get lost in there\n and ask for help",
            "Thank you,\n Sabor"
        }, Cutscenes.Bauble, this);
        cutscenes[3] = new Cutscene(new List<string>(){            
            "Oh haha!\n That shoe!",
            "You always used to\n hide this from",
            "Me and it\n took me days",
            "To find it\n every time!",
            "Thank you,\n Sabor"
        }, Cutscenes.Shoe, this);
        cutscenes[4] = new Cutscene(new List<string>(){            
            "Oh yes!\n My wedding photo",
            "You both got on\n so well",
            "I wish she were\n still here with us",
            "Thank you for,\n the memory Sabor"
        }, Cutscenes.Polaroid, this);
        cutscenes[5] = new Cutscene(new List<string>(){            
            "Oh hoho\n I remember this",
            "You always brought them\n to my wife",
            "Somehow you knew\n they were her favourite",
            "Thank you,\n Sabor"
        }, Cutscenes.Flower, this);
        cutscenes[6] = new Cutscene(new List<string>(){            
            "Oh wow Sabor\n You've been such",
            "A good kitty\n reminding me of the past",
            "But now I have a mess\n to clean up",
            "Thank you,\n Sabor",
            "I love you",
            ""
        }, Cutscenes.Fin, this);
    }
    
    public void CloseMemory(InputAction.CallbackContext _)
    {
        Globals.Instance.StopCutscene();
        Globals.Instance.Cat.Input.memory.Disable();
        if (enableTelescopeControlsOnMemoryEnd) {
            telescopeView.SetActive(true);
            Globals.Instance.Cat.Input.telescope.Enable();
        }
        else Globals.Instance.Cat.Input.freeroam.Enable();
        if (Globals.Instance.ObjectiveComplete == true) DisplayMemory(Cutscenes.Fin);
        //memoryToClose.SetActive(false);
    }

    public void DisplayMemory(Cutscenes cutscene)
    {
        Globals.Instance.StartCutscene();
        if (cutscene == Cutscenes.Fin)
        {
            foreach (Cutscene cuts in cutscenes)
        {
            if (cuts.cutsceneName == cutscene)
            {
                cuts.DisplayCutscene();
            }
        }
        }
        GameObject memoryImage = memories[(int)cutscene];
        //memoryImage.SetActive(true);
        enableTelescopeControlsOnMemoryEnd = Globals.Instance.Cat.Input.telescope.enabled;
        if (!enableTelescopeControlsOnMemoryEnd && cutscene != Cutscenes.Fin)
        {
            memoryImage.GetComponent<MemoryImage>().memoryConstellationButton.Unlock();

        } else
        {
            telescopeView.SetActive(false);
        }
        foreach (Cutscene cuts in cutscenes)
        {
            if (cuts.cutsceneName == cutscene)
            {
                cuts.DisplayCutscene();
            }
        }
        Globals.Instance.Cat.Input.memory.Enable();
        if (Globals.Instance.Cat.Input.freeroam.enabled) Globals.Instance.Cat.Input.freeroam.Disable();
        if (Globals.Instance.Cat.Input.telescope.enabled) Globals.Instance.Cat.Input.telescope.Disable();
    }

    
public class Cutscene     
{
    private List<string> textToShow;
    public Cutscenes cutsceneName;
    private MemoryManager memoryManager;
    int index = 0;

    public Cutscene(List<string> textToShow, Cutscenes name, MemoryManager memoryManager)
    {
        this.textToShow = textToShow;
        this.cutsceneName = name;
        this.memoryManager = memoryManager;
    }

    private void ShowNextItem()
    {
        if (Globals.Instance.Man.SetText(textToShow[index]))
        index++;
        if (index >= textToShow.Count)
        {
            EndCutscene();
        }
    }

    public void ShowNext(InputAction.CallbackContext _)
    {
        ShowNextItem();
    }


    public void DisplayCutscene()
    {
        ShowNextItem();
        Globals.Instance.Cat.Input.memory.CloseWindow.performed += ShowNext;
    }

    public void EndCutscene()
    {
        Globals.Instance.Cat.Input.memory.CloseWindow.performed -= ShowNext;
        Globals.Instance.Cat.Input.memory.CloseWindow.performed += Return;
    }

    public void Return(InputAction.CallbackContext _)
    {
        memoryManager.CloseMemory(_);
        index = 0;
        Globals.Instance.Cat.Input.memory.CloseWindow.performed -= Return;
        if (cutsceneName == Cutscenes.Fin) SceneManager.LoadScene(0);
    }
}
}
public enum Cutscenes
{
    Undefined,
    Fish,
    Flower,
    Box,
    Bauble,
    Polaroid,
    Shoe,
    Fin
}
