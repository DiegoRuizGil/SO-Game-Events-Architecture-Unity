# SO Game Events Architecture

Event system for communication between objects in a Unity scene, based on the use of Scriptable Objects, avoiding classes dependencies. Inspired by Ryan Hipple's talk [Unite Austin 2017 - Game Architecture with Scriptable Objects](https://www.youtube.com/watch?v=raQ3iHhE_Kk)

You can try a demo from this [`itch.io`](https://diegorg64.itch.io/so-game-events-architecture) page, where all the objects from the scene interact with each other without referring to other scripts.

## Table of contents
- [How to install](#how-to-install)
- [How to use](#how-to-use)
    - [Events creation](#events-creation)
    - [Adding listeners](#adding-listeners)
    - [Listener response from code](#listener-response-from-code)
    - [Create new events types](#create-new-events-types)
- [License](#license)


## How to install
- Download the `Unity Package` from the `Releases` section or from the [`itch.io`](https://diegorg64.itch.io/so-game-events-architecture) page
- From the Unity project editor, drag and drop the Unity Package into the `Assets` folder
- Click on `Import` in the displayed window

## How to use

### Events creation
In the `Project` window, right click and nagivate to `Create` -> `Game Events`, and select the event type you want.

`AÑADIR AQUI LA IMAGEN`

The event type indicates the type of data you will send to the listeners subscirbed to it.

### Adding listeners
With a GameObject selected, click on `Add Component` and search for a listener of the same type of the event you want to be suscribed.

In the component, we have the `Game Event` attribute, where we must assing the scriptable object of the event, and a UnityEvent for the `Response`.

### Listener response from code
You can add a response to an event from code. Just take a reference to the listener and use the `AddAction` function to add a new response, or the `RemoveAction` and `RemoveAllActions` functions to remove responses.

```CSharp
using GameEvents;
using UnityEngine;

public class TestClass : MonoBehaviour
{
    private IntListener _listener;

    private void Awake()
    {
        _listener = GetComponent<IntListener>();
    }

    private void OnEnable() => _listener.AddAction(DoSomething);

    private void OnDisable() => _listener.RemoveAction(DoSomething);

    private void DoSomething(int value)
    {
        ...
    }
}
```

### Create new events types
Navigate to `Game Events` -> `Create New Type Event`, from the top bar. In the new menu displayed, you will have to indicate the namespace of the class (if it has one), and the class name.

All the code genereted from this menu will be located in the `CODE_GENERATION` folder.
 
## License
This project is released under the MIT License by Diego Ruiz Gil (2024)