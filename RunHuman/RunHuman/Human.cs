using System;
using System.Windows.Forms;

public class Human
{
    string name = "";
    enum gender {man, woman};
    int age;
    double height;
    int weight;
    gender g;

    public Human(string name) {
        this.name = name;
    }

    public Human(string n, int g, int a)
	{
        name = n;
        this.g = (gender)g;
        age = a;
		
	}

    public Human(string n, int g, int a, double l, int w)
    {
        name = n;
        this.g = (gender)g;
        age = a;
        height = l;
        weight = w;
    }

    public double CalBMI()
    {
        if(weight > 0 && height > 0)
        {
            return Math.Round(weight / (height * height), 2);
        }
        else
        {
            return 0;
        }
    }

    public void Hello()
    {
        Console.WriteLine("Hello. My name is {0}. I am a {1}.", name, g);
    }
	public void SaySomething()
	{
		MessageBox.Show("Oh shit run");
	}
    
}
