using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

   
    [Header("Database")]
    public Database Current_Database;


    [Header("MAP_MOVEMENT")]
    public float speed = 1;
    public GameObject Player;
    public Camera PlayerChildCamera;
    private GameObject targetpos;
    public GameObject MainMenuPanel, BattlePanel, OkPanel, VillagePanel;


    [Header("Click_Menu")]
    public bool _buttonDown = false;
    public GameObject Menupanel, _CanGobtn, _CantGobtn;
    public TextMeshProUGUI distancetxt, endurancetxt, menuWarningtxt;
    private int temp_EnduranceRequiredValue = 0;

    [Header("BATTLE_MANAGER")]
    public List<Slider> BattleSlider = new List<Slider>();
    public List<int> BattleSliderValueMix = new List<int>();
    public List<int> HpPerValue = new List<int>();
    public List<int> ATKPerValue = new List<int>();
    public int totalHpPlayer, totalATKPlayer, totalHpEnemy, totalATKEnemy;
    public List<TextMeshProUGUI> BattleSliderUpperText = new List<TextMeshProUGUI>();
    public TextMeshProUGUI Total_Calcaulation_txt, Total_ATk_Calucation_txt, Total_CalcaulationEnemy_Hp, Total_CalcaulationEnemy_ATK, BattleLOGtxt;
    public GameObject BattleMenuPanel;

    [Header("Upgrade_Panel")]
    public GameObject UpgradeMenuPanel;
    public TextMeshProUGUI upgradeStatus;
    public List<TextMeshProUGUI> ListofUpgradeObject = new List<TextMeshProUGUI>();


    [Header("UI")]
    public Slider sliderHere;
    public TextMeshProUGUI LevelText;
    [Header("Time_Zone")]
    public TimeZone GetDay;
    private string CurrentDay;

    public TextMeshProUGUI currentTimezone;



    public static GameManager Instance;

    private void Awake()
    {
     //   PlayerPrefs.DeleteAll();

        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadValue_info();
    }


    void Start()
    {
        updateDbLvl(0);
        updateDbEnd(0);
        updateDbSliderValue(0);

     //   Player.transform.position = new Vector3(-1.944226f,0,0);

        totalHpEnemy = int.Parse(Total_CalcaulationEnemy_Hp.text.ToString());
        totalATKEnemy = int.Parse(Total_CalcaulationEnemy_ATK.text.ToString());

        for (int i = 0; i < BattleSlider.Count; i++)
        {
            BattleSlider[i].maxValue = BattleSliderValueMix[i];
        }
        GetDay.DayIndex = PlayerPrefs.GetInt("DayIndex", 1);
        CurrentDay = GetDay.CurrentDay(GetDay.DayIndex);
        currentTimezone.text = CurrentDay;
        InvokeRepeating("daySwitcher", 20, 20);
       

    }

    

    void daySwitcher()
    {
        CurrentDay = GetDay.NextDay();
        currentTimezone.text = CurrentDay;
    }


    private void LateUpdate()
    {
        SaveValue_info();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = Camera.main.WorldToScreenPoint(Player.transform.position);



        if (Input.GetMouseButtonDown(0) && !_buttonDown)
        {

          
            Vector3 mousePos = PlayerChildCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
              //    Debug.Log(hit.collider.gameObject.name);
                targetpos = hit.collider.gameObject;
               
                // targetpos.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                int days = Mathf.RoundToInt(Vector2.Distance(Player.transform.position, targetpos.transform.position));
                //      days -= 1;

                _buttonDown = true;

                Menupanel.SetActive(true);
                distancetxt.text = days.ToString() + " Days";


                temp_EnduranceRequiredValue = days * 2;
                endurancetxt.text = temp_EnduranceRequiredValue.ToString() + " Endurance";

                if (Current_Database.Current_Endurance < temp_EnduranceRequiredValue)
                {
                    menuWarningtxt.text = "Endurance is low you cant travel";
                    _CantGobtn.SetActive(true);
                    _CanGobtn.SetActive(false);
                }
                else
                {
                    menuWarningtxt.text = "Are you sure you want to visit";
                    _CantGobtn.SetActive(false);
                    _CanGobtn.SetActive(true);
                }
            }
        }


        // UPGradeWork HERE

        if (ListofUpgradeObject.Count < 4)
            return;

        ListofUpgradeObject[0].text = "Gold :" + Current_Database.Current_Gold.ToString();
        ListofUpgradeObject[1].text = "Weapons :" + Current_Database.Current_Weapon.ToString();
        ListofUpgradeObject[2].text = "Food :" + Current_Database.Current_Food.ToString();
        ListofUpgradeObject[3].text = "Coal :" + Current_Database.Current_Coal.ToString();
    }

    public void UpdateSlider()
    {
        int tempHp = 0;
        int tempAtk = 0;
        for (int i = 0; i < BattleSlider.Count; i++)
        {
            int temp = Mathf.RoundToInt(BattleSlider[i].value);
            BattleSliderUpperText[i].text = temp.ToString();
            tempHp += temp * HpPerValue[i];
            Total_Calcaulation_txt.text = tempHp.ToString();
            tempAtk += temp * ATKPerValue[i];
            Total_ATk_Calucation_txt.text = tempAtk.ToString();
            totalHpPlayer = tempHp;
            totalATKPlayer = tempAtk;


        }
    }
    //a

    public void MovetoDistance()
    {

        _buttonDown = true;
        Menupanel.SetActive(false);

        StartCoroutine(moveto(targetpos.transform.position));
    }

    public void CloseMenubt()
    {
        Menupanel.SetActive(false);
        _buttonDown = false;
    }

    public void StartBattle()
    {
        if (totalHpPlayer >= totalHpEnemy)
        {
            StartCoroutine(AddFightingText(totalHpEnemy, "Player Won"));
            targetpos.GetComponent<VillageInfo>().Level_info._isBattleWin = true;
        }
        else
        {
            StartCoroutine(AddFightingText(totalHpPlayer, "Enemy Won"));
        }
        BattlePanel.SetActive(false);
    }

    public IEnumerator AddFightingText(int counter, string Lastwords)
    {

        bool switcher = false;


        while (counter > 60)
        {
            if (!switcher)
            {
                totalHpEnemy -= 60;
                BattleLOGtxt.text += "\nPlayer is Attackting, Enemy Health Minus = " + totalHpEnemy.ToString();
                Total_CalcaulationEnemy_Hp.text = totalHpEnemy.ToString();
                switcher = true;

            }
            else
            {
                totalHpPlayer -= 60;
                BattleLOGtxt.text += "\nEnemy is Attackting, Player Health Minus = " + totalHpPlayer.ToString();
                Total_Calcaulation_txt.text = totalHpPlayer.ToString();
                switcher = false;
            }
            yield return new WaitForSeconds(2);
            counter -= 60;
        }
        OkPanel.SetActive(true);

        BattleLOGtxt.text += "\n" + Lastwords;
    }


    IEnumerator moveto(Vector2 target)
    {
        float Step = speed * Time.deltaTime;

        while (Vector2.Distance(Player.transform.position, target) > 0.2f)
        {
            Player.transform.position = Vector2.MoveTowards(Player.transform.position, target, Step);
            CurrentDay = GetDay.EnterDayCode(Mathf.RoundToInt(Vector2.Distance(Player.transform.position, target)));
            currentTimezone.text = CurrentDay;
            yield return null;
        }

        _buttonDown = false;
        for (int i = 0; i < BattleSlider.Count; i++)
        {
            BattleSlider[i].value = 0;
            BattleSliderUpperText[i].text = "0";
        }
        BattleLOGtxt.text = "";
        Total_Calcaulation_txt.text = "0";
        Total_ATk_Calucation_txt.text = "0";
        Total_CalcaulationEnemy_Hp.text = "200";
        Total_CalcaulationEnemy_ATK.text = "100";
        totalHpEnemy = 200;
        totalATKEnemy = 100;
        totalHpPlayer = 0;
        totalATKPlayer = 0;


        if (targetpos.GetComponent<VillageInfo>().Level_info._isBattleWin)
        {

            OpenCity();
        }
        else
        {
            OkPanel.SetActive(false);
            BattlePanel.SetActive(true);
            MainMenuPanel.SetActive(true);
            BattleMenuPanel.SetActive(true);
            UpgradeMenuPanel.SetActive(false);

        }


        updateDbEnd(-temp_EnduranceRequiredValue);
    }

    public void OpenCity()
    {
        VillagePanel.SetActive(true);
        VillagePanel.GetComponent<CityController>().activeShopFtn(targetpos.GetComponent<VillageInfo>().Level_info.activeShops);
    }
    public void updateDbEnd(int UpdateValueEnd)
    {
        Current_Database.Current_Endurance += UpdateValueEnd;

        LevelText.text = "LVL = " + Current_Database.Current_Level.ToString() + "|| END = " + Current_Database.Current_Endurance.ToString();
      
    }
    public void updateDbLvl(int UpdateValueLvl)
    {
        Current_Database.Current_Level += UpdateValueLvl;

        LevelText.text = "LVL = " + Current_Database.Current_Level.ToString() + "|| END = " + Current_Database.Current_Endurance.ToString();

        
    }


    public void SaveValue_info()
    {
        PlayerPrefs.SetInt("CurrentLevel", Current_Database.Current_Level);
        PlayerPrefs.SetInt("CurrentEndurance", Current_Database.Current_Endurance);
        PlayerPrefs.SetInt("CurrentProgressBar", Current_Database.Current_ProgressBar_Level);
        PlayerPrefs.SetFloat("posx", Current_Database.currentPos.x);
        PlayerPrefs.SetFloat("posy", Current_Database.currentPos.y);

        LoadValue_info();
      
    }

    public void LoadValue_info()
    {
        Current_Database.Current_Level = PlayerPrefs.GetInt("CurrentLevel", 1);
        Current_Database.Current_Endurance = PlayerPrefs.GetInt("CurrentEndurance", 8);
        Current_Database.Current_ProgressBar_Level = PlayerPrefs.GetInt("CurrentProgressBar", 0);
        Current_Database.currentPos= new Vector3(PlayerPrefs.GetFloat("posx", 0), PlayerPrefs.GetFloat("posy", 0),0);
       

    }


    public void updateDbSliderValue(int UpdateSlider)
    {
        Current_Database.Current_ProgressBar_Level +=UpdateSlider;

        if(Current_Database.Current_ProgressBar_Level >= 100) {

            Current_Database.Current_ProgressBar_Level = 0;
            updateDbLvl(1);

        }
        sliderHere.value = Current_Database.Current_ProgressBar_Level;



    }
  
    
    public void CancelBtn()
    {
        Menupanel.SetActive(false);
        _buttonDown = false;

    }

    public void okBt()
    {

       
        if (targetpos.GetComponent<VillageInfo>().Level_info._isBattleWin)
        {
        
            MainMenuPanel.SetActive(false);
            OpenCity();
            updateDbEnd(15);
            updateDbSliderValue(30);
            GetComponent<CityManager>().resoucresCall();

        }
        else
        {
            MainMenuPanel.SetActive(false);
        }
    }

    public void UpdrageMenuBt()
    {
        
       
    //    MainMenuPanel.SetActive(true);
    //    BattleMenuPanel.SetActive(false);
        UpgradeMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
