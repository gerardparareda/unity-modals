# Modals test for Petoons 

## Controls
WASD/Arrows/Joystick (Gamepad) -> Move player
ESC/P/Start or Select (Gamepad) -> Open pause/options menu
Enter/South button (Gamepad) -> Select answer from modal

Gamepad tested with Nintendo Joycons.

## Possible improvements
- Better resizability across different screen sizes
- Use new UI Toolkit system
- Make GameManager a singleton
- Keep selected button on new modal open and close
- Make more modals like a controls one or a question to validate game close
- Customize UI
- Clean up some code
- Document all the code

## Resources
Some of the things I had to look up.

### Blur shader
https://lexdev.net/tutorials/ui/blur.html

https://github.com/LexdevTutorials/UIBlur/blob/master/UIBlurUnityProject/Assets/Shaders/Blur.shader

### New Input System
I decided on using the DefaultInputActions for they were good enough for me to use. I only added the Settings action, mapped to 'P' on Keyboard and 'Start' on Gamepads.

https://www.youtube.com/watch?v=Pzd8NhcRzVo

https://www.youtube.com/watch?v=Yjee_e4fICc

#### Find if any key was pressed on keyboard or gamepad
https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html

https://forum.unity.com/threads/input-system-1-3-0-released-more-fixes.1222632/

https://answers.unity.com/questions/1629490/checking-if-button-is-highlighted-with-a-controlle.html

### Addressable Assets
https://www.youtube.com/watch?v=C6i_JiRoIfk

https://docs.unity3d.com/Packages/com.unity.addressables@1.20/manual/AssetReferences.html

https://gamedev-resources.com/load-unload-and-change-assets-at-runtime-with-addressables/

### Coroutines
https://answers.unity.com/questions/300864/how-to-stop-a-co-routine-in-c-instantly.html

https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/

### Basic old UI System
https://www.youtube.com/watch?v=zc8ac_qUXQY

### Others
Disable back panel buttons: https://forum.unity.com/threads/exclude-buttons-from-navigation-in-menu.751247/#post-5012486

List of custom serializable class: https://forum.unity.com/threads/public-list-not-appearing-in-inspector.520160/

Find in List: https://stackoverflow.com/questions/38197707/how-to-find-list-element-with-class-without-looping-unity-c-sharp

Unity Code Guideline: https://myunity.dev/coding-guideline-for-unity-c/

Drivers to use Joy-Cons as XINPUT in Windows: https://github.com/Davidobot/BetterJoy


## Credits
Made by Gerard Parareda Gallifa
(27 December 2022 - 1 January 2023, During my vacations in Istanbul)
