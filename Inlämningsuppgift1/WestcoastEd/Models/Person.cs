namespace WestcoastEd;


public abstract class Person            //superklass för samtliga användare, 
{
    public PersonInfo Info {get;}
    protected Person(PersonInfo info) => Info = info;

    public abstract string Role {get;}

    public override string ToString() => $"{Role}: {Info.FirstName} {Info.LastName}, Phone: {Info.PhoneNr}, Personal Number: {Info.PersnoNr}, Address: {Info.Adress}, Zip Code: {Info.ZipCode}, City: {Info.City}";
}
