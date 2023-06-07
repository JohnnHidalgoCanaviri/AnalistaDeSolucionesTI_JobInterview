using System;

public class Book
{
    private string author;
    private int chapters;
    private string group;
    private string name;
    private string testament;
    private Abbre abbre;

    public Book()
    {
        this.author = "";
        this.chapters = 0;
        this.group = "";
        this.name = "";
        this.testament = "";
        
	}

    public string Author { get => Author1; set => Author1 = value; }
    public int Chapters { get => chapters; set => chapters = value; }
    public string Group { get => group; set => group = value; }
    public string Name { get => name; set => name = value; }
    public string Testament { get => testament; set => testament = value; }
    public Abbre Abbre { get => abbre; set => abbre = value; }
}
