using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var potionInstance = other.GetComponent<PotionInstance>();
        if (potionInstance)
        {
            EventRelay.Instance.RaiseSellPotion(potionInstance.GetPotionData().Guid, true);
            Destroy(other.gameObject);
        }
    }
}
