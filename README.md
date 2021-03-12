# SelectionBox_2D_2D
Manages A SelectionBox UI To Select Objects Using their Position(2D) On Screen
- Controls a SelectionBox UI size and position
- Restricts SelectionBox UI within bounds of another UI

## Features
- Works in any Screen Resoulution
- Works in any Canvas Rendering Mode - Overlay,Camera or WorldSpace
- Able to select single objects on cursor position

## Additional-Features
- 3 Event Callback - OnSelectionBoxSelect, OnSelectionBoxRelease, OnSelectionPointSelect

## Usage
1. Click and Drag over the screen to create an area to select all objects within the area
2. Click to select single objects

## Implementation
1. Set a list of selectable objects using SetSelectableObjects(list)
2. Assign SelectionBoxUI and SelectionBoxArea
3. Use StartSelectionBox(),UpdateSelectionBox() and ReleaseSelectionBox()
 
## License
[MIT][L]

[L]: https://github.com/frozonnorth/SelectionBox_2D_2D/blob/main/LICENSE
