using System.Windows.Input;

namespace Odem.Admin.UserControls;

public partial class NavButton
{
    public static readonly BindableProperty IconProperty = BindableProperty.Create(
        nameof(Icon), typeof(ImageSource), typeof(NavButton), null);
    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command), typeof(ICommand), typeof(NavButton));

    public ImageSource Icon
    {
        get { return (ImageSource)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public new static readonly BindableProperty ContentProperty = BindableProperty.Create(
        nameof(TextContent), typeof(string), typeof(NavButton));

    public string TextContent
    {
        get => (string)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    private void OnButtonClicked(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler Clicked;
    
    
    public NavButton()
    {
        InitializeComponent();
        Clicked += OnButtonClicked;
    }
}