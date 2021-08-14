## DEV-13, Make a Second Level

We created a prefab for the following items:
Paddle
Ball
Play Space
Game Camera
Scene Loader
Game Canvas


Made sure that the buttons still worked by adding the prefabbed Scene Loader and attaching the correct functions to the canvas buttons

Create a new scene by File > new Scene

Honestly hook everything back together in this new scene and you basically have a level 2


this was my old way to get colors

    Dictionary<string, Color> createColorDictionary(){
        List<string, Color> list;
        Dictionary<string, Color> d = new Dictionary<string, Color>();
        foreach (string color in list) {
            switch(color){
                case black:
                    d.Add(color, Color.black);
                    break;
                case blue:
                    d.Add(color, Color.blue);
                    break;
                case clear:
                    d.Add(color, Color.clear);
                    break;
                case cyan:
                    d.Add(color, Color.cyan);
                    break;
                case gray:
                    d.Add(color, Color.gray);
                    break;
                case green:
                    d.Add(color, Color.green);
                    break;
                case magenta:
                    d.Add(color, Color.magenta);
                    break;
                case red:
                    d.Add(color, Color.red);
                    break;
                case white:
                    d.Add(color, Color.white);
                    break;
                case yellow:
                    d.Add(color, Color.yellow);
                    break;
                default:
                    break;
            }
        }

this is my new way

        Dictionary<string, Color> createColorDictionary(){
        List<string, Color> list;
        Dictionary<string, Color> d = new Dictionary<string, Color>(){
            {"black", Color.black},
            {"blue", Color.blue},
            {"clear", Color.clear},
            {"cyan", Color.cyan},
            {"gray", Color.gray},
            {"green", Color.green},
            {"magenta", Color.magenta},
            {"red", Color.red},
            {"white", Color.white},
            {"yellow", Color.yellow},
            {"orange", Color.orange}.
            {"lime", Color.lime}
        }