using BlueRiver.Character;
using BlueRiver.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BlueRiver.Items
{
    public class ItemSelectorCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private GameObject IPointerObj;
        private Button selectButton;
        private StartItemType itemType;
        public event System.Action<StartItemType> OnItemSelected;

        private void Start()
        {
            selectButton = Utils.Utils.FindChild<Button>(gameObject, "Button");

            selectButton.onClick.AddListener(OnClick);
        }

        public void SetItem(StartItemType itemType)
        {
            this.itemType = itemType;
        }

        private void OnClick()
        {
            Debug.Log("ItemSelectorCell OnClick");
            OnItemSelected?.Invoke(itemType);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            IPointerObj.SetActive(true);
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            IPointerObj.SetActive(false);
        }
    }
}