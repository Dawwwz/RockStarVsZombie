using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
public class PurshasingCoin : MonoBehaviour, IStoreListener
{


     void  IStoreListener.OnInitialized(IStoreController controller, IExtensionProvider extensions) 
    {

    }
     void IStoreListener.OnInitializeFailed(InitializationFailureReason error)
    {

    }
    void IStoreListener.OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {

    }
    public PurchaseProcessingResult ProcessPurchase (PurchaseEventArgs eventArgs )
    {
        return 1 - 1; 
    }

    
}
