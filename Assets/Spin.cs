    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Spin : MonoBehaviour
{
    //objects and sprites
    public GameObject wheel;
    public GameObject indicator;
    public GameObject deathBox;
    public GameObject prevRewardsBox;
    public GameObject menuBox;
    public GameObject spinBox;

    public Sprite bronzeWheel;
    public Sprite silverWheel;
    public Sprite goldWheel;
    public Sprite bronzeIndicator;
    public Sprite silverIndicator;
    public Sprite goldIndicator;

    public Sprite prevRewardEmpty;

    //reward lists
    public Sprite[] bronzeRewards;
    public Sprite[] silverRewards;
    public Sprite[] goldRewards;

    //reward counters
    //bronze
    private int rewardCash;
    private int rewardGlasses;
    private int rewardCap;
    private int rewardBronzeChest;
    private int rewardNeurostim;
    private int rewardRegenerator;
    private int rewardFrag;
    //silver
    private int rewardGold;
    private int rewardSiverChest;
    private int rewardBayonet;
    private int rewardMeleeT2;
    private int rewardRifleT2;
    private int rewardShotgunT3;
    private int rewardSMGT3;
    private int rewardSniperT3;
    //gold
    private int rewardGoldChest;
    private int rewardPointsArmor;
    private int rewardPointsKnife;
    private int rewardPointsPistol;
    private int rewardPointsRifle;
    private int rewardPointsShotgun;
    private int rewardPointsSMG;
    private int rewardPointsSniper;

    private int rewardAmount;
    
    //reward amount texts
    public GameObject amount1;
    public GameObject amount2;
    public GameObject amount3;
    public GameObject amount4;
    public GameObject amount5;
    public GameObject amount6;
    public GameObject amount7;
    public GameObject amount8;
    public GameObject amount9;
    public GameObject amount10;
    public GameObject amount11;
    public GameObject amount12;
    public GameObject amount13;
    public GameObject amount14;
    public GameObject amount15;
    public GameObject amount16;
    public GameObject amount17;
    public GameObject amount18;
    public GameObject amount19;
    public GameObject amount20;
    public GameObject amount21;
    public GameObject amount22;
    public GameObject amount23;
    public GameObject amountprev;

    //reward objects
    public GameObject reward1;
    public GameObject reward2;
    public GameObject reward3;
    public GameObject reward4;
    public GameObject reward5;
    public GameObject reward6;
    public GameObject reward7;
    public GameObject reward8;
    public GameObject rewardprev;

    //next amount objects
    public GameObject rewardamount1;
    public GameObject rewardamount2;
    public GameObject rewardamount3;
    public GameObject rewardamount4;
    public GameObject rewardamount5;
    public GameObject rewardamount6;
    public GameObject rewardamount7;
    public GameObject rewardamount8;



    public float spinPower;
    public float stopPower;

    private Rigidbody2D rb;
    bool spinning;
    float t;
    public int spinCount;
    public bool nextSpinGold = false;
    public bool nextSpinSilver = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spinCount = 1;
        setBronzeRewards();
        ResetRewards();
        UpdateRewards();
        rewardAmount = 1;
        UpdateNextAmounts();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.angularVelocity > 0)
        {
            rb.angularVelocity += stopPower * Time.deltaTime;
        }

        if (rb.angularVelocity <= 0 && spinning)
        {
            t += 1 * Time.deltaTime;
            if (t >= 0.5f)
            {
                rb.angularVelocity = 0;
                spinning = false;
                if (spinCount > 1)
                {
                    getReward();
                }  
                t = 0;
            }
        }
    }

    public void spinWheel()
    {
        if (!spinning)
        {
            spinPower = Random.Range(700f,1200f);
            stopPower = Random.Range(200f,300f);
            rb.AddTorque(-spinPower);
            spinning = true;
            spinCount++;    
        }
    }

    public void setBronzeRewards()
    {
        reward1.GetComponent<Image>().sprite = bronzeRewards[0];
        reward2.GetComponent<Image>().sprite = bronzeRewards[1];
        reward3.GetComponent<Image>().sprite = bronzeRewards[2];
        reward4.GetComponent<Image>().sprite = bronzeRewards[3];
        reward5.GetComponent<Image>().sprite = bronzeRewards[4];
        reward6.GetComponent<Image>().sprite = bronzeRewards[5];
        reward7.GetComponent<Image>().sprite = bronzeRewards[6];
        reward8.GetComponent<Image>().sprite = bronzeRewards[7];
    }
    public void setSilverRewards()
    {
        reward1.GetComponent<Image>().sprite = silverRewards[0];
        reward2.GetComponent<Image>().sprite = silverRewards[1];
        reward3.GetComponent<Image>().sprite = silverRewards[2];
        reward4.GetComponent<Image>().sprite = silverRewards[3];
        reward5.GetComponent<Image>().sprite = silverRewards[4];
        reward6.GetComponent<Image>().sprite = silverRewards[5];
        reward7.GetComponent<Image>().sprite = silverRewards[6];
        reward8.GetComponent<Image>().sprite = silverRewards[7];
    }
    public void setGoldRewards()
    {
        reward1.GetComponent<Image>().sprite = goldRewards[0];
        reward2.GetComponent<Image>().sprite = goldRewards[1];
        reward3.GetComponent<Image>().sprite = goldRewards[2];
        reward4.GetComponent<Image>().sprite = goldRewards[3];
        reward5.GetComponent<Image>().sprite = goldRewards[4];
        reward6.GetComponent<Image>().sprite = goldRewards[5];
        reward7.GetComponent<Image>().sprite = goldRewards[6];
        reward8.GetComponent<Image>().sprite = goldRewards[7];
    }

    public void getReward()
    {
        
        float r = transform.eulerAngles.z;

        if (r > 0 && r <= 45)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 45);
            Reward(2);
        }
        else if (r > 45 && r <= 90)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 90);
            Reward(3);
        }
        else if (r > 90 && r <= 135 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 135);
            Reward(4);
        }
        else if (r > 135 && r <= 180)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 180);
            Reward(5);
        }
        else if (r > 180 && r <= 225)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 225);
            Reward(6);
        }
        else if (r > 225 && r <= 270)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 270);
            Reward(7);
        }
        else if (r > 270 && r <= 315)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 315);
            Reward(8);
        }
        else if (r > 315 && r <= 360)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
            Reward(1);
        }

        if (spinCount%30 == 0)
        {
            wheel.GetComponent<Image>().sprite = goldWheel;
            indicator.GetComponent<Image>().sprite = goldIndicator;
            setGoldRewards();
            nextSpinGold = true;
        }
        else if (spinCount%5 == 0)
        {
            wheel.GetComponent<Image>().sprite = silverWheel;
            indicator.GetComponent<Image>().sprite = silverIndicator;
            setSilverRewards();
            nextSpinSilver = true;
        }
        else
        {
            wheel.GetComponent<Image>().sprite = bronzeWheel;
            indicator.GetComponent<Image>().sprite = bronzeIndicator;
            setBronzeRewards();
        }
    }


    public void Reward(int Slot)
    {
        //Debug.Log("SLOT " + Slot);

        if (nextSpinGold)
        {
            switch (Slot)
            {
                case 1:
                    rewardprev.GetComponent<Image>().sprite = goldRewards[0];
                    rewardGoldChest += rewardAmount;
                    nextSpinGold = false;
                    break;
                case 2:
                    rewardprev.GetComponent<Image>().sprite = goldRewards[1];
                    rewardPointsArmor += rewardAmount;
                    nextSpinGold = false;
                    break;
                case 3:
                    rewardprev.GetComponent<Image>().sprite = goldRewards[2];
                    rewardPointsKnife += rewardAmount;
                    nextSpinGold = false;
                    break;
                case 4:
                    rewardprev.GetComponent<Image>().sprite = goldRewards[3];
                    rewardPointsPistol += rewardAmount;
                    nextSpinGold = false;
                    break;
                case 5:
                    rewardprev.GetComponent<Image>().sprite = goldRewards[4];
                    rewardPointsRifle += rewardAmount;
                    nextSpinGold = false;
                    break;
                case 6:
                    rewardprev.GetComponent<Image>().sprite = goldRewards[5];
                    rewardPointsShotgun += rewardAmount;
                    nextSpinGold = false;
                    break;
                case 7:
                    rewardprev.GetComponent<Image>().sprite = goldRewards[6];
                    rewardPointsSMG += rewardAmount;
                    nextSpinGold = false;
                    break;
                case 8:
                    rewardprev.GetComponent<Image>().sprite = goldRewards[7];
                    rewardPointsSniper += rewardAmount;
                    nextSpinGold = false;
                    break;
            }
        }
        else if (nextSpinSilver)
        {
            switch (Slot)
            {
                case 1:
                    rewardprev.GetComponent<Image>().sprite = silverRewards[0];
                    rewardGold += rewardAmount;
                    nextSpinSilver = false;
                    break;
                case 2:
                    rewardprev.GetComponent<Image>().sprite = silverRewards[1];
                    rewardSiverChest += rewardAmount;
                    nextSpinSilver = false;
                    break;
                case 3:
                    rewardprev.GetComponent<Image>().sprite = silverRewards[2];
                    rewardBayonet += rewardAmount;
                    nextSpinSilver = false;
                    break;
                case 4:
                    rewardprev.GetComponent<Image>().sprite = silverRewards[3];
                    rewardMeleeT2 += rewardAmount;
                    nextSpinSilver = false;
                    break;
                case 5:
                    rewardprev.GetComponent<Image>().sprite = silverRewards[4];
                    rewardRifleT2 += rewardAmount;
                    nextSpinSilver = false;
                    break;
                case 6:
                    rewardprev.GetComponent<Image>().sprite = silverRewards[5];
                    rewardShotgunT3 += rewardAmount;
                    nextSpinSilver = false;
                    break;
                case 7:
                    rewardprev.GetComponent<Image>().sprite = silverRewards[6];
                    rewardSMGT3 += rewardAmount;
                    nextSpinSilver = false;
                    break;
                case 8:
                    rewardprev.GetComponent<Image>().sprite = silverRewards[7];
                    rewardSniperT3 += rewardAmount;
                    nextSpinSilver = false;
                    break;
            }
        }
        else
        {
            switch (Slot)
            {
                case 1:
                    Death();
                    break;
                case 2:
                    rewardprev.GetComponent<Image>().sprite = bronzeRewards[1];
                    rewardCash += rewardAmount;
                    break;
                case 3:
                    rewardprev.GetComponent<Image>().sprite = bronzeRewards[2];
                    rewardGlasses += rewardAmount; 
                    break;
                case 4:
                    rewardprev.GetComponent<Image>().sprite = bronzeRewards[3];
                    rewardCap += rewardAmount;
                    break;
                case 5:
                    rewardprev.GetComponent<Image>().sprite = bronzeRewards[4];
                    rewardBronzeChest += rewardAmount;
                    break;
                case 6:
                    rewardprev.GetComponent<Image>().sprite = bronzeRewards[5];
                    rewardNeurostim += rewardAmount;
                    break;
                case 7:
                    rewardprev.GetComponent<Image>().sprite = bronzeRewards[6];
                    rewardRegenerator += rewardAmount;
                    break;
                case 8:
                    rewardprev.GetComponent<Image>().sprite = bronzeRewards[7];
                    rewardFrag += rewardAmount;
                    break;
            }
        }
        amountprev.GetComponent<TMPro.TextMeshProUGUI>().text = rewardAmount.ToString();
        rewardAmount++;
        UpdateRewards();
        UpdateNextAmounts();
    }

    public void ResetRewards()
    {
        rewardCash = 0;
        rewardGlasses = 0;
        rewardCap = 0;
        rewardBronzeChest = 0;
        rewardNeurostim = 0;
        rewardRegenerator = 0;
        rewardFrag = 0;
        rewardGold = 0;
        rewardSiverChest = 0;
        rewardBayonet = 0;
        rewardMeleeT2 = 0;
        rewardRifleT2 = 0;
        rewardShotgunT3 = 0;
        rewardSMGT3 = 0;
        rewardSniperT3 = 0;
        rewardGoldChest = 0;
        rewardPointsArmor = 0;
        rewardPointsKnife = 0;
        rewardPointsPistol = 0;
        rewardPointsRifle = 0;
        rewardPointsShotgun = 0;
        rewardPointsSMG = 0;
        rewardPointsSniper = 0;
    }

    public void UpdateRewards()
    {
        amount1.GetComponent<TMPro.TextMeshProUGUI>().text = rewardCash.ToString();
        amount2.GetComponent<TMPro.TextMeshProUGUI>().text = rewardGlasses.ToString();
        amount3.GetComponent<TMPro.TextMeshProUGUI>().text = rewardCap.ToString();
        amount4.GetComponent<TMPro.TextMeshProUGUI>().text = rewardBronzeChest.ToString();
        amount5.GetComponent<TMPro.TextMeshProUGUI>().text = rewardNeurostim.ToString();
        amount6.GetComponent<TMPro.TextMeshProUGUI>().text = rewardRegenerator.ToString();
        amount7.GetComponent<TMPro.TextMeshProUGUI>().text = rewardFrag.ToString();
        amount8.GetComponent<TMPro.TextMeshProUGUI>().text = rewardGold.ToString();
        amount9.GetComponent<TMPro.TextMeshProUGUI>().text = rewardSiverChest.ToString();
        amount10.GetComponent<TMPro.TextMeshProUGUI>().text = rewardBayonet.ToString();
        amount11.GetComponent<TMPro.TextMeshProUGUI>().text = rewardMeleeT2.ToString();
        amount12.GetComponent<TMPro.TextMeshProUGUI>().text = rewardRifleT2.ToString();
        amount13.GetComponent<TMPro.TextMeshProUGUI>().text = rewardShotgunT3.ToString();
        amount14.GetComponent<TMPro.TextMeshProUGUI>().text = rewardSMGT3.ToString();
        amount15.GetComponent<TMPro.TextMeshProUGUI>().text = rewardSniperT3.ToString();
        amount16.GetComponent<TMPro.TextMeshProUGUI>().text = rewardGoldChest.ToString();
        amount17.GetComponent<TMPro.TextMeshProUGUI>().text = rewardPointsArmor.ToString();
        amount18.GetComponent<TMPro.TextMeshProUGUI>().text = rewardPointsKnife.ToString();
        amount19.GetComponent<TMPro.TextMeshProUGUI>().text = rewardPointsPistol.ToString();
        amount20.GetComponent<TMPro.TextMeshProUGUI>().text = rewardPointsRifle.ToString();
        amount21.GetComponent<TMPro.TextMeshProUGUI>().text = rewardPointsShotgun.ToString();
        amount22.GetComponent<TMPro.TextMeshProUGUI>().text = rewardPointsSMG.ToString();
        amount23.GetComponent<TMPro.TextMeshProUGUI>().text = rewardPointsSniper.ToString();
        
    }

    public void UpdateNextAmounts()
    {
        if (spinCount % 5 == 0)
        {
            rewardamount1.GetComponent<TMPro.TextMeshProUGUI>().text = rewardAmount.ToString();
        }
        else
        { 
            rewardamount1.GetComponent<TMPro.TextMeshProUGUI>().text = ("");
        }
        rewardamount2.GetComponent<TMPro.TextMeshProUGUI>().text = rewardAmount.ToString();
        rewardamount3.GetComponent<TMPro.TextMeshProUGUI>().text = rewardAmount.ToString();
        rewardamount4.GetComponent<TMPro.TextMeshProUGUI>().text = rewardAmount.ToString();
        rewardamount5.GetComponent<TMPro.TextMeshProUGUI>().text = rewardAmount.ToString();
        rewardamount6.GetComponent<TMPro.TextMeshProUGUI>().text = rewardAmount.ToString();
        rewardamount7.GetComponent<TMPro.TextMeshProUGUI>().text = rewardAmount.ToString();
        rewardamount8.GetComponent<TMPro.TextMeshProUGUI>().text = rewardAmount.ToString();
    }
    public void Death()
    {
        ResetRewards();
        UpdateRewards();
        UpdateNextAmounts();
        deathBox.SetActive(true);
    }

    public void GoToMenu()
    {
        rewardAmount = 1;
        UpdateNextAmounts();
        spinCount = 1;
        wheel.GetComponent<Image>().sprite = bronzeWheel;
        indicator.GetComponent<Image>().sprite = bronzeIndicator;
        setBronzeRewards();
        menuBox.SetActive(true);
        spinBox.SetActive(false);
        deathBox.SetActive(false);
    }

    public void Play()
    {
        amountprev.GetComponent<TMPro.TextMeshProUGUI>().text = ("");
        rewardprev.GetComponent<Image>().sprite = prevRewardEmpty;
        menuBox.SetActive(false);
        spinBox.SetActive(true);
        deathBox.SetActive(false);
    }

}
