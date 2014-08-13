using System;

[Serializable]
public class InventoryItemDictionary : SerializableDictionary<string, InventoryItem, InventoryItemDictionaryEntry> {}
