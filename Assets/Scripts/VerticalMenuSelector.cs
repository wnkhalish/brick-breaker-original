using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script used to add vertical selection to a menu selector. It exposes the variable
 * SelectedMenuOptionIndex for subclasses to know the actual menu position.
 */
public class VerticalMenuSelector : MonoBehaviour
{
    // configuration
    [SerializeField] protected GameObject[] verticalMenuOptions;
    [SerializeField] protected SceneLoader sceneLoader;
    

    private int _selectedMenuOptionIndex = 0;  // (up, down) arrows

  
    protected GameObject GetCurrentMenu()
    {
        return this.verticalMenuOptions[this._selectedMenuOptionIndex];
    }
    
    /**
     * Returns a new Vector2 position for the menu selector position. The position is calculated
     * according to the currently selected menu option (private variable: this._selectedMenuOptionIndex).
     */
    protected Vector2 GetMenuSelectorPosition()
    {
        GameObject menuOption = this.verticalMenuOptions[this._selectedMenuOptionIndex];
        
        var selectorY = menuOption.transform.position.y;
        Vector2 selectorPosition = new Vector2(transform.position.x, selectorY);

        return selectorPosition;
    }
    
    /**
     * Handles up and down keyboard arrow presses by moving the menu selector position up and down
     * according to the menu available options (this.verticalMenuOptions).
     */
    protected void HandleUpDownArrowPresses()
    {
        var maxMenuOptionIndex = this.verticalMenuOptions.Length - 1;

       
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this._selectedMenuOptionIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this._selectedMenuOptionIndex--;
        }
        this._selectedMenuOptionIndex = Mathf.Clamp(this._selectedMenuOptionIndex, 0, maxMenuOptionIndex);
        
    
        this.transform.position = GetMenuSelectorPosition();
    }
}
