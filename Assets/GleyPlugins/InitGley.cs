using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGley : MonoBehaviour
{
   void Awake()
    {
        IAPManager.Instance.InitializeIAPManager(InitializeResultCallback);
    }
    private void InitializeResultCallback(IAPOperationStatus status, string message, List<StoreProduct>
shopProducts)
    {
        if (status == IAPOperationStatus.Success)
        {
            //IAP was successfully initialized
            //loop through all products
            for (int i = 0; i < shopProducts.Count; i++)
            {
                if (shopProducts[i].productName == "YourProductName")
                {
                    //if active variable is true, means that user had bought that product
                    //so enable access
                    if (shopProducts[i].active)
                    {
                        //yourBoolVariable = true;
                    }
                }
            }
        }
        else
        {
            //Debug.Log(“Error occurred ”+message);
        }
    }
}
