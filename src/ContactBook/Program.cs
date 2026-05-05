namespace ContactBook;
public class Program
{
    public static void Main()
    {
        
       Contact c1 = new Contact();
       Contact c2 = new Contact("Luis");
       Contact c3 = new Contact("Prinima", "Mercado");
       Contact c4 = new Contact("Gerardo", "Rosas", "123-786-1234");
       Contact c5 = new Contact("Hector", "Rosas", "123-732-9872", "hector@gmail.com");
    }
}
