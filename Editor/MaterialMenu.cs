using UnityEditor;

public class MaterialMenu 
{
    [MenuItem("Material/MaterialChanger")]
    private static void MenuOption()
    {
        EditorWindow.GetWindow(typeof(ColorChanger), false, "MaterialChanger");
    }
}
