# Upgrade System

This code comes with the bare minimum required for you to give a fully functional **SETUP** for the upgrades system that might be useful in your game.

This system uses two classes one is _UpgradeItem_ and the other one is _UpgradeDatabase_. A databse will contain all the upgrades in your game.

**NOTE:** _Saving and Loading the data is not the responsibility of the Upgrade System hence that code needs to be written by you._

This project also comes with a little helper template for making generation of the upgrade item scripts easier.

## Steps to create a new upgrade item

---

-   Move the folder named **"ScriptTemplates"** to the **"{Your Unity Project}/Assets/ScriptTemplates"**.

-   Restart the Unity Editor.

-   Now create a new folder with a suitable name for the new Upgrade Item.

-   The Directory structure should be as follows:

    -   New Upgrade Item

        -   Editor

            -   NewUpgradeItemEditor.cs

        -   NewUpgradeItem.cs
        -   NewUpgradeItem.asset (<- This is a scriptable object)

-   Now go into this newly created Directory and right click to open the create asset menu.

-   You will be able to see 2 templates under the option _"Upgrade Item"_

-   Click on the _"Upgrade Item"_ template to create a new script.

-   Now Create the Editor script same way in the _"Editor'_ Folder.

-   Inside the Upgrade Item script you will be required to create a Data Structure to hold data for your upgrade. Example a boost upgrade data will contain the fields:

    ```c#
    public struct BoostUpgradeData
    {
        public int unlockMoney;
        public float boostLevel;
    }
    ```

-   Now replace the type of the list with this newly created data structure.

### We are almost there! Let's look at the editor side code to make this fully functional.

-   Open the script created in the Editor folder.

-   First put the type of the new UpgradeItem in the line

    ```c#
    [CustomEditor(typeof(BoostUpgradeItem))]
    public class YourScriptNameEditor : UpgradeItemEditor
    ```

-   Then in the function `OnEnable()` Change the `list.elementHeight` property to make the list contain all your fields in the data:

    ```c#
    protected override void OnEnable()
    {
        base.OnEnable();
        list.elementHeight = /*multiply by your desired height*/ EditorGUIUtility.singleLineHeight;
    }
    ```

-   Now comes the part where you have to decide how you want to draw your upgrade data in the inspector:
    ```c#
    protected override void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
    {
        // Your Element in a reorderable list drawing code here ...
    }
    ```

## We now have an upgrade system. Create the relevant Scriptable Objects and configure them however you like!
