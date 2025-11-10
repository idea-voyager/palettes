namespace PatioCode.Palettes.WPF.Preview;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        PaletteService.FreezeBrushes(this);
    }
}