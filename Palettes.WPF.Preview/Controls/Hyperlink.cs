namespace PatioCode.Palettes.WPF.Preview.Controls;

public class Hyperlink : Button
{
    public Hyperlink() => Click += (_, _) =>
    {
        if (Content is string { Length: > 0 } link)
            Process.Start(link);
    };
}