using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logica
{
    public class HotKey
    {
        Datos.HotKey datosHotKey = new Datos.HotKey();

        public void CreateDb()
        {
            datosHotKey.CreateDb();
        }

        public List<Modelo.HotKey> Read()
        {
            return datosHotKey.Read();
        }

        public Modelo.HotKey ReadByName(string hkName)
        {
            return datosHotKey.ReadByName(hkName);
        }

        public Modelo.HotKey ReadByKeysPressed(string modifierPressed, string keyPressed)
        {
            return datosHotKey.ReadByKeysPressed(modifierPressed, keyPressed);
        }

        public void Update(Modelo.HotKey hkToUpdate)
        {
            if (int.TryParse(hkToUpdate.Key, out var value))// If hkToUpdate.Key is between 0..9 
                hkToUpdate.Key = "D" + hkToUpdate.Key;      // We need to add D before the text
            if (hkToUpdate.Key == "-")
                hkToUpdate.Key = "Subtract";
            if (hkToUpdate.Key == "+")
                hkToUpdate.Key = "Add";
            datosHotKey.Update(hkToUpdate);
        }

        public string FoundDuplicatedValues(List<Modelo.HotKey> hotKeysList)
        {
            //We create a list for add hk duplicated and two string to compare
            List<Modelo.HotKey> hkDuplicatedList = new List<Modelo.HotKey>();
            string hkCompared, hkCurrent;

            foreach (var hk in hotKeysList)
            {
                // The first time we save the current hk to compare it with the others
                hkCompared = hk.Modifier + " + " + hk.Key;
                foreach (var hkItem in hotKeysList)
                {
                    hkCurrent = hkItem.Modifier + " + " + hkItem.Key;
                    // If the current hk is the same as the saved hk and their names are different
                    if ((hkCurrent == hkCompared) && (hk.Name != hkItem.Name))
                    {
                        // We add it to hkDuplicatedList
                        Modelo.HotKey hkNew = new Modelo.HotKey(hkItem.Name, hkItem.Modifier, hkItem.Key);
                        hkDuplicatedList.Add(hkNew);
                    }
                }
            }

            // We create a list to add the names of the duplicate values
            string hkDuplicatedNames = "";

            if (hkDuplicatedList.Count > 0)
            {
                foreach (var hkDuplicated in hkDuplicatedList)
                {
                    if (hkDuplicatedNames == "")
                        hkDuplicatedNames = hkDuplicated.Name;
                    else
                        hkDuplicatedNames = hkDuplicatedNames + ", " + hkDuplicated.Name;
                }
            }

            return hkDuplicatedNames;
        }

        public string ReplacehkPressedText(Modelo.HotKey hkSelected)
        {
            string hotKeyPressedText = "";
            // If the keyPressed start with D and Length > 1 is a number (D0..D9)
            if ((hkSelected.Key.StartsWith("D")) && (hkSelected.Key.Length > 1))
                hkSelected.Key = hkSelected.Key.Replace("D", "");
            // If the keyPressed = "-"
            if (hkSelected.Key == "Subtract")
                hkSelected.Key = "-";
            // If the keyPressed = "+"
            if (hkSelected.Key == "Add")
                hkSelected.Key = "+";
            hotKeyPressedText = hkSelected.Modifier + " + " + hkSelected.Key;
            return hotKeyPressedText;
        }

        public int VerifyDb(List<Modelo.HotKey> hotKeysList)
        {
            return datosHotKey.VerifyDb(hotKeysList);
        }

        public bool VerifyKeyPressed(string keyPressed)
        {
            // We use verifyKeyPressed to verify if the key is equivalent to [A..Z] || [1..9] [-+]
            string stringKey = "";

            if (keyPressed.StartsWith("D") && keyPressed.Count() == 2)
                stringKey = keyPressed.ToString().Replace("D", "");// [1..9]
            if (keyPressed.StartsWith("NumPad") && keyPressed.Count() == 7)
                stringKey = keyPressed.ToString().Replace("NumPad", "");// [NumPad0..NumPad9]
            if (keyPressed.Count() == 1)
                stringKey = keyPressed;// Letters or Subtract(-) or Add(+)

            // Verify if keyPressed = [1..9] or [A..Z] or [+-]
            if (Regex.IsMatch(stringKey, @"^[A-Z0-9]+$") || (keyPressed == "Add") || (keyPressed == "Subtract"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}