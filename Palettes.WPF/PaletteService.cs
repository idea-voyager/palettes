namespace PatioCode.Palettes.WPF;

public static class PaletteService
{
    private const string Brush = nameof(Brush);
    private const string Color = nameof(Color);
    
    public static void FreezeBrushes(Application application) => FreezeBrushes(application.Resources);
    public static void FreezeBrushes(ResourceDictionary resources)
    {
        foreach (var resourceKey in resources.Keys.OfType<string>().Where(x => x.StartsWith(Brush)).ToArray())
        {
            var key = resourceKey.Replace($"{Brush}-", "");
            
            if (Colors.MaterialDesign.AllColors.ContainsKey(key) &&
                Colors.Tailwind.AllColors.ContainsKey(key) &&
                resources[resourceKey] is Freezable { CanFreeze: true, IsFrozen: false } freezable)
                freezable.Freeze();
        }
        
        foreach (var merged in resources.MergedDictionaries)
            FreezeBrushes(merged);
    }
    
    private static void AddBrushes(ResourceDictionary resources, Dictionary<string, string> colors)
    {
        foreach (var colorPair in colors)
        {
            var color = CreateColor(colorPair.Value);
            resources[BrushKey(colorPair.Key)] = CreateBrush(color);
        }
    }
    
    private static void AddColors(ResourceDictionary resources, Dictionary<string, string> colors)
    {
        foreach (var colorPair in colors)
        {
            resources[ColorKey(colorPair.Key)] = CreateColor(colorPair.Value);
        }
    }
    
    private static Color CreateColor(string colorHex) =>
        (Color)ColorConverter.ConvertFromString(colorHex);
    
    private static SolidColorBrush CreateBrush(Color color)
    {
        var brush = new SolidColorBrush(color);
        
        if (brush is { CanFreeze: true, IsFrozen: false })
            brush.Freeze();
        
        return brush;
    }
    
    private static string BrushKey(string key) => $"{Brush}-{key}";
    private static string ColorKey(string key) => $"{Color}-{key}";
    
    public static class MaterialDesign
    {
        public static class Brushes
        {
            public static void AddAll(Application application) => AddAll(application.Resources);
            public static void AddAll(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.MaterialDesign.AllColors);

            public static void AddAmber(Application application) => AddAmber(application.Resources);
            public static void AddAmber(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Amber);

            public static void AddBlue(Application application) => AddBlue(application.Resources);
            public static void AddBlue(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Blue);

            public static void AddCyan(Application application) => AddCyan(application.Resources);
            public static void AddCyan(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Cyan);

            public static void AddEmerald(Application application) => AddEmerald(application.Resources);
            public static void AddEmerald(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Emerald);

            public static void AddFuchsia(Application application) => AddFuchsia(application.Resources);
            public static void AddFuchsia(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Fuchsia);

            public static void AddGray(Application application) => AddGray(application.Resources);
            public static void AddGray(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Gray);

            public static void AddGreen(Application application) => AddGreen(application.Resources);
            public static void AddGreen(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Green);

            public static void AddIndigo(Application application) => AddIndigo(application.Resources);
            public static void AddIndigo(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Indigo);

            public static void AddLime(Application application) => AddLime(application.Resources);
            public static void AddLime(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Lime);

            public static void AddNeutral(Application application) => AddNeutral(application.Resources);
            public static void AddNeutral(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Neutral);

            public static void AddOrange(Application application) => AddOrange(application.Resources);
            public static void AddOrange(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Orange);

            public static void AddPink(Application application) => AddPink(application.Resources);
            public static void AddPink(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Pink);

            public static void AddPurple(Application application) => AddPurple(application.Resources);
            public static void AddPurple(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Purple);

            public static void AddRed(Application application) => AddRed(application.Resources);
            public static void AddRed(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Red);

            public static void AddRose(Application application) => AddRose(application.Resources);
            public static void AddRose(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Rose);

            public static void AddSky(Application application) => AddSky(application.Resources);
            public static void AddSky(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Sky);

            public static void AddSlate(Application application) => AddSlate(application.Resources);
            public static void AddSlate(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Slate);

            public static void AddStone(Application application) => AddStone(application.Resources);
            public static void AddStone(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Stone);
            
            public static void AddTeal(Application application) => AddTeal(application.Resources);
            public static void AddTeal(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Teal);
            
            public static void AddViolet(Application application) => AddViolet(application.Resources);
            public static void AddViolet(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Violet);
            
            public static void AddYellow(Application application) => AddYellow(application.Resources);
            public static void AddYellow(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Yellow);
            
            public static void AddZinc(Application application) => AddZinc(application.Resources);
            public static void AddZinc(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Zinc);
        }
        
        public static class Colors
        {
            public static void AddAll(Application application) => AddAll(application.Resources);
            public static void AddAll(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.AllColors);

            public static void AddAmber(Application application) => AddAmber(application.Resources);
            public static void AddAmber(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.Amber);

            public static void AddBlue(Application application) => AddBlue(application.Resources);
            public static void AddBlue(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.Blue);

            public static void AddBlueGray(Application application) => AddBlueGray(application.Resources);
            public static void AddBlueGray(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.BlueGray);

            public static void AddBrown(Application application) => AddBrown(application.Resources);
            public static void AddBrown(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.Brown);

            public static void AddCyan(Application application) => AddCyan(application.Resources);
            public static void AddCyan(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.Cyan);

            public static void AddDeepOrange(Application application) => AddDeepOrange(application.Resources);
            public static void AddDeepOrange(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.DeepOrange);

            public static void AddDeepPurple(Application application) => AddDeepPurple(application.Resources);
            public static void AddDeepPurple(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.DeepPurple);

            public static void AddGray(Application application) => AddGray(application.Resources);
            public static void AddGray(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.Gray);

            public static void AddGreen(Application application) => AddGreen(application.Resources);
            public static void AddGreen(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.Green);

            public static void AddIndigo(Application application) => AddIndigo(application.Resources);
            public static void AddIndigo(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.Indigo);

            public static void AddLightBlue(Application application) => AddLightBlue(application.Resources);
            public static void AddLightBlue(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.LightBlue);

            public static void AddLightGreen(Application application) => AddLightGreen(application.Resources);
            public static void AddLightGreen(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.LightGreen);

            public static void AddLime(Application application) => AddLime(application.Resources);
            public static void AddLime(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.Lime);

            public static void AddOrange(Application application) => AddOrange(application.Resources);
            public static void AddOrange(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.Orange);

            public static void AddPink(Application application) => AddPink(application.Resources);
            public static void AddPink(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.Pink);

            public static void AddPurple(Application application) => AddPurple(application.Resources);
            public static void AddPurple(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.Purple);

            public static void AddRed(Application application) => AddRed(application.Resources);
            public static void AddRed(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.Red);
            
            public static void AddTeal(Application application) => AddTeal(application.Resources);
            public static void AddTeal(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.Teal);
            
            public static void AddYellow(Application application) => AddYellow(application.Resources);
            public static void AddYellow(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.MaterialDesign.Yellow);
        }
    }
    
    public static class Tailwind
    {
        public static class Brushes
        {
            public static void AddAll(Application application) => AddAll(application.Resources);
            public static void AddAll(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.AllColors);

            public static void AddAmber(Application application) => AddAmber(application.Resources);
            public static void AddAmber(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Amber);

            public static void AddBlue(Application application) => AddBlue(application.Resources);
            public static void AddBlue(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Blue);

            public static void AddCyan(Application application) => AddCyan(application.Resources);
            public static void AddCyan(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Cyan);

            public static void AddEmerald(Application application) => AddEmerald(application.Resources);
            public static void AddEmerald(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Emerald);

            public static void AddFuchsia(Application application) => AddFuchsia(application.Resources);
            public static void AddFuchsia(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Fuchsia);

            public static void AddGray(Application application) => AddGray(application.Resources);
            public static void AddGray(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Gray);

            public static void AddGreen(Application application) => AddGreen(application.Resources);
            public static void AddGreen(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Green);

            public static void AddIndigo(Application application) => AddIndigo(application.Resources);
            public static void AddIndigo(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Indigo);

            public static void AddLime(Application application) => AddLime(application.Resources);
            public static void AddLime(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Lime);

            public static void AddNeutral(Application application) => AddNeutral(application.Resources);
            public static void AddNeutral(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Neutral);

            public static void AddOrange(Application application) => AddOrange(application.Resources);
            public static void AddOrange(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Orange);

            public static void AddPink(Application application) => AddPink(application.Resources);
            public static void AddPink(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Pink);

            public static void AddPurple(Application application) => AddPurple(application.Resources);
            public static void AddPurple(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Purple);

            public static void AddRed(Application application) => AddRed(application.Resources);
            public static void AddRed(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Red);

            public static void AddRose(Application application) => AddRose(application.Resources);
            public static void AddRose(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Rose);

            public static void AddSky(Application application) => AddSky(application.Resources);
            public static void AddSky(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Sky);

            public static void AddSlate(Application application) => AddSlate(application.Resources);
            public static void AddSlate(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Slate);

            public static void AddStone(Application application) => AddStone(application.Resources);
            public static void AddStone(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Stone);

            public static void AddTeal(Application application) => AddTeal(application.Resources);
            public static void AddTeal(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Teal);

            public static void AddViolet(Application application) => AddViolet(application.Resources);
            public static void AddViolet(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Violet);

            public static void AddYellow(Application application) => AddYellow(application.Resources);
            public static void AddYellow(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Yellow);

            public static void AddZinc(Application application) => AddZinc(application.Resources);
            public static void AddZinc(ResourceDictionary resources) => AddBrushes(resources, Palettes.Colors.Tailwind.Zinc);
        }
        
        public static class Colors
        {
            public static void AddAll(Application application) => AddAll(application.Resources);
            public static void AddAll(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.AllColors);

            public static void AddAmber(Application application) => AddAmber(application.Resources);
            public static void AddAmber(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Amber);

            public static void AddBlue(Application application) => AddBlue(application.Resources);
            public static void AddBlue(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Blue);

            public static void AddCyan(Application application) => AddCyan(application.Resources);
            public static void AddCyan(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Cyan);

            public static void AddEmerald(Application application) => AddEmerald(application.Resources);
            public static void AddEmerald(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Emerald);

            public static void AddFuchsia(Application application) => AddFuchsia(application.Resources);
            public static void AddFuchsia(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Fuchsia);

            public static void AddGray(Application application) => AddGray(application.Resources);
            public static void AddGray(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Gray);

            public static void AddGreen(Application application) => AddGreen(application.Resources);
            public static void AddGreen(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Green);

            public static void AddIndigo(Application application) => AddIndigo(application.Resources);
            public static void AddIndigo(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Indigo);

            public static void AddLime(Application application) => AddLime(application.Resources);
            public static void AddLime(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Lime);

            public static void AddNeutral(Application application) => AddNeutral(application.Resources);
            public static void AddNeutral(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Neutral);

            public static void AddOrange(Application application) => AddOrange(application.Resources);
            public static void AddOrange(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Orange);

            public static void AddPink(Application application) => AddPink(application.Resources);
            public static void AddPink(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Pink);

            public static void AddPurple(Application application) => AddPurple(application.Resources);
            public static void AddPurple(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Purple);

            public static void AddRed(Application application) => AddRed(application.Resources);
            public static void AddRed(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Red);

            public static void AddRose(Application application) => AddRose(application.Resources);
            public static void AddRose(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Rose);

            public static void AddSky(Application application) => AddSky(application.Resources);
            public static void AddSky(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Sky);

            public static void AddSlate(Application application) => AddSlate(application.Resources);
            public static void AddSlate(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Slate);

            public static void AddStone(Application application) => AddStone(application.Resources);
            public static void AddStone(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Stone);

            public static void AddTeal(Application application) => AddTeal(application.Resources);
            public static void AddTeal(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Teal);

            public static void AddViolet(Application application) => AddViolet(application.Resources);
            public static void AddViolet(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Violet);

            public static void AddYellow(Application application) => AddYellow(application.Resources);
            public static void AddYellow(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Yellow);

            public static void AddZinc(Application application) => AddZinc(application.Resources);
            public static void AddZinc(ResourceDictionary resources) => AddColors(resources, Palettes.Colors.Tailwind.Zinc);
        }
    }
}