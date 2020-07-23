using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

	public GameObject TurretType1;
	public GameObject TurretType2;
    public GameObject TurretType3;
    public GameObject TurretType4;
  
    public int avaliableAmount;
	private int Turret1Price, Turret2Price, Turret3Price, Turret4Price, turretprice;

    public GameObject availableAmountText;
    private TextMeshProUGUI availableAmounttextmeshPro;
 

    private void Start()
    {
        availableAmounttextmeshPro = availableAmountText.GetComponent<TextMeshProUGUI>();
    
        Turret1Price = TurretType1.gameObject.GetComponent<Turret>().turretprice;
        Turret2Price = TurretType2.gameObject.GetComponent<Turret>().turretprice;
        Turret3Price = TurretType3.gameObject.GetComponent<Turret>().turretprice;
        Turret4Price = TurretType4.gameObject.GetComponent<Turret>().turretprice;
        
    }

    
    public void BuyTurret1()
    {
        avaliableAmount -= Turret1Price;
    }
    

    public void BuyTurret2()
    {

        avaliableAmount -= Turret2Price;

    }


    public void BuyTurret3()
    {

        avaliableAmount -= Turret3Price;

    }

    public void BuyTurret4()
    {

        avaliableAmount -= Turret4Price;

    }
    public void SellShop()
    {
        avaliableAmount += Turret1Price;
    }
    public void Update()
    { 
        availableAmounttextmeshPro.SetText("Money " + avaliableAmount + "$");
      
    }

  
}
