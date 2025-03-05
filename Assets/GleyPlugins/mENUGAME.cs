using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mENUGAME : MonoBehaviour
{
    //public Button btnShop;

    public void BuyP1()
    {
        IAPManager.Instance.BuyProduct(ShopProductNames.buyremoveads, ProductBoughtCallback);
    }
   
    private void ProductBoughtCallback(IAPOperationStatus status, string message, StoreProduct
product)
    {
        if (status == IAPOperationStatus.Success)
        {
            //each consumable gives coins in this example
            {

            }
        }
        else
        {
            //an error occurred in the buy process, log the message for more details
            Debug.Log("Buy product failed: " + message);
        }
    }
}
