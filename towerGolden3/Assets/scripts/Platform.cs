using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Platform : MonoBehaviour, IPointerClickHandler
{

    private GameObject prefab1, prefab2, prefab3, prefab4;
    public GameObject shop;
    public GameObject buildingMenu;
    public GameObject pleaseSell;
    public Vector3 positionOffset;
    private GameObject turret;

    public Button turret1, turret2, turret3, turret4,
        exitBuldingMenu, sell, exitPleaseSell;

    void Start()

    {

        prefab1 = shop.gameObject.GetComponent<ShopScript>().TurretType1;
        prefab2 = shop.gameObject.GetComponent<ShopScript>().TurretType2;
        prefab3 = shop.gameObject.GetComponent<ShopScript>().TurretType3;
        prefab4 = shop.gameObject.GetComponent<ShopScript>().TurretType4;

        turret1.GetComponent<Button>().onClick.AddListener(Build);
        turret2.GetComponent<Button>().onClick.AddListener(Build2);
        turret3.GetComponent<Button>().onClick.AddListener(Build3);
        turret4.GetComponent<Button>().onClick.AddListener(Build4);

        sell.GetComponent<Button>().onClick.AddListener(SellTurret);
        exitBuldingMenu.GetComponent<Button>().onClick.AddListener(ExitBuildingMenu);
        exitPleaseSell.GetComponent<Button>().onClick.AddListener(PleaseSellOff);

    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
 
        buildingMenu.SetActive(true);
    }


    public void Build()
    {
        if (transform.childCount == 0)


        {

            shop.gameObject.GetComponent<ShopScript>().BuyTurret1();
            BuildCreate(prefab1);
        }
        else
        {
            PleaseSellOn();

        }


     
    }

   

    public void Build2()
    {
        if (transform.childCount == 0)

        {

            shop.gameObject.GetComponent<ShopScript>().BuyTurret2();

            BuildCreate(prefab2);
        }
        else
        {
            PleaseSellOn();

        }
    }

    public void Build3()
    {
        if (transform.childCount == 0)

        {

            shop.gameObject.GetComponent<ShopScript>().BuyTurret3();

            BuildCreate(prefab3);
        }
        else
        {
            PleaseSellOn();

        }
    }

    public void Build4()
    {
        if (transform.childCount == 0)

        {

            shop.gameObject.GetComponent<ShopScript>().BuyTurret4();

            BuildCreate(prefab4);
        }
        else
        {
            PleaseSellOn();

        }
    }

    public void SellTurret()
    {
        if (transform.childCount > 0)
        {
   
            foreach (Transform child in transform)
            {
                var price = child.gameObject.GetComponent<Turret>().turretprice;
                shop.gameObject.GetComponent<ShopScript>().avaliableAmount += price;
                Destroy(child.gameObject);
            }
        }
    }

    public void ExitBuildingMenu()
    {

        buildingMenu.SetActive(false);
    }

    public void PleaseSellOn()
    {

        pleaseSell.SetActive(true);
    }

    public void PleaseSellOff()
    {

        pleaseSell.SetActive(false);
    }

    public void BuildCreate(GameObject prefab)
    {

        turret = Instantiate(prefab, transform.position + positionOffset, transform.rotation);
        turret.transform.parent = transform;
    }




}
