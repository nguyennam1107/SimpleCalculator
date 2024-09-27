using System;  
using System.Data;  
using Gtk;  

public class Calculator : Window  
{  
    private Entry entry;  

    public Calculator() : base("Máy Tính Đơn Giản")  
    {  
        SetDefaultSize(600, 800);  
        SetPosition(WindowPosition.Center);  

        Box vbox = new Box(Orientation.Vertical, 0);  
        entry = new Entry();  
        vbox.PackStart(entry, false, false, 0);  

        string[] buttons = { "7", "8", "9", "/", "4", "5", "6", "*", "1", "2", "3", "-", "0", "C", "=", "+" };  
        Grid grid = new Grid();  
        grid.RowSpacing = 5;
        grid.ColumnSpacing = 5; 

        int k = 0;  
        for (int i = 0; i < 4; i++)  
        {  
            for (int j = 0; j < 4; j++)  
            {  
                Button button = new Button(buttons[k]);  
                button.Clicked += OnButtonClicked;  

                
                grid.Attach(button, j, i, 1, 1);  
                button.Show(); 
                k++;  
            }  
        }  

        vbox.PackStart(grid, true, true, 0);  
        Add(vbox);  
        ShowAll();  
        DeleteEvent += (o, args) => Application.Quit();  
    }  

    void OnButtonClicked(object? sender, EventArgs args)  
    {  
        if (sender is Button button)  
        {  
            string text = button.Label;  

            if (text == "C")  
            {  
                entry.Text = "";  
            }  
            else if (text == "=")  
            {  
                try  
                {  
                    var result = new DataTable().Compute(entry.Text, null);  
                    entry.Text = result.ToString();  
                }  
                catch  
                {  
                    entry.Text = "Lỗi";  
                }  
            }  
            else  
            {  
                entry.Text += text;  
            }  
        }  
    }  

    public static void Main()  
    {  
        Application.Init();  
        new Calculator();  
        Application.Run();  
    }  
}