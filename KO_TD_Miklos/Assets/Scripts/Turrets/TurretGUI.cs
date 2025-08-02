using TMPro;
using UnityEngine;

public class TurretGUI : MonoBehaviour
{
    private TurretBase[] turretBases;

    [SerializeField] private GameObject _sellTurret;
    [SerializeField] private TextMeshProUGUI _sellText;
    [SerializeField] private GameObject _upgradeTuret;
    [SerializeField] private TextMeshProUGUI _upgradeText;
    [SerializeField] private GameObject _carrousel;
    [SerializeField] private GameObject _closeBtn;

    private TurretCarrousel turretCarrousel;
    private TurretBase currentBase;
    private Currency currency;

    //Fill Carrousel data and set listener to every turrent available
    private void Start()
    {
        currency = FindObjectOfType<Currency>();
        turretBases = FindObjectsOfType<TurretBase>();
        foreach (TurretBase turretBase in turretBases)
        {
            turretBase.OnClick.AddListener(OpenGUIData);
        }
    
        turretCarrousel = FindObjectOfType<TurretCarrousel>();
        CloseGui();

    }

    public void CloseGui()
    {
        turretCarrousel.onTurretBuy.RemoveAllListeners();
        _sellTurret.SetActive(false);
        _upgradeTuret.SetActive(false);
        _carrousel.SetActive(false);
        _closeBtn.SetActive(false);
    }
    //when an turretBase or the turret in the turret base is pressed
    private void OpenGUIData(TurretBase turretBase)
    {
        currentBase = turretBase;
        CloseGui();
        //no turret in the base, gui to buy new one
        if (turretBase.GetTurretData() == null)
        {
            _carrousel.SetActive(true);
            turretCarrousel.onTurretBuy.AddListener(TurretBuyed);
            _closeBtn.SetActive(true);
        }
        else
        {
            //ui to update(if available) and sell
            if (turretBase.GetTurretData().turret.canBeUpgraded)
            {
                _upgradeText.text = $"UPGRADE ${turretBase.GetTurretData().turret.cost}";
                _upgradeTuret.SetActive(true);
            }
            _closeBtn.SetActive(true);
            _sellText.text = $"SELL TURRET ${turretBase.GetTurretData().turret.sellReturn}";
            _sellTurret.SetActive(true);
        }
    }

    //on carrousel item pressed, will try to buy
    private void TurretBuyed(TurretDataSO turret)
    {
        if(!currency || !currency.Purchase(turret.turret.cost)){return;}
        currentBase.SetTurret(turret);
        CloseGui();
    }

    public void UpgradeTurret()
    {
        if(!currency || !currency.Purchase(currentBase.GetTurretData().turret.upgradedTurret.turret.cost)){return;}
        if (!currentBase.GetTurretData().turret.upgradedTurret) { return;}
        currentBase.SetTurret(currentBase.GetTurretData().turret.upgradedTurret);
        CloseGui();
    }

    public void SellTurret()
    {
        if(currency && currentBase.GetTurretData()){currency.AddCurrency(currentBase.GetTurretData().turret.sellReturn);}
        currentBase.SetTurret(null);
        CloseGui();
    }

}
